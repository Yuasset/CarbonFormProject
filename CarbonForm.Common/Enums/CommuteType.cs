using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarbonForm.Common.Enums
{
    public enum CommuteType
    {
        [Display(Name = "Şahsi Araba")]
        [Description("Şahsi Araba")]
        Car = 0,
        [Display(Name = "Otobüs / Servis")]
        [Description("Otobüs / Servis")]
        Bus = 1,
        [Display(Name = "Metro / Tramvay")]
        [Description("Metro / Tramvay")]
        Metro = 2,
        [Display(Name = "Yürüyerek / Bisiklet")]
        [Description("Yürüyerek / Bisiklet")]
        Walk = 3,
    }
}
