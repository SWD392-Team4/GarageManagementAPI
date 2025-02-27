using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ServiceHistoryMappingProfile : Profile
    {
        public ServiceHistoryMappingProfile()
        {
            CreateMap<ServiceHistory, ServiceHistoryDto>();
            CreateMap<ServiceHistoryDtoForCreation, ServiceHistory>();
        }
    }
}
