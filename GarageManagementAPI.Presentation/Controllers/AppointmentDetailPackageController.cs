using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetailPackage;

using Microsoft.AspNetCore.Mvc;



namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/workplaces/{garageId}/appointments/{appointmentId:guid}/packages")]
    [ApiController]
    public class AppointmentDetailPackageController : ApiControllerBase
    {
        public AppointmentDetailPackageController(IServiceManager service) : base(service)
        {
        }

        [HttpPut("{appointmentDetailPackgeId}")]
        public async Task<IActionResult> UpdateAppointmentDetailPakcage(Guid garageId, Guid appointmentId, Guid appointmentDetailPackgeId, [FromBody] AppointmentDetailPackageDtoForUpdate appointmentDetailPackageDtoForUpdate)
        {
            var result = await _service.AppointmentDetailPackageService.UpdateAppointmentDetailPackage(garageId, appointmentId, appointmentDetailPackgeId, appointmentDetailPackageDtoForUpdate);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }

}
