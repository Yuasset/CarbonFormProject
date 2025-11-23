using CarbonForm.Common.Enums;

namespace CarbonForm.Core.Entities
{
    // Ulaşım Alışkanlıkları
    public class Transportation : BaseEntity
    {
        public Guid SurveyId { get; set; }

        public CommuteType CommuteType { get; set; }
        public int CommuteDistanceKm { get; set; }

        public int FlightDomesticCount { get; set; }
        public int FlightDomesticKm { get; set; }
        public int FlightInternationalCount { get; set; }
        public int FlightInternationalKm { get; set; }

        public int CarTravelCount { get; set; }
        public int CarTravelKm { get; set; }

        public int PublicTransportTravelCount { get; set; }
        public int PublicTransportTravelKm { get; set; }

        public virtual Survey Survey { get; set; } = null!;
    }
}
