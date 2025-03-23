using AutoMapper;

using GarageManagementAPI.Shared.DataTransferObjects.ReplacementPart;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ReplacementPartMappingProfile : Profile
    {
        public ReplacementPartMappingProfile()
        {
            CreateMap<Entities.Models.ReplacementPart, ReplacementPartDto>()
                .ForMember(dest => dest.ProductHistory, opts =>
                {
                    opts.PreCondition(src => src.ProductHistory != null);
                    opts.MapFrom(src => src.ProductHistory);
                })
                .ForMember(dest => dest.Product, opts =>
                {
                    opts.PreCondition(src => src.ProductHistory != null && src.ProductHistory.Product != null);
                    opts.MapFrom(src => src.ProductHistory.Product);
                }).ForMember(dest => dest.TotalPrice, opts =>
                {
                    opts.PreCondition(src => src.ProductHistory != null);
                    opts.MapFrom(src => src.Quantity * src.ProductHistory.ProductPrice);
                });
        }
    }
}
