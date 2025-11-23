using CarbonForm.Service.DTOs;
using FluentValidation;

namespace CarbonForm.Service.Validations
{
    public class ConsumptionValidator : AbstractValidator<ConsumptionDto>
    {
        public ConsumptionValidator()
        {
            RuleFor(x => x.ClothingExpense)
                .GreaterThanOrEqualTo(0).WithMessage("Harcama tutarı negatif olamaz.");

            RuleFor(x => x.ElectronicsExpense).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CosmeticExpense).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PersonalCareExpense).GreaterThanOrEqualTo(0);

            RuleFor(x => x.EatingOutFrequency)
                .IsInEnum().WithMessage("Lütfen dışarıda yeme sıklığını seçiniz.");

            RuleFor(x => x.MeatConsumptionKg)
                .GreaterThanOrEqualTo(0).WithMessage("Et tüketimi negatif olamaz.");

            RuleFor(x => x.VeggieConsumptionKg)
                .GreaterThanOrEqualTo(0).WithMessage("Sebze tüketimi negatif olamaz.");
        }
    }
}