﻿using GarageManagementAPI.Shared.CustomAttribute;

namespace GarageManagementAPI.Entities.Models
{
    public class Garage : BaseEntity<Garage>
    {
        public required string Name { get; set; }

        public required string Address { get; set; }

        public required string City { get; set; }

        public required string PhoneNumber { get; set; }

        [ExcludeFromProjection]
        [ChildObject]
        public ICollection<Employee>? Employees { get; set; }
    }
}
