using CarbonForm.Common.Enums;

namespace CarbonForm.Core.Entities
{
    // Kullanıcı Bilgileri
    public class UserInfo : BaseEntity
    {
        public Guid SurveyId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public AgeRange AgeRange { get; set; }

        public EducationLevel EducationLevel { get; set; }

        public bool IsNgoMember { get; set; }

        public bool HasAttendedGreenFair { get; set; }
        public string? GreenFairName { get; set; }

        public bool DoRecycle { get; set; }
        public bool DoCompost { get; set; }

        public bool HasPlantedTree { get; set; }
        public int TreeCount { get; set; }

        public virtual Survey Survey { get; set; } = null!;
    }
}
