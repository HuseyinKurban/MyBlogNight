using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using X.PagedList.Extensions;
using X.PagedList;
using MyBlogNight.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace MyBlogNight.PresentationLayer.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IArticleService _articleService;

        public HomePageController(IArticleService articleService)
        {
            _articleService = articleService;


        }

        public IActionResult Index(int page = 1)
        {

            var values = _articleService.TArticleListWithCategoryAndAppUser().ToPagedList(page, 3);
            return View(values);
        }


    }
}

