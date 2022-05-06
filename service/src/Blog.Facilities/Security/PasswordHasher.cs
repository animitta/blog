using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Volo.Abp.DependencyInjection;

namespace Ibms.Security
{
    public class PasswordHasher : IPasswordHasher, ISingletonDependency
    {
        private const int SaltSize = 128 / 8;
        private const int IterationCount = 10000;
        private const int NumBytesRequested = 256 / 8;
        private const KeyDerivationPrf Prf = KeyDerivationPrf.HMACSHA256;
        private static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();

        public string Hash(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var salt = new byte[SaltSize];
            Random.GetBytes(salt);
            var subKey = KeyDerivation.Pbkdf2(password, salt, Prf, IterationCount, NumBytesRequested);

            var outputBytes = new byte[13 + salt.Length + subKey.Length];
            outputBytes[0] = 0x01; // format marker
            WriteNetworkByteOrder(outputBytes, 1, (uint)Prf);
            WriteNetworkByteOrder(outputBytes, 5, IterationCount);
            WriteNetworkByteOrder(outputBytes, 9, SaltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subKey, 0, outputBytes, 13 + SaltSize, subKey.Length);

            return Convert.ToBase64String(outputBytes);
        }

        public bool Verify(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == null)
            {
                throw new ArgumentNullException(nameof(hashedPassword));
            }

            if (providedPassword == null)
            {
                throw new ArgumentNullException(nameof(providedPassword));
            }

            var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            if (decodedHashedPassword.Length == 0)
            {
                return false;
            }

            switch (decodedHashedPassword[0])
            {
                case 0x01:
                    if (VerifyHashedPasswordV3(decodedHashedPassword, providedPassword, out var embeddedIterationCount))
                    {
                        return embeddedIterationCount >= IterationCount;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    return false;
            }
        }

        private static uint ReadNetworkByteOrder(IReadOnlyList<byte> buffer, int offset)
        {
            return ((uint)buffer[offset + 0] << 24) | ((uint)buffer[offset + 1] << 16) | ((uint)buffer[offset + 2] << 8) | buffer[offset + 3];
        }

        private static void WriteNetworkByteOrder(IList<byte> buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }

        private static bool VerifyHashedPasswordV3(byte[] hashedPassword, string password, out int iterationCount)
        {
            iterationCount = default;

            try
            {
                var prf = (KeyDerivationPrf)ReadNetworkByteOrder(hashedPassword, 1);
                iterationCount = (int)ReadNetworkByteOrder(hashedPassword, 5);
                var saltLength = (int)ReadNetworkByteOrder(hashedPassword, 9);

                if (saltLength < 128 / 8)
                {
                    return false;
                }

                var salt = new byte[saltLength];
                Buffer.BlockCopy(hashedPassword, 13, salt, 0, salt.Length);

                var subKeyLength = hashedPassword.Length - 13 - salt.Length;
                if (subKeyLength < 128 / 8)
                {
                    return false;
                }

                var expectedSubKey = new byte[subKeyLength];
                Buffer.BlockCopy(hashedPassword, 13 + salt.Length, expectedSubKey, 0, expectedSubKey.Length);
                var actualSubKey = KeyDerivation.Pbkdf2(password, salt, prf, iterationCount, subKeyLength);

                return CryptographicOperations.FixedTimeEquals(actualSubKey, expectedSubKey);
            }
            catch
            {
                return false;
            }
        }
    }
}
