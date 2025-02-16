using Microsoft.AspNetCore.Identity;

namespace GarageManagementAPI.Entities.Models
{
    public class Roles : IdentityRole<Guid>
    {
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
