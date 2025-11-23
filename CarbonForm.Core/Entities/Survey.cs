using CarbonForm.Common.Enums;

namespace CarbonForm.Core.Entities
{
    // Anketin ana tablosu
    public class Survey : BaseEntity
    {
        public string? UserIpAddress { get; set; }
        public string? UserAgent { get; set; }
        public SurveyStage CurrentStage { get; set; }
        public bool IsCompleted { get; set; }

        // İlişkiler (Navigation Properties)
        public virtual UserInfo? UserInfo { get; set; }
        public virtual Transportation? Transportation { get; set; }
        public virtual HomeEnergy? HomeEnergy { get; set; }
        public virtual Consumption? Consumption { get; set; }
    }
}
