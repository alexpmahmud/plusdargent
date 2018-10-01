using System;
using System.Linq;
using PlusArgent_v1._0.Interfaces;
using PlusArgent_v1._0.Models;
using System.Data.Entity;
using System.Collections.Generic;
using PlusArgent_v1._0.ViewModels;

namespace PlusArgent_v1._0.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(PlusArgentContext context) : base(context)
        {

        }

        public List<Book> GetByUser(int iduser)
        {
            return DbSet.AsNoTracking().Where(c => c.Account.IdUser == iduser).ToList();
        }

        public List<BookTransactions> GetListMonth(int mm)
        {

            var result = (from a in Db.Book
                          join al in Db.Transactions on
                          new { C1 = a.IdBook, C2 = a.Date.Month } equals
                          new { C1 = al.IdBook, C2 = mm } into ALL
                          from al in ALL.DefaultIfEmpty()
                          select new BookTransactions
                          {
                              IdBook = a.IdBook,
                              Description = a.Description
                          }).ToList();

            return result;
            /*
                        var result = Db.Book
                                    .GroupJoin(Db.Transactions, book => book.IdBook, transactions => transactions.IdBook,
                               (book, transactions) => new { Book = book, Transactions = transactions.DefaultIfEmpty() })
                           .SelectMany(a => a.Transactions, (a, transactions) => new
                           {
                               a.Book.IdBook,
                               transactions.Value
                           });

                        return result;
            */
        }


    }
}