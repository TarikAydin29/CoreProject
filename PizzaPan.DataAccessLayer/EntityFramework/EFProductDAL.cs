using Microsoft.EntityFrameworkCore;
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
    public class EFProductDAL : GenericRepository<Product>, IProductDAL
    {
        public List<Product> GetProductsWithCategory()
        {
            using var context = new Context();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }
    }
}
