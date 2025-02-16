using GarageManagementAPI.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/garages")]
    [ApiController]
    public class GarageController : ControllerBase
    {
        private readonly IServiceManager _service;

        public GarageController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetGarages()
        {
            var garages = _service.GarageService.GetAllGarages(false);
            return Ok(garages);
        }
    }
}
