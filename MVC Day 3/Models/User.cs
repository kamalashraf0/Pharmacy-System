using System.ComponentModel.DataAnnotations;

namespace MVC_Day_3.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
