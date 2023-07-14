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
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDAL discountDAL;

        public DiscountManager(IDiscountDAL discountDAL)
        {
            this.discountDAL = discountDAL;
        }       

        public void TDelete(Discount t)
        {
            discountDAL.Delete(t);
        }

        public Discount TGetByID(int id)
        {
            return discountDAL.GetByID(id);
        }

        public List<Discount> TGetList()
        {
          return  discountDAL.GetList();
        }

        public void TInsert(Discount t)
        {
            discountDAL.Insert(t);
        }

        public void TUpdate(Discount t)
        {
            discountDAL.Update(t);
        }
    }
}
