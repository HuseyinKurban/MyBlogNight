using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogNight.EntityLayer.Concrete;
using MyBlogNight.PresentationLayer.Models;

namespace MyBlogNight.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        // Yapıcı (Constructor) metot - bizim yerimize `UserManager<AppUser>` nesnesinin oluşturulmasını sağlıyor.
        public RegisterController(UserManager<AppUser> userManager)
        {

            //Bu nesne, kullanıcı yönetimi (ekleme, silme, doğrulama vb.) işlemleri için kullanılıyor.
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //asenkron yapı tanımlanması
        //asenkron= aynı anda birden fazla işlem yapılması 
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Email = model.Email,
                Surname = model.Surname,
                UserName = model.Username,
                ImageUrl = "Test"
            };
            // _userManager kullanarak verilen kullanıcıyı (appUser) ve şifresini (model.Password) sisteme kaydetmeye çalışır. Şifreyi hashleyerek kaydetme yapar
            var result = await _userManager.CreateAsync(appUser, model.Password);

            //giriş başarılıysa logine gönder
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);

                }
            }
            return View();
        }

    }
}
