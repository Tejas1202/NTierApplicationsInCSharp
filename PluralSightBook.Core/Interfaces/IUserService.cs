using PluralSightBook.Core.Models;

namespace PluralSightBook.Core.Interfaces
{
    public interface IUserService
    {
        User GetUserByEmail(string email);
    }
}