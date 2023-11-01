using Microsoft.EntityFrameworkCore;
namespace OrderDAL.Models
{
    public class ApplicationDBContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            public DbSet<Order> Orders { get; set; }
         }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entity models here.
        // Example: modelBuilder.Entity<Order>().ToTable("Orders");
    }
}
}
