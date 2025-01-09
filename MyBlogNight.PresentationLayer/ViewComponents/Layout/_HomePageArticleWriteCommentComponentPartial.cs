using Microsoft.AspNetCore.Mvc;
using MyBlogNight.EntityLayer.Concrete;

namespace MyBlogNight.PresentationLayer.ViewComponents.Layout
{
    public class _HomePageArticleWriteCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke(int articleId)
        {
            ViewData["ArticleId"] = articleId;
            return View(new Comment());
        }
    }
}
