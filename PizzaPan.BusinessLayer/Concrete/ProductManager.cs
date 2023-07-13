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
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        public void TDelete(Product t)
        {
            _productDAL.Delete(t);
        }

        public Product TGetByID(int id)
        {
            return _productDAL.GetByID(id);
        }

        public List<Product> TGetList()
        {
            return _productDAL.GetList();
        }

        public void TInsert(Product t)
        {
            _productDAL.Insert(t);
        }

        public void TUpdate(Product t)
        {
            _productDAL.Update(t);
        }
    }
}
