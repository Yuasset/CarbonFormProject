using CarbonForm.Service.DTOs;
using FluentValidation;

namespace CarbonForm.Service.Validations
{
    public class TransportationValidator : AbstractValidator<TransportationDto>
    {
        public TransportationValidator()
        {
            RuleFor(x => x.CommuteDistanceKm)
                .GreaterThanOrEqualTo(0).WithMessage("Mesafe negatif olamaz.");

            RuleFor(x => x.CommuteType)
                .NotEmpty()
                .When(x => x.CommuteDistanceKm > 0)
                .WithMessage("Eğer mesafe girdiyseniz, lütfen ulaşım şeklini seçiniz.");

            RuleFor(x => x.FlightDomesticCount)
                .GreaterThanOrEqualTo(0).WithMessage("Uçuş sayısı negatif olamaz.");

            RuleFor(x => x.FlightDomesticKm)
                .GreaterThanOrEqualTo(0).WithMessage("Uçuş mesafesi negatif olamaz.");

            RuleFor(x => x.FlightDomesticKm)
                .GreaterThan(0)
                .When(x => x.FlightDomesticCount > 0)
                .WithMessage("Yurtiçi uçuş adedi girdiyseniz, tahmini KM bilgisini de girmelisiniz.");

            RuleFor(x => x.FlightInternationalCount)
                .GreaterThanOrEqualTo(0).WithMessage("Uçuş sayısı negatif olamaz.");

            RuleFor(x => x.FlightInternationalKm)
                .GreaterThan(0)
                .When(x => x.FlightInternationalCount > 0)
                .WithMessage("Yurtdışı uçuş adedi girdiyseniz, tahmini KM bilgisini de girmelisiniz.");

            RuleFor(x => x.CarTravelKm).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PublicTransportTravelKm).GreaterThanOrEqualTo(0);
        }
    }
}