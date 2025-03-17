using AutoMapper;

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class AppoitnmentReplacementPartProfile : Profile
    {
        public AppoitnmentReplacementPartProfile()
        {
            CreateMap<AppointmentReplacementPart, AppointmentReplacementPartDto>()
                .ForMember(dest => dest.ProductName, opts =>
                {
                    opts.PreCondition(src => src.ProductHistory != null && src.ProductHistory.Product != null);
                    opts.MapFrom(src => src.ProductHistory.Product.ProductName);
                }).ForMember(dest => dest.ImageLink, opts =>
                {
                    opts.PreCondition(src => src.ProductHistory != null && src.ProductHistory.Product != null && src.ProductHistory.Product.ProductImages != null && src.ProductHistory.Product.ProductImages.Any());
                    opts.MapFrom(src => src.ProductHistory.Product.ProductImages.Select(e => e.ImageLink).ToList());
                }).ForMember(dest => dest.ProductPrice, opts =>
                {
                    opts.PreCondition(src => src.ProductHistory != null);
                    opts.MapFrom(src => src.ProductHistory.ProductPrice);
                }).ForMember(dest => dest.ProductId, opts =>
                {
                    opts.PreCondition(src => src.ProductHistory != null);
                    opts.MapFrom(src => src.ProductHistory.ProductId);
                });
        }
    }
}
