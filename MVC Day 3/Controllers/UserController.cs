using Microsoft.AspNetCore.Mvc;
using MVC_Day_3.Data;
using MVC_Day_3.Models;
using MVC_Day_3.Repository.Helpers;


namespace MVC_Day_3.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _dbcontext;

        public UserController(ApplicationDBContext context)
        {
            _dbcontext = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //int userId;
            if (!int.TryParse(HttpContext.Session.GetString("UserId"), out int userId))
            {
                return RedirectToAction("Index", "Login");
            }

            var user = _dbcontext.Users.Find(userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _dbcontext.Users.Find(user.Id);
                if (existingUser != null)
                {

                    existingUser.Email = user.Email;
                    existingUser.Password = PasswordHelper.HashPassword(user.Password);

                    _dbcontext.SaveChanges();
                    TempData["Message"] = "User data updated successfully!";
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete()
        {
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var user = _dbcontext.Users.Find(userId);

            if (user != null)
            {
                _dbcontext.Users.Remove(user);
                _dbcontext.SaveChanges();
                HttpContext.Session.Clear();
                Response.Cookies.Delete("UserEmail");
                return RedirectToAction("Index", "Login");
            }

            return RedirectToAction("Index");
        }
    }
}
