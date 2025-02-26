using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ApiControllerBase
    {
        public AppointmentController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments([FromQuery] AppointmentParameters appointmentParameters)
        {
            var result = await _service.AppointmentService.GetAppointmentsAsync(appointmentParameters, false);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
