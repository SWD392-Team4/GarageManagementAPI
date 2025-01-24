using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Entities.Models
{
    public class PackageHistory : BaseEntity<PackageHistory>
    {
        public Guid PackageId { get; set; }

        public Guid CarCategoryId { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }

        public int ValidityPeriod { get; set; } = 1; //su dung duoc bao nhieu ngay

        public int UsageLimit { get; set; } = 1;

        public Package? Package { get; set; }

        public CarCategory? CarCategory { get; set; }

        public ICollection<PackageDetailHistory>? PackageDetailHistories { get; set; }

        public ICollection<PackageProvided>? PackageProvideds { get; set; }
    }
}