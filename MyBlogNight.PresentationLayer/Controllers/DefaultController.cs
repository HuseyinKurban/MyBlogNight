using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {

        public IActionResult Index()
        {
           
            return View();
        }
    }
}
