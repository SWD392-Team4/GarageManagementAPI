﻿using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opts =>
                {
                    opts.PreCondition(src => src.Roles != null);
                    opts.MapFrom(src => src.Roles.FirstOrDefault()!.Name);
                })
                .ForMember(dest => dest.CitizenIdentification, opt =>
                {
                    opt.PreCondition(src => src.EmployeeInfo != null);
                    opt.MapFrom(src => src.EmployeeInfo!.CitizenIdentification);
                })
                .ForMember(dest => dest.Gender, opt =>
                {
                    opt.PreCondition(src => src.EmployeeInfo != null);
                    opt.MapFrom(src => src.EmployeeInfo!.Gender);
                })
                .ForMember(dest => dest.DateOfBirth, opt =>
                {
                    opt.PreCondition(src => src.EmployeeInfo != null);
                    opt.MapFrom(src => src.EmployeeInfo!.DateOfBirth);
                })
                .ForMember(dest => dest.WorkPlaceId, opt =>
                {
                    opt.PreCondition(src => src.EmployeeInfo != null);
                    opt.MapFrom(src => src.EmployeeInfo!.WorkplaceId);
                })
                .ForMember(dest => dest.UpdatedAt, opt =>
                {
                    opt.MapFrom(src =>
                        src.EmployeeInfo != null && DateTimeOffset.Compare(src.EmployeeInfo.UpdatedAt, src.UpdatedAt) > 0
                            ? src.EmployeeInfo.UpdatedAt
                            : src.UpdatedAt);

                });

            CreateMap<UserForUpdateDto, User>();

            CreateMap<UserForUpdateEmployeeDto, User>()
                .IncludeBase<UserForUpdateDto, User>();
        }
    }
}
