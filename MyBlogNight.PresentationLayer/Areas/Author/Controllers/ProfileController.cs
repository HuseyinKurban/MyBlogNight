using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogNight.EntityLayer.Concrete;
using MyBlogNight.PresentationLayer.Areas.Author.Models;

namespace MyBlogNight.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;



        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> EditMyProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Surname = values.Surname;
            model.Name = values.Name;
            model.Username = values.UserName;
            model.Email = values.Email;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMyProfile(UserEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name= model.Name;
            user.Surname= model.Surname;
            user.Email= model.Email;
            user.UserName=model.Username;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");

            }
            return View();
           
        }

        public async Task<IActionResult>LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
