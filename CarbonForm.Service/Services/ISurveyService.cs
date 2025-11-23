using CarbonForm.Service.DTOs;

namespace CarbonForm.Service.Services
{
    public interface ISurveyService
    {
        // Varlık validasyonu yapar
        Task<List<string>> ValidateStepAsync<T>(T dto) where T : class;

        Task<Guid> SubmitSurveyAsync(SurveyDto fullSurveyData, string ipAddress);
    }
}