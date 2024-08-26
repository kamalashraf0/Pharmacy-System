using System.ComponentModel.DataAnnotations;

namespace MVC_Day_3.ViewModel
{
    public class RegisterViewModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
    }
}
