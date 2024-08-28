using System.ComponentModel.DataAnnotations;

namespace MVC_Day_3.ViewModel
{
    public class RoleViewModel
    {


        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
