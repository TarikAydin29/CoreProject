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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDAL _testimonialDAL;

        public TestimonialManager(ITestimonialDAL testimonialDAL)
        {
            _testimonialDAL = testimonialDAL;
        }
        public void TDelete(Testimonial t)
        {
            _testimonialDAL.Delete(t);
        }

        public Testimonial TGetByID(int id)
        {
            return _testimonialDAL.GetByID(id);
        }

        public List<Testimonial> TGetList()
        {
            return _testimonialDAL.GetList();
        }

        public void TInsert(Testimonial t)
        {
            _testimonialDAL.Insert(t);
        }

        public void TUpdate(Testimonial t)
        {
            _testimonialDAL.Update(t);
        }
    }
}
