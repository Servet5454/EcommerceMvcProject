using ECommerceWithMVC.Models.ViewModel;
using FluentValidation;

namespace ECommerceWithMVC.Models.Validators
{
    public class KullaniciVeAdresViewValidator : AbstractValidator<KullaniciVeAdresViewModel>
    {
        public KullaniciVeAdresViewValidator()
        {
            //RuleFor(p => p.Email).NotEmpty().WithMessage("Email Adresi Boş Bırakılamaz").EmailAddress().WithMessage("Lütfen Geçerli Email Adresi Giriniz");
            //RuleFor(p => p.Sifre1).NotEmpty().WithMessage("Şifrenizi Yazmayı Unuttunuz...").Length(5, 10).WithMessage("Lütfen En düşük 5 En Yüksek 10 Haneli Bir Şifre Oluşturunuz");
            RuleFor(p => p.TelNo).NotEmpty().WithMessage("Telefon Numarası Boş Bırakılamaz").Length(11, 11).WithMessage("Lütfen Telefon Numaranızı 11 Haneli Giriniz");
            RuleFor(p => p.Ad).NotEmpty().WithMessage("Lütfen İsim Bilginizi Giriniz");
            RuleFor(p => p.Soyad).NotEmpty().WithMessage("Lütfen Soyisim Bilginizi Giriniz");
            RuleFor(p => p.Adresbasligi).NotEmpty().WithMessage("Adres Başlığı Boş Bırakılamaz");
            RuleFor(p => p.Il).NotEmpty().WithMessage("Sehir Bilgisi Boş Bırakılamaz");
            RuleFor(p => p.Ilce).NotEmpty().WithMessage("İlçe Bilgisi Boş Bırakılamaz");
            RuleFor(p => p.Mahalle).NotEmpty().WithMessage("Mahalle Bilgisi Boş Bırakılamaz");
            RuleFor(p => p.AdresGenel).NotEmpty().WithMessage("Genel Adres Tanımlaması Boş Bırakılamaz");
        }
    }
}
