using Mamba.Models;
using Mamba.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mamba.Controllers
{
    public class AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = new AppUser
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Email = vm.Email,
                UserName = vm.UserName
            };
            IdentityResult result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(vm);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = await _userManager.FindByNameAsync(vm.UserNameOrEmail) ??
                await _userManager.FindByNameAsync(vm.UserNameOrEmail);
            if (user == null || !await _userManager.CheckPasswordAsync(user, vm.Password))
            {
                ModelState.AddModelError(string.Empty, "Password or Name wrong");
                return View(vm);
            }

            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, true, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Too many attemps");
                return View(vm);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
