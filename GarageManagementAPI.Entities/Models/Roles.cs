using Microsoft.AspNetCore.Identity;

namespace GarageManagementAPI.Entities.Models
{
    public class Roles : IdentityRole<Guid>
    {
        public new Guid Id { get; set; } = Guid.NewGuid();
    }
}
