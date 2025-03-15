using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/workplaces/{garageId}/appointments/{appointmentId:guid}/details/{appointmentDetailId}/products")]
    [ApiController]
    public class AppointmentReplacementPartController : ApiControllerBase
    {
        public AppointmentReplacementPartController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentReplacementParts(Guid garageId, Guid appointmentId, Guid appointmentDetailId)
        {
            var result = await _service.AppointmentReplacementPartService.GetAppointmentReplacementPartsAsync(garageId, appointmentId, appointmentDetailId);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{replacementPartId:guid}")]
        public async Task<IActionResult> GetAppointmentReplacementPart(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid replacementPartId)
        {
            var result = await _service.AppointmentReplacementPartService.GetAppointmentReplacementPartAsync(garageId, appointmentId, appointmentDetailId, replacementPartId);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointmentReplacementPart(Guid garageId, Guid appointmentId, Guid appointmentDetailId, [FromBody] AppointmentReplacementPartDtoForCreation appointmentReplacementPartDtoForCreation)
        {
            var result = await _service.AppointmentReplacementPartService.CreateAppointmentReplacementPartAsync(garageId, appointmentId, appointmentDetailId, appointmentReplacementPartDtoForCreation);
            return result.Map(
                onSuccess: _ => Created(),
                onFailure: ProcessError
                );
        }

        //[HttpPut("{replacementPartId:guid}")]
        //public async Task<IActionResult> UpdateAppointmentReplacementPart(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid replacementPartId, [FromBody] AppointmentReplacementPartDtoForUpdate appointmentReplacementPartDtoForUpdate)
        //{
        //    var result = await _service.AppointmentReplacementPartService.UpdateAppointmentReplacementPartAsync(garageId, appointmentId, appointmentDetailId, replacementPartId, appointmentReplacementPartDtoForUpdate);
        //    return result.Map(
        //        onSuccess: Ok,
        //        onFailure: ProcessError
        //        );
        //}
    }
}
