using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Context;
using MyBlogNight.EntityLayer.Concrete;
using MyBlogNight.PresentationLayer.Models;

namespace MyBlogNight.PresentationLayer.ViewComponents.Layout
{
    public class _HomePageCategoryListComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;


        public _HomePageCategoryListComponentPartial(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TArticleCategoryCount();
            //var values = _categoryService.TGetAll();
            return View(values);
        }
    }
}
