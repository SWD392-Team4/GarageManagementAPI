using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public class PackageDetail
    {
        public Guid ServiceId { get; set; }

        public Guid PackageHistoryId { get; set; }
    }

}

