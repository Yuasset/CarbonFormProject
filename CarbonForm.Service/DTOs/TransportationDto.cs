using CarbonForm.Common.Enums;

namespace CarbonForm.Service.DTOs
{
    // Ulaşım Alışkanlıkları
    public class TransportationDto
    {
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
    }
}