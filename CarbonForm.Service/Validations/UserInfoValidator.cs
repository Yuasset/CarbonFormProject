using CarbonForm.Service.DTOs;
using FluentValidation;

namespace CarbonForm.Service.Validations
{
    public class UserInfoValidator : AbstractValidator<UserInfoDto>
    {
        public UserInfoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı zorunludur.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı zorunludur.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.EducationLevel).IsInEnum().WithMessage("Lütfen eğitim durumu seçiniz.");

            RuleFor(x => x.GreenFairName)
                .NotEmpty()
                .When(x => x.HasAttendedGreenFair)
                .WithMessage("Lütfen katıldığınız fuarın adını giriniz.");

            RuleFor(x => x.TreeCount)
                .GreaterThan(0)
                .When(x => x.HasPlantedTree)
                .WithMessage("Lütfen diktiğiniz ağaç sayısını giriniz.");
        }
    }
}