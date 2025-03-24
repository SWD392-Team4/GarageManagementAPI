using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.DataTransferObjects.Dashboard
{
    public class ProductAtGarageRevenueDto
    {
        public int Month { get; set; }
        public decimal Prices{ get; set; }
    }
}
