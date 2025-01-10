﻿using MyBlogNight.DataAccessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Context;
using MyBlogNight.DataAccessLayer.Repositories;
using MyBlogNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.EntityFramework
{
    public class EfNewsLetterDal : GenericRepository<NewsLetter>, INewsLetterDal
    {
        public EfNewsLetterDal(BlogContext context) : base(context)
        {
        }
    }
}