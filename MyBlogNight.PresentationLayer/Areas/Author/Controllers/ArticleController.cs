using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;

namespace MyBlogNight.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByAppUserId(userValue.Id);
            return View(values);
        }


        [HttpGet]
        public IActionResult CreateArticle()
        {
            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.v1 = values1;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);

            article.AppUserId = userValue.Id;
            article.CreatedDate = DateTime.Now;
            article.ArticleViewCount = 0;
            _articleService.TInsert(article);
            return RedirectToAction("/Author/Article/Index");
        }

        public IActionResult DeleteArticle(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("/Author/Article/Index");
        }

        [HttpGet]
        public IActionResult UpdateArtilce(int id)
        {
            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.v1 = values1;
            var value = _articleService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateArtilce(Article article)
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            article.AppUserId = userValue.Id;

            _articleService.TUpdate(article);
            return RedirectToAction("/Author/Article/Index");
        }
    }
}
