using CarbonForm.Service.DTOs;
using CarbonForm.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarbonForm.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISurveyService surveyService;

        public HomeController(ISurveyService surveyService)
        {
            this.surveyService = surveyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Javascript ile kontrol edilecek SessionStroe üzerinden adým adým ilerleme saðlanacak
        public IActionResult Step1_UserInfo() => View();
        public IActionResult Step2_Transportation() => View();
        public IActionResult Step3_HomeEnergy() => View();
        public IActionResult Step4_Consumption() => View();
        public IActionResult Step5_Result() => View();

        [HttpPost]
        public async Task<IActionResult> ValidateStep1([FromBody] UserInfoDto dto)
        {
            var errors = await surveyService.ValidateStepAsync(dto);
            if (errors.Any())
            {
                return BadRequest(errors);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ValidateStep2([FromBody] TransportationDto dto)
        {
            var errors = await surveyService.ValidateStepAsync(dto);
            if (errors.Any())
            {
                return BadRequest(errors);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ValidateStep3([FromBody] HomeEnergyDto dto)
        {
            var errors = await surveyService.ValidateStepAsync(dto);
            if (errors.Any())
            {
                return BadRequest(errors);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ValidateStep4([FromBody] ConsumptionDto dto)
        {
            var errors = await surveyService.ValidateStepAsync(dto);
            if (errors.Any())
            {
                return BadRequest(errors);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitSurvey([FromBody] SurveyDto fullDto)
        {
            try
            {
                var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "0.0.0.0";

                var surveyId = await surveyService.SubmitSurveyAsync(fullDto, ipAddress);
                return Ok(new { SurveyId = surveyId, Message = "Kaydýnýz baþarýyla alýndý." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluþtu: " + ex.Message);
            }
        }
    }
}
