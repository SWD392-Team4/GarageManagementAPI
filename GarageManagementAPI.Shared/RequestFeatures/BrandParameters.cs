using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class BrandParameters : RequestParameters
    {
        public BrandParameters() => OrderBy = "name";
        public string BrandName { get; set; } = null!;

    }
}

