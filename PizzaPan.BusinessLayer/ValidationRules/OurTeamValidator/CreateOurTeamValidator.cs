using FluentValidation;
using PizzaPan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPan.BusinessLayer.ValidationRules.OurTeamValidator
{
    public class CreateOurTeamValidator : AbstractValidator<OurTeam>
    {
        public CreateOurTeamValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Olamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez.");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Giriniz.");
            RuleFor(x => x.Title).MaximumLength(33).WithMessage("Lütfen En Fazla 30 Karakter Giriniz.");
        }
    }
}
