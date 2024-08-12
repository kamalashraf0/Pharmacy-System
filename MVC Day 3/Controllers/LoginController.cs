using Microsoft.AspNetCore.Mvc;
using MVC_Day_3.Models;

namespace MVC_Day_3.Controllers
{
    public class LoginController : Controller
    {
        private static List<Login> log = new List<Login>()
        {
            new Login() { Username="Kamal", Password = "kam123#"},
            new Login() { Username="ahmed", Password = "123"}
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = log.FirstOrDefault(x => x.Username.Trim() == loginModel.Username.Trim() && x.Password == loginModel.Password);
                if (user != null)
                {
                    // Redirect to a valid action, assuming Home action exists in HomeController
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.logerror = "error";
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return View(loginModel);
                }
            }
            return View(loginModel);
        }
    }
}
