using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarbonForm.Common.Enums
{
    public enum EatingOutFrequency
    {
        [Display(Name = "Nadiren / Hiç")]
        [Description("Nadiren / Hiç")]
        Rarely = 0,
        [Display(Name = "Haftada 1 kez")]
        [Description("Haftada 1 kez")]
        OnceAWeek = 1,
        [Display(Name = "Haftada 2-4 kez")]
        [Description("Haftada 2-4 kez")]
        TwoToFourTimes = 2,
        [Display(Name = "Haftada 5 ve üzeri")]
        [Description("Haftada 5 ve üzeri")]
        FiveOrMore = 3
    }
}
