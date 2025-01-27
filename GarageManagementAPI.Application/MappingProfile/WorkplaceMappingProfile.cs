using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class WorkplaceMappingProfile : Profile
    {
        public WorkplaceMappingProfile()
        {
            CreateMap<Workplace, WorkplaceDto>()
                .ForMember(c => c.FullAddress,
                        opt => opt.MapFrom(x => string.Join(", ", x.Address.Trim(), x.Ward.Trim(), x.District.Trim(), x.Province.Trim()).Trim()));
            CreateMap<WorkplaceDtoForCreation, Workplace>();
            CreateMap<WorkplaceDtoForUpdate, Workplace>().ReverseMap();
        }
    }
}
