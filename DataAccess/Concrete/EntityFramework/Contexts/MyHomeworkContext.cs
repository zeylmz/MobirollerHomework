using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class MyHomeworkContext : DbContext
    {        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(@"Server=mssql_server,1433;Initial Catalog=MyHomework;User ID=SA;Password=P4ssw0rd+");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-ASD8F4L;Database=MyHomework;Trusted_Connection=true");
        }
        public DbSet<TurkishEvent> TurkishEvents { get; set; }
        public DbSet<ItalianEvent> ItalianEvents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
