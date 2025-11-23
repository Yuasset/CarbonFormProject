using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarbonForm.Common.Enums
{
    public enum SurveyStage
    {
        [Display(Name = "Kullanıcı Bilgileri")]
        [Description("Kullanıcı Bilgileri")]
        UserInfo = 1,
        [Display(Name = "Ulaşım")]
        [Description("Ulaşım")]
        Transportation = 2,
        [Display(Name = "Ev Enerjisi")]
        [Description("Ev Enerjisi")]
        HomeEnergy = 3,
        [Display(Name = "Tüketim Alışkanlıkları")]
        [Description("Tüketim Alışkanlıkları")]
        Consumption = 4,
        [Display(Name = "Anket Tamamlandı")]
        [Description("Anket Tamamlandı")]
        Completed = 5
    }
}
