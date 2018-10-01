using System;
using System.Linq;
using PlusArgent_v1._0.Interfaces;
using PlusArgent_v1._0.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace PlusArgent_v1._0.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(PlusArgentContext context) : base (context)
        {

        }


        public List<Category> GetByUser(int IdUser)
        {
            return DbSet.AsNoTracking().Where(c => c.IdUser == IdUser).ToList();
        }
    }
}