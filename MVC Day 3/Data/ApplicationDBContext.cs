using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVC_Day_3.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {


        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }





        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }





    }
}
