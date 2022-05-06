using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace Blog.Users
{
    public class UserIdentitySpecification : Specification<User>
    {
        private readonly string _name;
        private readonly string _email;
        private readonly string _mobile;

        public UserIdentitySpecification(string name, string email, string mobile)
        {
            _name = name;
            _email = email;
            _mobile = mobile;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return user => user.Name == _name || (user.Mobile == _mobile && user.MobileConfirmed) || (user.Email == _email && user.EmailConfirmed);
        }
    }
}
