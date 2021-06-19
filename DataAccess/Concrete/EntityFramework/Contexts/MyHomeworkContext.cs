using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class MyHomeworkContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-ASD8F4L;Database=MyHomework;Trusted_Connection=true");
        }
        public DbSet<TurkishEvent> TurkishEvents { get; set; }
        public DbSet<ItalianEvent> ItalianEvents { get; set; }
    }
}
