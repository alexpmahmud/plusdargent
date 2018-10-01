
using PlusArgent_v1._0.Models;
using System.Collections.Generic;

namespace PlusArgent_v1._0.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        List<Account> GetByUser(int IdUser);
    }
}
