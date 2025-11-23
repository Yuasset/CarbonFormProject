using CarbonForm.Service.DTOs;
using FluentValidation;

namespace CarbonForm.Service.Validations
{
    public class HomeEnergyValidator : AbstractValidator<HomeEnergyDto>
    {
        public HomeEnergyValidator()
        {
            RuleFor(x => x.NaturalGasBillAmount).GreaterThanOrEqualTo(0).WithMessage("Fatura tutarı negatif olamaz.");
            RuleFor(x => x.NaturalGasM3).GreaterThanOrEqualTo(0);

            RuleFor(x => x.ElectricityBillAmount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.ElectricityKwh).GreaterThanOrEqualTo(0);

            RuleFor(x => x.WaterBillAmount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.WaterM3).GreaterThanOrEqualTo(0);

            RuleFor(x => x.AirConditionerType)
                .IsInEnum()
                .When(x => x.HasAirConditioner)
                .WithMessage("Klima kullanıyorsanız lütfen BTU/Tip seçimi yapınız.");

            RuleFor(x => x.AirConditionerUseDays)
                .GreaterThan(0)
                .When(x => x.HasAirConditioner)
                .WithMessage("Klima kullanıyorsanız yıllık kullanım gün sayısını girmelisiniz.")
                .LessThanOrEqualTo(365).WithMessage("Bir yılda en fazla 365 gün olabilir.");

            RuleFor(x => x.SolidWasteKg).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CarWashCount).GreaterThanOrEqualTo(0);
        }
    }
}