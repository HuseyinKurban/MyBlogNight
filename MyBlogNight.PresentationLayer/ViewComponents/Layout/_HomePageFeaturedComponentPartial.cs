using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.ViewComponents.Layout
{
    public class _HomePageFeaturedComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _HomePageFeaturedComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values= _articleService.TLastArticle();
            return View(values);
        }
    }
}
