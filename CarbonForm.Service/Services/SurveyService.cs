using AutoMapper;
using CarbonForm.Core.Entities;
using CarbonForm.Data.Interfaces;
using CarbonForm.Service.DTOs;
using FluentValidation;

namespace CarbonForm.Service.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IServiceProvider serviceProvider; // Validatorları dinamik çağırmak için

        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper, IServiceProvider serviceProvider)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Her adım için dinamik olarak doğrulama yapar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<List<string>> ValidateStepAsync<T>(T dto) where T : class
        {
            // İlgili DTO için uygun Validator'ı bul
            var validator = serviceProvider.GetService(typeof(IValidator<T>)) as IValidator<T>;

            if (validator == null)
            {
                return new List<string>();
            }

            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            return new List<string>(); // Hata yok, boş liste
        }

        /// <summary>
        /// Anket verilerini alır, ilgili entity'lere dönüştürür ve veritabanına kaydeder.
        /// </summary>
        /// <param name="fullSurveyData"></param>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public async Task<Guid> SubmitSurveyAsync(SurveyDto fullSurveyData, string ipAddress)
        {
            // 1. DTO -> Entity Dönüşümü
            var survey = new Survey
            {
                CreatedDate = DateTime.Now,
                UserIpAddress = ipAddress,
                CurrentStage = Common.Enums.SurveyStage.Completed,
                IsCompleted = true
            };

            survey.UserInfo = mapper.Map<UserInfo>(fullSurveyData.UserInfo);
            survey.Transportation = mapper.Map<Transportation>(fullSurveyData.Transportation);
            survey.HomeEnergy = mapper.Map<HomeEnergy>(fullSurveyData.HomeEnergy);
            survey.Consumption = mapper.Map<Consumption>(fullSurveyData.Consumption);

            // 2. Transaction ile Kayıt (UnitOfWork)
            var surveyRepo = unitOfWork.GetRepository<Survey>();
            await surveyRepo.AddAsync(survey);

            await unitOfWork.CommitAsync();

            return survey.Id;
        }
    }
}