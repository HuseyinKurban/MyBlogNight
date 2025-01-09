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
        private readonly ICommentService _commentService;
        private readonly INewsLetterService _newsletterService;
        private readonly UserManager<AppUser> _userManager;

        public HomePageController(IArticleService articleService, UserManager<AppUser> userManager, ICommentService commentService, INewsLetterService newsletterService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _commentService = commentService;
            _newsletterService = newsletterService;
        }

        public IActionResult Index(int page = 1)
        {

            var values = _articleService.TArticleListWithCategoryAndAppUser().ToPagedList(page, 3);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            comment.AppUserId = user.Id;
            comment.CreatedDate = DateTime.Now;
            comment.Status = true;

            _commentService.TInsert(comment);

            return Redirect($"/Article/ArticleDetail/{comment.ArticleId}");
        }

        [HttpPost]
        public IActionResult AddNewsLatter(NewsLetter newsLetter)
        {
            _newsletterService.TInsert(newsLetter);
            return RedirectToAction("Index");
        }
    }
}

