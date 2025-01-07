using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.ViewComponents.Layout
{
    public class _HomePageLastThreeArticleComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _HomePageLastThreeArticleComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TLastThreeArticle();
            return View(values);
        }
    }
}
