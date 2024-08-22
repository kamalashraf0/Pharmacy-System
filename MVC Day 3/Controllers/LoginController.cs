using Microsoft.AspNetCore.Mvc;
using MVC_Day_3.Data;
using MVC_Day_3.Repository.Helpers;

namespace MVC_Day_3.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public LoginController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            string hashedPassword = PasswordHelper.HashPassword(password);
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                TempData["Username"] = user.Username;


                Response.Cookies.Append("UserEmail", user.Email);

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Invalid username or password";
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("UserEmail");
            return RedirectToAction("Index");
        }
    }
}
