using Cen_Con.DAL.DataContext.Entity;
using Microsoft.EntityFrameworkCore;
namespace Cen_Con.DAL.DataContext
{
    public class CenConDbContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<ConcreteOrder> OrderedBy { get; set; }
        public DbSet<ConcreteSuppliers> ConcreteSuppliers { get; set; }
        public DbSet<Crews> Crews { get; set; }
        public DbSet<Finishes> Finishes { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public CenConDbContext(DbContextOptions options) : base(options) { }
        public static string TablePrefix { get; set; } = "";
        public static string Schema { get; set; } = "dbo";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
