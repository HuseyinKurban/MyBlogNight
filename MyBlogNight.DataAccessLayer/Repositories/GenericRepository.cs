using MyBlogNight.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.Repositories
{
    public class GenericRepository<T>:IGenericDal<T> where T : class
    {

    }
}
