using ECommerceWithMVC.Models.ViewModel;
using FluentValidation;

namespace ECommerceWithMVC.Models.Validators
{
    public class KullaniciViewValidator:AbstractValidator<KullaniciViewModel>
    {

        public KullaniciViewValidator()
        {
            RuleFor(p => p.Email).NotNull().WithMessage("Email Adresi Boş Bırakılamaz.").EmailAddress().WithMessage("Lütfen Geçerli Email Adresi Giriniz");
            RuleFor(p => p.Sifre1).NotNull().WithMessage("Şifre Girmediniz").Length(5,100).WithMessage("Lütfen En düşük 6 En Yüksek 10 Haneli Bir Şifre Oluşturunuz");
        }
    }
}
