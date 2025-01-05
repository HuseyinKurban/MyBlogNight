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

        public _HomePageCategoryListComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public IViewComponentResult Invoke()
        {

            var values = _categoryService.TGetAll();
            return View(values);
        }
    }
}
