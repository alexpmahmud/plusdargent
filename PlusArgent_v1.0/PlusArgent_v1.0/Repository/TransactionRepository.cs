using System;
using System.Linq;
using PlusArgent_v1._0.Interfaces;
using PlusArgent_v1._0.Models;
using System.Data.Entity;


namespace PlusArgent_v1._0.Repository
{
    public class TransactionRepository : Repository<User>, ITransactionRepository
    {
        public TransactionRepository(PlusArgentContext context) : base (context)
        {

        }

    }
}