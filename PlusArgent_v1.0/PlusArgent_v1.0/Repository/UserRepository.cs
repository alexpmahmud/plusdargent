using System;
using System.Linq;
using PlusArgent_v1._0.Interfaces;
using PlusArgent_v1._0.Models;
using System.Data.Entity;


namespace PlusArgent_v1._0.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(PlusArgentContext context) : base (context)
        {

        }

        public User GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }


        public User GetLogin(string email,string password)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email  && c.Password == password);
        }
    }
}