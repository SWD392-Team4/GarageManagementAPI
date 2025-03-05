using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.PackageFeedBack;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class PackageFeedBackMappingProfile : Profile
    {
        public PackageFeedBackMappingProfile()
        {
            CreateMap<PackageFeedBack, PackageFeedBackDto>()
                .ForMember(dest => dest.CustomerFullName, opts =>
            {
                opts.PreCondition(src => src.Customer != null);
                opts.MapFrom(src => string.Join(' ', src.Customer.FirstName, src.Customer.LastName));
            });

            CreateMap<PackageFeedBackDtoForCreation, PackageFeedBack>();
            CreateMap<PackageFeedBackDtoForUpdate, PackageFeedBack>();
        }
    }
}
