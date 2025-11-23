using CarbonForm.Common.Enums;

namespace CarbonForm.Service.DTOs
{
    // Ev Enerjisi ve Atık Yönetimi Alışkanlıkları
    public class HomeEnergyDto
    {
        public decimal NaturalGasBillAmount { get; set; }
        public decimal NaturalGasM3 { get; set; }

        public decimal WaterBillAmount { get; set; }
        public decimal WaterM3 { get; set; }

        public decimal ElectricityBillAmount { get; set; }
        public decimal ElectricityKwh { get; set; }

        public decimal LpgM3 { get; set; }

        public bool HasAirConditioner { get; set; }
        public AirConditionerType AirConditionerType { get; set; }
        public int AirConditionerUseDays { get; set; }

        public decimal SolidWasteKg { get; set; }
        public int CarWashCount { get; set; }
    }
}