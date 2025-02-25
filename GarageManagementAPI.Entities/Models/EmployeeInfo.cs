﻿namespace GarageManagementAPI.Entities.Models
{
    public partial class EmployeeInfo : BaseEntity<EmployeeInfo>
    {
        public Guid? WorkplaceId { get; set; }

        public string CitizenIdentification { get; set; } = null!;

        public bool Gender { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual Workplace Workplace { get; set; } = null!;
    }

}

