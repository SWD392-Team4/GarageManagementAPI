﻿using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class CarPartParameters : RequestParameters
    {
        public CarPartParameters() => OrderBy = "PartName";
        public string CarPartName { get; set; } = null!;
        public string CarPartCategory { get; set; } = null!;
        [EnumDataType(typeof(CarPartStatus))]
        public CarPartStatus? Status { get; set; } = null;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
