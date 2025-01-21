using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace GarageManagementAPI.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(
            IMapper mapper, 
            UserManager<User> userManager, 
            IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);

            var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, userForRegistrationDto.Role.ToString());

            return result;
        }
    }
}
