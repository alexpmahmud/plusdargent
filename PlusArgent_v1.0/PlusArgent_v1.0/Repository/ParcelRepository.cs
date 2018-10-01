using System;
using System.Linq;
using PlusArgent_v1._0.Interfaces;
using PlusArgent_v1._0.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace PlusArgent_v1._0.Repository
{
    public class ParcelRepository : Repository<Parcel>, IParcelRepository
    {
        public ParcelRepository(PlusArgentContext context) : base (context)
        {

        }

        public IEnumerable<Parcel> GetByBook(int idbook)
        {
            return DbSet.AsNoTracking().Where(c => c.IdBook == idbook).ToList();
        }

    }
}