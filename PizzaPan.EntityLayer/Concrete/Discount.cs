using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPan.EntityLayer.Concrete
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string DiscountCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int UseCount { get; set; }
    }
}
