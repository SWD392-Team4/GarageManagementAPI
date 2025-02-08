using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.RequestFeatures
{
 
        public class ProductParameters : RequestParameters
        {
            public ProductParameters() => OrderBy = "ProductName";

            public string? ProductName { get; set; }

            public string? ProductBarcode { get; set; }

    }
}
