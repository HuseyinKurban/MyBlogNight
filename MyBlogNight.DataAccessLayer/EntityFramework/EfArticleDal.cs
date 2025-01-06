using Microsoft.EntityFrameworkCore;
using MyBlogNight.DataAccessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Context;
using MyBlogNight.DataAccessLayer.Repositories;
using MyBlogNight.EntityLayer.Concrete;
using MyBlogNight.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        private readonly BlogContext context;

        public EfArticleDal(BlogContext contexts) : base(contexts)
        {
            context = contexts;
        }

        public List<CategoryArticleCountViewModel> ArticleCategoryCount()
        {
            return context.Articles
               .GroupBy(a => new { a.CategoryId, a.Category.CategoryName })
               .Select(g => new CategoryArticleCountViewModel
               {
                   CategoryId = g.Key.CategoryId,
                   CategoryName = g.Key.CategoryName,
                   ArticleCount = g.Count()
               })
               .OrderByDescending(x => x.ArticleCount)
               .ToList();
        }

        public List<Article> ArticleListWithCategory()
        {

            var values = context.Articles.Include(x => x.Category).ToList();
            return values;

        }

        public List<Article> ArticleListWithCategoryAndAppUser()
        {

            var values = context.Articles.Include(x => x.Category).Include(y => y.AppUser).ToList();
            return values;
        }

        public Article ArticleListWithCategoryAndAppUserByArticleId(int id)
        {

            var values = context.Articles.Where(x => x.ArticleId == id).Include(y => y.Category).Include(z => z.AppUser).FirstOrDefault();
            return values;
        }

        public void ArticleViewCountIncrease(int id)
        {

            var updatedValue = context.Articles.Find(id);
            updatedValue.ArticleViewCount += 1;
            context.SaveChanges();
        }

        public List<Article> GetArticlesByAppUserId(int id)
        {

            var values = context.Articles.Where(x => x.AppUserId == id).ToList();
            return values;
        }

        public Article LastArticle()
        {
            var values = context.Articles.OrderByDescending(x => x.ArticleId).FirstOrDefault();
            return values;
        }

        public List<Article> PopularCategoryArticlesViewCount()
        {

            var values = context.Articles.OrderByDescending(x => x.ArticleViewCount).Take(3).ToList();
            return values;
        }
    }
}
