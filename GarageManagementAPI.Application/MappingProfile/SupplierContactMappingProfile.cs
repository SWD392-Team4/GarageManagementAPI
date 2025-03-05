using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.SupplierContact;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class SupplierContactMappingProfile : Profile
    {
        public SupplierContactMappingProfile()
        {
            CreateMap<SupplierContact, SupplierContactDto>();
            CreateMap<SupplierContactDtoForCreation, SupplierContact>();
            CreateMap<SupplierContactDtoForUpdate, SupplierContact>().ReverseMap();
            CreateMap<SupplierContactDtoForManipulation, SupplierContact>();
        }
    }
}
