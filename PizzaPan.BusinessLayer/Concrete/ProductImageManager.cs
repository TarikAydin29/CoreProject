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
    public class ProductImageManager : IProductImageService
    {
        private readonly IProductImageDAL productImageDAL;

        public ProductImageManager(IProductImageDAL productImageDAL)
        {
            this.productImageDAL = productImageDAL;
        }
        public void TDelete(ProductImage t)
        {
            productImageDAL.Delete(t);
        }

        public ProductImage TGetByID(int id)
        {
            return productImageDAL.GetByID(id);
        }

        public List<ProductImage> TGetList()
        {
            return productImageDAL.GetList();
        }

        public void TInsert(ProductImage t)
        {
            productImageDAL.Insert(t);
        }

        public void TUpdate(ProductImage t)
        {
            productImageDAL.Update(t);
        }
    }
}
