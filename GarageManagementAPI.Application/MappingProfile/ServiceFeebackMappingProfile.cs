using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ServiceFeebackMappingProfile : Profile
    {
        public ServiceFeebackMappingProfile()
        {
            CreateMap<ServiceFeedBack, ServiceFeedBackDto>()
                 .ForMember(dest => dest.CustumerName, otps =>
                 {
                     otps.PreCondition(src => src.Customer != null);
                     otps.MapFrom(src => src.Customer!.FirstName + src.Customer!.LastName);
                 })
                  .ForMember(dest => dest.NameService, otps =>
                  {
                      otps.PreCondition(src => src.Service != null);
                      otps.MapFrom(src => src.Service!.ServiceName);
                  });
            CreateMap<ServiceFeedbackDtoForCreation, ServiceFeedBack>();
            CreateMap<ServiceFeedBackDtoForUpdate, ServiceFeedBack>().ReverseMap();
            CreateMap<ServiceFeedBackDtoForManipulation, ServiceFeedBack>();
        }
    }
}
