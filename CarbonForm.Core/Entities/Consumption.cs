using CarbonForm.Common.Enums;

namespace CarbonForm.Core.Entities
{
    // Tüketim Alışkanlıkları
    public class Consumption : BaseEntity
    {
        public Guid SurveyId { get; set; }

        public decimal ClothingExpense { get; set; }
        public decimal CosmeticExpense { get; set; }
        public decimal PersonalCareExpense { get; set; }
        public decimal ElectronicsExpense { get; set; }
        public int LocalProductPreferenceScore { get; set; }

        public EatingOutFrequency EatingOutFrequency { get; set; }
        public decimal MeatConsumptionKg { get; set; }
        public decimal VeggieConsumptionKg { get; set; }

        public virtual Survey Survey { get; set; } = null!;
    }
}
