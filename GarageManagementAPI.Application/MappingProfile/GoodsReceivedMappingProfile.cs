using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class GoodsReceivedMappingProfile : Profile
    {
        public GoodsReceivedMappingProfile()
        {
            CreateMap<GoodsReceived, GoodsReceivedDto>()
                 .ForMember(dest => dest.ContactPersonName, opts =>
                 {
                     opts.PreCondition(src => src.SupplierContact != null);
                     opts.MapFrom(src => src.SupplierContact!.ContactPersonName);
                 })
                  .ForMember(dest => dest.WorkPlaceName, opts =>
                  {
                      opts.PreCondition(src => src.Warehouse != null);
                      opts.MapFrom(src => src.Warehouse!.Name);
                  })
                  .ForMember(dest => dest.WarehouseManagereName, opts =>
                  {
                      opts.PreCondition(src => src.CreatedWarehouseManager != null);
                      opts.MapFrom(src => src.CreatedWarehouseManager!.FirstName + " " + src.CreatedWarehouseManager!.LastName);
                  });
                 
            CreateMap<GoodsReceivedDtoForCreation, GoodsReceived>();
            CreateMap<GoodsReceivedDtoForUpdate, GoodsReceived>().ReverseMap();
            CreateMap<GoodsReceivedDtoForManipulation, GoodsReceived>();
        }
    }
}
