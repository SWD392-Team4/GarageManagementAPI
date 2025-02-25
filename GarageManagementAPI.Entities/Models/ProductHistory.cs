﻿using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class ProductHistory : BaseEntity<ProductHistory>
    {
        public Guid ProductId { get; set; }

        public decimal ProductPrice { get; set; }

        [EnumDataType(typeof(ProductHistoryStatus))]
        public ProductHistoryStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual ICollection<AppointmentReplacementPart> AppointmentReplacementParts { get; set; } = new List<AppointmentReplacementPart>();

        public virtual ICollection<InvoiceSellProduct> InvoiceSellProducts { get; set; } = new List<InvoiceSellProduct>();

        public virtual Product Product { get; set; } = null!;

        public virtual ICollection<ReplacementPart> ReplacementParts { get; set; } = new List<ReplacementPart>();
    }

}

