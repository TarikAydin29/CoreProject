using System.ComponentModel.DataAnnotations;

namespace PizzaPan.UILayer.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Ad alanı boş olamaz.")]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email alanı boş olamaz.")]
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}
