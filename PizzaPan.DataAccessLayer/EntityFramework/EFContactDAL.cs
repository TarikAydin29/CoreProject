using PizzaPan.DataAccessLayer.Abstract;
using PizzaPan.DataAccessLayer.Repositories;
using PizzaPan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPan.DataAccessLayer.EntityFramework
{
    internal class EFContactDAL : GenericRepository<Contact>, IContactDAL
    {
    }
}
