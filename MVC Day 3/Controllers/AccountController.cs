using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel UserViewModel)
        {
            if (ModelState.IsValid)
            {
                //Mapping
                ApplicationUser appuser = new ApplicationUser();
                appuser.Address = UserViewModel.Address;
                appuser.UserName = UserViewModel.Username;
                //appuser.PasswordHash = UserViewModel.Password;

                //saveDatabase
                IdentityResult result = await _userManager.CreateAsync(appuser, UserViewModel.Password);  // hashPassword

                if (result.Succeeded)
                {
                    //assign to role
                    await _userManager.AddToRoleAsync(appuser, "Admin");  //addtorole
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

        [HttpGet]
        public async Task<IActionResult> Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appuser = await _userManager.FindByNameAsync(loginUserViewModel.Name);

                if (appuser != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(appuser, loginUserViewModel.Password);

                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("UserAddress", appuser.Address));
                        await _signInManager.SignInWithClaimsAsync(appuser, loginUserViewModel.RememberMe, claims);

                        //await _signInManager.SignInAsync(appuser, loginUserViewModel.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            ModelState.AddModelError("", "Username or Password is Wrong");


            return View(loginUserViewModel);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
