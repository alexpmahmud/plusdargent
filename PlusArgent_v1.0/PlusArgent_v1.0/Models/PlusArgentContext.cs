using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PlusArgent_v1._0.Models
{
    public class PlusArgentContext : DbContext
    {
        public PlusArgentContext() : base ("name=PlusArgentConnectionString")
        {
            //Desativa a criacao automatica do banco de dados
            Database.SetInitializer<DbContext>(null);

            //Recria o banco de dados
            //Database.SetInitializer(new DropCreateDatabaseAlways<PlusArgentContext>());
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Parcel>().ToTable("Parcels");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<User>().ToTable("Users");



            /*
            modelBuilder.Entity<Account>()
                .HasRequired<User>(s => s.User)
                .WithMany(g => g.Accounts)
                .HasForeignKey<int>(s => s.User.IdUser);

            modelBuilder.Entity<Category>()
                .HasRequired<User>(s => s.User)
                .WithMany(g => g.Categories)
                .HasForeignKey<int>(s => s.User.IdUser);

            modelBuilder.Entity<Book>()
                .HasRequired<Account>(s => s.Account)
                .WithMany(g => g.Books)
                .HasForeignKey<int>(s => s.User.IdAccount);

            modelBuilder.Entity<Book>()
                .HasRequired<Category>(s => s.Category)
                .WithMany(g => g.Books)
                .HasForeignKey<int>(s => s.IdCategory);

            modelBuilder.Entity<Transaction>()
                .HasRequired<Account>(s => s.Account)
                .WithMany(g => g.Transactions)
                .HasForeignKey<int>(s => s.IdAccount);

            modelBuilder.Entity<Transaction>()
                .HasRequired<Book>(s => s.Book)
                .WithMany(g => g.Transactions)
                .HasForeignKey<int>(s => s.IdBook);

            modelBuilder.Entity<Parcel>()
                .HasRequired<Book>(s => s.Book)
                .WithMany(g => g.Parcels)
                .HasForeignKey<int>(s => s.IdBook);
             */
        }
    }

}