using AutoMapper;
using CarbonForm.Core.Entities;
using CarbonForm.Service.DTOs;

namespace CarbonForm.Service.Mappings
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<UserInfo, UserInfoDto>().ReverseMap();
            CreateMap<Transportation, TransportationDto>().ReverseMap();
            CreateMap<HomeEnergy, HomeEnergyDto>().ReverseMap();
            CreateMap<Consumption, ConsumptionDto>().ReverseMap();
            CreateMap<Survey, SurveyDto>().ReverseMap();
        }
    }
}