﻿using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class CarModel : BaseEntity<CarModel>
    {
        public Guid BrandId { get; set; }

        public Guid CarCategoryId { get; set; }

        public string ModelName { get; set; } = null!;

        public DateOnly ModelYear { get; set; }

        [EnumDataType(typeof(CarModelStatus))]
        public CarModelStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public virtual Brand Brand { get; set; } = null!;

        public virtual CarCategory CarCategory { get; set; } = null!;

        public virtual ICollection<CustomerCar> CustomerCars { get; set; } = new List<CustomerCar>();

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }

}

