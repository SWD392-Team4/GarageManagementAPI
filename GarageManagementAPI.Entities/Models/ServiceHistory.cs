using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Entities.Models
{
    public class ServiceHistory : BaseEntity<ServiceHistory>
    {
        public Guid ServiceId { get; set; }

        public Guid CarCategoryId { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }

        public Service? Service { get; set; }

        public CarCategory? CarCategory { get; set; }

        public ICollection<AppointmentDetail>? AppointmentDetails { get; set; }
    }
}