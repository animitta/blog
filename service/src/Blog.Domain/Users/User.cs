using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using static Blog.Users.UserConsts;

namespace Blog.Users
{
    public class User : BasicAggregateRoot<Guid>
    {
        private User()
        {
        }

        internal User(Guid id, string name, Sex sex, string email, string mobile, string hashedPassword)
            : base(id)
        {
            Sex = sex;
            LoginTimes = 0;
            LastLoginTime = DateTime.MinValue;

            SetName(name);
            SetEmail(email);
            SetMobile(mobile);
            SetHashedPassword(hashedPassword);
        }

        #region Properties
        public string Name { get; private set; }

        public Sex Sex { get; private set; }

        public string Email { get; private set; }

        public bool EmailConfirmed { get; internal set; }

        public string Mobile { get; private set; }

        public bool MobileConfirmed { get; internal set; }

        public string HashedPassword { get; internal set; }

        public int LoginTimes { get; private set; }

        public DateTime LastLoginTime { get; private set; }
        #endregion

        #region Methods
        public void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), MaxNameLength, MinNameLength);
        }

        public void SetEmail(string email)
        {
            Email = Check.NotNullOrWhiteSpace(email, nameof(email), MaxEmailLength, MinEmailLength);
            EmailConfirmed = false;
        }

        public void SetMobile(string mobile)
        {
            if (!string.IsNullOrWhiteSpace(mobile))
            {
                Mobile = Check.NotNullOrWhiteSpace(mobile, nameof(mobile), MobileLength, MobileLength);
            }
            MobileConfirmed = false;
        }

        internal void SetHashedPassword(string hashedPassword)
        {
            HashedPassword = Check.NotNullOrWhiteSpace(hashedPassword, nameof(hashedPassword), MaxHashedPasswordLength, MinHashedPasswordLength);
        }

        internal void Login()
        {
            LoginTimes++;
            LastLoginTime = DateTime.Now;
        }
        #endregion
    }
}
