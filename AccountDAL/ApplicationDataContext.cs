using AccountDAL.Account;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDAL
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext()
            : base("DBConnectionString")
        {
            //If model change, It will re-create new database.
            Database.SetInitializer<ApplicationDataContext>(new DropCreateDatabaseIfModelChanges<ApplicationDataContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Set primary key to Person table
            modelBuilder.Entity<Login>().HasKey(m => m.Id).Property(m => m.Id).IsRequired();
            //name fleld is required

            modelBuilder.Entity<Login>().Property(p => p.EmployeeId).IsRequired();
            //surname is required
            modelBuilder.Entity<Login>().Property(p => p.UserName).IsRequired();

            //set primary key to Address table
            modelBuilder.Entity<Login>().HasKey(m => m.Password);
            modelBuilder.Entity<Login>().HasKey(m => m.IsSeesionActive);
            modelBuilder.Entity<Login>().HasKey(m => m.LoginStartTime);
            modelBuilder.Entity<Login>().HasKey(m => m.LoginEndTime);
        }
        public DbSet<Login> Login { get; set; }
       
    }
}
