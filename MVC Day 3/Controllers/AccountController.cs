using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Day_3.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _userManager = userManager;
            _signInManager = signinManager;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel UserViewModel)
        {
            if (ModelState.IsValid)
            {
                //Mapping
                ApplicationUser appuser = new ApplicationUser();
                appuser.Address = UserViewModel.Address;
                appuser.UserName = UserViewModel.Username;
                appuser.PasswordHash = UserViewModel.Password;

                //saveDatabase
                IdentityResult result = await _userManager.CreateAsync(appuser);

                if (result.Succeeded)
                {
                    //cookie
                    await _signInManager.SignInAsync(appuser, false);
                    return RedirectToAction("Index", "Home");

                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View();
        }

    }
}
