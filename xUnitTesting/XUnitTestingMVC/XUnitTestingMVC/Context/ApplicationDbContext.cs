using Microsoft.EntityFrameworkCore;
using XUnitTestingMVC.Models;

namespace XUnitTestingMVC.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<Company> company { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Company>()
                .Property(x => x.City).HasMaxLength(100)
                .IsRequired();
            builder.Entity<Company>()
                .Property(x => x.Name).HasMaxLength(100)
                .IsRequired();
            builder.Entity<Company>()
               .Property(x => x.Address).HasMaxLength(100)
               .IsRequired();

            builder.Entity<Company>()
                .HasKey(x => x.Id);

            builder.Entity<Company>()
                .Property(x => x.Address).HasMaxLength(50)
                .IsRequired();


            base.OnModelCreating(builder);
        }

    }
}
