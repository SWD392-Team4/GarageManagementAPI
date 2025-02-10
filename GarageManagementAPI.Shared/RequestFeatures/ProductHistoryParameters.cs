using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class ProductHistoryParameters : RequestParameters
    {
        public ProductHistoryParameters() => OrderBy = "ProductPrice";

        public decimal ProductPrice { get; set; }

        [EnumDataType(typeof(ProductHistoryStatus))]
        public ProductHistoryStatus Status { get; set; }
    }
}
