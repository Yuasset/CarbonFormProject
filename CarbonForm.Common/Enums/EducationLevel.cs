using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarbonForm.Common.Enums
{
    public enum EducationLevel
    {
        [Display(Name = "Ön Lisans")]
        [Description("Ön Lisans")]
        OnLisans = 1,
        [Display(Name = "Lisans")]
        [Description("Lisans")]
        Lisans = 2,
        [Display(Name = "Yüksek Lisans")]
        [Description("Yüksek Lisans")]
        YuksekLisans = 3,
        [Display(Name = "Doktora")]
        [Description("Doktora")]
        Doktora = 4
    }
}
