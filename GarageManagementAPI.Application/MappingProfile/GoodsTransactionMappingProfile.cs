using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsTransaction;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class GoodsTransactionMappingProfile : Profile
    {
        public GoodsTransactionMappingProfile()
        {
            CreateMap<GoodsTransaction, GoodsTransactionDto>();
            CreateMap<GoodsTransactionDtoForCreation, GoodsTransaction>();
            CreateMap<GoodsTransactionDtoForManipulation, GoodsTransaction>();
        }
    }
}
