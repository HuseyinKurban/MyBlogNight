using FluentValidation;
using MyBlogNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.BusinessLayer.ValidationRules.CreateArticleValidator
{
    public class CreateArticleValidator : AbstractValidator<Article>
    {
        public CreateArticleValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlığın adını boş bırakmayınız.");
        }
    }
}
