using CarbonForm.Common.Enums;

namespace CarbonForm.Service.DTOs
{
    // Tüketim Alışkanlıkları
    public class ConsumptionDto
    {
        public decimal ClothingExpense { get; set; }
        public decimal CosmeticExpense { get; set; }
        public decimal PersonalCareExpense { get; set; }
        public decimal ElectronicsExpense { get; set; }
        public int LocalProductPreferenceScore { get; set; }

        public EatingOutFrequency EatingOutFrequency { get; set; }
        public decimal MeatConsumptionKg { get; set; }
        public decimal VeggieConsumptionKg { get; set; }
    }
}