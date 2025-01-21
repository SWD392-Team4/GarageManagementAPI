using GarageManagementAPI.Shared.DataTransferObjects.User;
using Microsoft.AspNetCore.Identity;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
    }
}
