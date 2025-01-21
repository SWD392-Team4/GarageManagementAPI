using Microsoft.AspNetCore.Identity;

namespace GarageManagementAPI.Entities.Models
{
    public class User : IdentityUser
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }
    }
}
