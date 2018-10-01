
using PlusArgent_v1._0.Models;
using System.Collections.Generic;

namespace PlusArgent_v1._0.Interfaces
{
    public interface IParcelRepository : IRepository<Parcel>
    {
        IEnumerable<Parcel> GetByBook(int ibook);
    }
  
}
