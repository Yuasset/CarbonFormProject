namespace CarbonForm.Service.DTOs
{
    // Anketin ana DTO'su
    public class SurveyDto
    {
        public UserInfoDto UserInfo { get; set; } = new();
        public TransportationDto Transportation { get; set; } = new();
        public HomeEnergyDto HomeEnergy { get; set; } = new();
        public ConsumptionDto Consumption { get; set; } = new();
    }
}