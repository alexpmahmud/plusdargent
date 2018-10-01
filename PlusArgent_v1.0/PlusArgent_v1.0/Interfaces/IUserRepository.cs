
using PlusArgent_v1._0.Models;

namespace PlusArgent_v1._0.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {

        User GetByEmail(string email);
        User GetLogin(string email, string password);
    }
}
