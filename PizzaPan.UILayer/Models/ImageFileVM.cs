using Microsoft.AspNetCore.Http;

namespace PizzaPan.UILayer.Models
{
    public class ImageFileVM
    {
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
