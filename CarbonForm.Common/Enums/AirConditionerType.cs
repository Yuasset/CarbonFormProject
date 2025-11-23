using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarbonForm.Common.Enums
{
    public enum AirConditionerType
    {
        [Display(Name = "Kullanmıyorum")]
        [Description("Kullanmıyorum")]
        None = 0,
        [Display(Name = "0 - 9.000 BTU")]
        [Description("0 - 9.000 BTU")]
        LowBtu = 1,
        [Display(Name = "9.001 - 12.000 BTU")]
        [Description("9.001 - 12.000 BTU")]
        MidBtu = 2,
        [Display(Name = "12.001 - 18.000 BTU")]
        [Description("12.001 - 18.000 BTU")]
        HighBtu = 3,
        [Display(Name = "18.001 BTU ve Üzeri")]
        [Description("18.001 BTU ve Üzeri")]
        UltraBtu = 4
    }
}
