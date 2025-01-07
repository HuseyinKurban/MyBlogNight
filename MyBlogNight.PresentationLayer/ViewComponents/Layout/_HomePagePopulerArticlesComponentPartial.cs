using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.ViewComponents.Layout
{
    public class _HomePagePopulerArticlesComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _HomePagePopulerArticlesComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TPopularArticles();
            return View(values);
        }

    }
}
