
using PlusArgent_v1._0.Models;
using PlusArgent_v1._0.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PlusArgent_v1._0.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        List<Book> GetByUser(int iduser);

        List<BookTransactions> GetListMonth(int mm);
    }
}
