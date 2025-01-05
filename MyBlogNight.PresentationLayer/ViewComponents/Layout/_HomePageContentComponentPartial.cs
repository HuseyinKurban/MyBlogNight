using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.ViewComponents.Layout
{
    public class _HomePageContentComponentPartial: ViewComponent
    {
        private readonly IArticleService _articleService;

        public _HomePageContentComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {

            var values = _articleService.TArticleListWithCategoryAndAppUser();
            return View(values);
        }
    }
}
