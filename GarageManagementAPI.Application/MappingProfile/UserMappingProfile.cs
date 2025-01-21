using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
