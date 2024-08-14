using Microsoft.EntityFrameworkCore;
using MVC_Day_3.Models;

namespace MVC_Day_3.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
