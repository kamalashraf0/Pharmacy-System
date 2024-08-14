using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Day_3.Models
{
    public class Drug
    {

        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
        [MaxLength(50, ErrorMessage = "Should be less than 50 letters")]
        [MinLength(3, ErrorMessage = "Should be more than 2 letters")]
        [Remote("UniqueName", "Drug", ErrorMessage = "Name must be Unique")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Manufacture Date is required.")]
        public DateTime ManufactureDate { get; set; }

        [Required(ErrorMessage = "Expiration Date is required.")]
        public DateTime ExpirationDate { get; set; }


        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "Company is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid company.")]
        public int CompanyId { get; set; }

        public virtual Company? Company { get; set; }


    }
}
