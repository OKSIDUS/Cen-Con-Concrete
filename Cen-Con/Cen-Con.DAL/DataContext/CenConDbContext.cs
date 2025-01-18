using Cen_Con.DAL.DataContext.Entity;
using Microsoft.EntityFrameworkCore;
namespace Cen_Con.DAL.DataContext
{
    public class CenConDbContext : DbContext
    {
        public DbSet<Types> Types { get; set; }
        public CenConDbContext(DbContextOptions options) : base(options) { }
        public static string TablePrefix { get; set; } = "";
        public static string Schema { get; set; } = "dbo";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
