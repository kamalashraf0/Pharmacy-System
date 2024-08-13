using System.ComponentModel.DataAnnotations;

namespace MVC_Day_3.Models
{
    public class Drug
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ManufactureDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; }

        public string? ImagePath { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public virtual Company? Company { get; set; }


    }
}
