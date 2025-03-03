using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ServiceFeebackMappingProfile : Profile
    {
        public ServiceFeebackMappingProfile()
        {
            CreateMap<ServiceFeedBack, ServiceFeedBackDto>();
            CreateMap<ServiceFeedbackDtoForCreation, ServiceFeedBack>();
            CreateMap<ServiceFeedBackDtoForUpdate, ServiceFeedBack>().ReverseMap();
            CreateMap<ServiceFeedBackDtoForManipulation, ServiceFeedBack>();
        }
    }
}
