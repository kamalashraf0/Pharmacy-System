using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Day_3.Models
{
    public class Company
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        [MaxLength(50, ErrorMessage = "Should be less than 50 characters.")]
        [MinLength(3, ErrorMessage = "Should be more than 2 characters.")]
        [Remote("UniqueName", "Companies", AdditionalFields = nameof(Id), ErrorMessage = "Name must be unique.")]
        public string Name { get; set; }


        public virtual List<Drug>? Drugs { get; set; }
    }
}
