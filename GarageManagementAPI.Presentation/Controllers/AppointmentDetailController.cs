using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;

using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/workplaces/{garageId}/appointments/{appointmentId:guid}/details")]
    [ApiController]
    public class AppointmentDetailController : ApiControllerBase
    {
        public AppointmentDetailController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentDetails(Guid garageId, Guid appointmentId)
        {
            var result = await _service.AppointmentDetailService.GetAppointmentDetailsAsync(garageId, appointmentId);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointmentDetail(Guid garageId, Guid appointmentId, [FromBody] List<AppointmentDetailDtoForCreation> appointmentDetailDtoForCreation)
        {
            var result = await _service.AppointmentDetailService.CreateAppointmentDetails(garageId, appointmentId, appointmentDetailDtoForCreation);
            return result.Map(
                onSuccess: _ => Created(),
                onFailure: ProcessError
                );
        }

        [HttpPut("cancel")]
        public async Task<IActionResult> CancelAppointmentDetail(Guid garageId, Guid appointmentId, [FromBody] AppointmentDetailDtoForCancellation appointmentDetailDtoForCancellation)
        {
            var result = await _service.AppointmentDetailService.CancelAppointmentDetailsAsync(garageId, appointmentId, appointmentDetailDtoForCancellation);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPut("reject")]
        public async Task<IActionResult> RejectAppointmentDetail(Guid garageId, Guid appointmentId, [FromBody] AppointmentDetailDtoForCancellation appointmentDetailDtoForCancellation)
        {
            var result = await _service.AppointmentDetailService.RejectAppointmentDetailsAsync(garageId, appointmentId, appointmentDetailDtoForCancellation);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
