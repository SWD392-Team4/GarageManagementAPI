using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Service
{
    public record class ServiceDtoForManipulation
    {
        public string ServiceName { get; set; } = null!;

        [EnumDataType(typeof(ServiceCategory))]
        public ServiceCategory ServiceCategory { get; set; }

        public decimal ServicePrice { get; set; }

        [EnumDataType(typeof(WorkNature))]
        public WorkNature WorkNature { get; set; }


        [EnumDataType(typeof(ServiceAction))]
        public ServiceAction Action { get; set; }

        public string Description { get; set; } = null!;

        public int EstimatedHours { get; set; }

        public Guid CarPartId { get; set; }

        public Guid CarCategoryId { get; set; }

    }
}
