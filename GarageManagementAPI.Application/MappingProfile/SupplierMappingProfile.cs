using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Supplier;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class SupplierMappingProfile : Profile
    {
        public SupplierMappingProfile()
        {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDtoForCreation, Supplier>();
            CreateMap<SupplierDtoForUpdate, Supplier>().ReverseMap();
            CreateMap<SupplierDtoForManipulation, Supplier>();
        }
    }
}
