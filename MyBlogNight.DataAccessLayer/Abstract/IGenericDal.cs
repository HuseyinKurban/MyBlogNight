using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.Abstract
{
    // bu t mutlaka sınıf olucak
    public interface IGenericDal<T>where T : class
    {
        //bu 5 method bütün entitylerim için ortak
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);
    }
}
