using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarbonForm.Common.Enums
{
    public enum AgeRange
    {
        [Display(Name = "18 Arası 29")]
        [Description("18 Arası 29")]
        Between18and29 = 0,
        [Display(Name = "30 Arası 45")]
        [Description("30 Arası 45")]
        Between30and45 = 1,
        [Display(Name = "46 Üstü")]
        [Description("46 Üstü")]
        Plus46 = 2,
    }
}
