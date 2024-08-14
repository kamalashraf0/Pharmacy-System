using Microsoft.AspNetCore.Mvc;
using MVC_Day_3.Data;

namespace MVC_Day_3.Controllers
{
    public class CompanyController : Controller
    {

        ApplicationDBContext _dbContext;

        public CompanyController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
