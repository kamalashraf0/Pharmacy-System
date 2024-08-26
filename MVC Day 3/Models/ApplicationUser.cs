using Microsoft.AspNetCore.Identity;

namespace MVC_Day_3.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string? Address { get; set; }




    }
}
