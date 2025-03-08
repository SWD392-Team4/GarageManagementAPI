using GarageManagementAPI.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/pacakges/{packageId:guid}/histories")]
    public class PackageHistoryController : ApiControllerBase
    {
        public PackageHistoryController(IServiceManager service) : base(service)
        {
        }


    }
}
