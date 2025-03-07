using GarageManagementAPI.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/pacakges/{packageId:guid}/conditions")]
    [ApiController]
    public class PackageConditionController : ApiControllerBase
    {
        public PackageConditionController(IServiceManager service) : base(service)
        {
        }
    }
}
