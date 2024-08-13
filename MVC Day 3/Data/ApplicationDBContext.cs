using Microsoft.EntityFrameworkCore;
using MVC_Day_3.Models;

namespace MVC_Day_3.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drug>(
                builder =>
                {
                    builder.Property(n => n.Name).IsRequired().HasMaxLength(50);

                });


            modelBuilder.Entity<Company>(
                Builder =>
                {
                    Builder.Property(n => n.Name).IsRequired().HasMaxLength(20);
                });
        }

        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
