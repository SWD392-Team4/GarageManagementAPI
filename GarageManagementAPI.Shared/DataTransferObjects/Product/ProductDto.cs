using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    public class ProductDto
    {
        string ProductName { get; set; }
        string ProductBarcode { get; set; }
        string ProductDescription { get; set; }
        public Guid BrandId { get; set; }
    }
}
