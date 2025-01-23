using Microsoft.AspNetCore.Identity;

namespace GarageManagementAPI.Entities.Models
{
    public class User : IdentityUser
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
