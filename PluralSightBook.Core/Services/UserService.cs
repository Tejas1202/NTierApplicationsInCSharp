using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Models;

namespace PluralSightBook.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IQueryUsersByEmail _queryUserByEmail;

        public UserService(IQueryUsersByEmail queryUserByEmail)
        {
            _queryUserByEmail = queryUserByEmail;
        }

        public User GetUserByEmail(string email)
        {
            return _queryUserByEmail.GetUserByEmail(email);
        }
    }
}
