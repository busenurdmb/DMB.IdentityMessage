using DMB.IdentityMessage.BusinessLayer.Dto;
using DMB.IdentityMessage.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMB.IdentityMessage.BusinessLayer.Validation.Register
{
    public class CreateRegisterValidatior : AbstractValidator<RegisterViewDto>
    {
        public CreateRegisterValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ad alanıen az 5 karakter geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı alanı boş geçilemez")
                                    .Matches(@"^[^\u00c0-\u017F]+$").WithMessage("Kullanıcı Adı Türkçe karakter içermemelidir")
                                    .MaximumLength(20).WithMessage("Lütfen en fazla 20 karatker girişi yapın")
                                    .MinimumLength(5).WithMessage("Lütfen en az 5 karatker girişi yapın");
            RuleFor(x => x.Password)
                        .NotEmpty().WithMessage("Şifre alanı boş geçilemez")
                        .MinimumLength(6).WithMessage("Şifre alanı en az 6 karakter olmalıdır")
                        .Matches("[A-Z]").WithMessage("Şifre en az 1 büyük harf içermelidir")
                        .Matches("[a-z]").WithMessage("Şifre en az 1 küçük harf içermelidir")
                        .Matches("[0-9]").WithMessage("Şifre rakam içermelidir")
                        .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az 1 özel karakter içermelidir");
        }
    }
}
