using PizzaPan.DataAccessLayer.Abstract;
using PizzaPan.DataAccessLayer.Concrete;
using PizzaPan.DataAccessLayer.Repositories;
using PizzaPan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPan.DataAccessLayer.EntityFramework
{
    public class EFDiscountDAL : GenericRepository<Discount>, IDiscountDAL
    {      
        
    }
}
