using GarageManagementAPI.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductImage
{
    public record class ProductImageDtoForManipulation
    {
        public Guid ProductId { get; set; }

        public string Link { get; set; } = null!;
    }
}
