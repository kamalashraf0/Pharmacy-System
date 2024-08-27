using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Day_3.ViewModel
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember Me !!")]
        public bool RememberMe { get; set; }
    }
}
