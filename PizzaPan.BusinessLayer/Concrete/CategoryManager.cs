using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.DataAccessLayer.Abstract;
using PizzaPan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPan.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }
        public void TDelete(Category t)
        {
            _categoryDAL.Delete(t);
        }

        public Category TGetByID(int id)
        {
           return _categoryDAL.GetByID(id);
        }

        public List<Category> TGetList()
        {
            return _categoryDAL.GetList();
        }

        public void TInsert(Category t)
        {
            _categoryDAL.Insert(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDAL.Update(t);
        }
    }
}
