using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductAtWarehouseMappingProfile : Profile
    {
        public ProductAtWarehouseMappingProfile() {
            CreateMap<ProductAtWarehouse, ProductAtWarehouseDto>();
            CreateMap<ProductAtWarehouseDtoForManipulation, ProductAtWarehouse>();
            CreateMap<ProductAtWarehouseDtoForCreation, ProductAtWarehouse>();
            CreateMap<ProductAtWarehouseDtoForUpdate, ProductAtWarehouse>();
        }
    }
}
