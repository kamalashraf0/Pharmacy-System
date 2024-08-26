using Microsoft.AspNetCore.Mvc;
using MVC_Day_3.Filtters;

namespace MVC_Day_3.Controllers
{
    [HandleError]
    public class FilterController : Controller
    {

        public IActionResult Index()
        {
            throw new Exception("Exception Fr Index");
        }
        public IActionResult Index2()
        {
            throw new Exception("Exception second Index");
        }
    }
}
