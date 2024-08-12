using Microsoft.EntityFrameworkCore;

namespace MVC_Day_3.Models
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Drug> Drug { get; set; }
    }
}
