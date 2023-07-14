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
    public class EFContactDAL : GenericRepository<Contact>, IContactDAL
    {
        public List<Contact> GetContactBySubjectWithTesekkur()
        {
            using var context = new Context();
            var values = context.Contacts.Where(x => x.Subject.Contains("Teşekkür")).ToList();
            return values;
        }
    }
}
