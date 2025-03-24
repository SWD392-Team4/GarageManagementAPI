using GarageManagementAPI.Presentation.ModelBinders;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.DataTransferObjects.EmployeeSchedule;

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
            if (!result.IsSuccess)
                return ProcessError(result);

            await _service.MailService.SendInformationAppointmentEmail(appointmentId);

            return Created();
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

        [HttpPost("{detailId:guid}/assign")]
        public async Task<IActionResult> AssignEmployee(Guid garageId, Guid appointmentId, Guid detailId, [FromBody] EmployeeScheduleDtoForAssign employeeScheduleDtoForAssign)
        {
            var result = await _service.AppointmentDetailService.AssignEmployee(garageId, appointmentId, detailId, employeeScheduleDtoForAssign);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost("{detailId:guid}/unassign")]
        public async Task<IActionResult> UnAssignEmployee(Guid garageId, Guid appointmentId, Guid detailId, [FromBody] EmployeeScheduleDtoForUnassign employeeScheduleDtoForUnassign)
        {
            var result = await _service.AppointmentDetailService.UnAssignEmployee(garageId, appointmentId, detailId, employeeScheduleDtoForUnassign);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("email/confirm/({ids})")]
        public async Task<IActionResult> ConfirmAppointmentDetailFromMail(Guid garageId, Guid appointmentId, [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var detailDtoForConfirm = new AppointmentDetailDtoForConfirm { AppointmentDetailId = [.. ids] };

            var result = await _service.AppointmentDetailService.ConfirmAppointmentDetail(garageId, appointmentId, detailDtoForConfirm);
            return result.Map(
                onSuccess: _ => Redirect("https://tbturbotrack.netlify.app/booking/success"),
                onFailure: ProcessError
                );
        }
        [HttpGet("email/reject/({ids})")]
        public async Task<IActionResult> RejectAppointmentDetailFromMail(Guid garageId, Guid appointmentId, [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var appointmentDetailDtoForCancellation = new AppointmentDetailDtoForCancellation { AppointmentDetailId = [.. ids], CancelReason = "Khách hàng hủy thông qua mail." };

            var result = await _service.AppointmentDetailService.RejectAppointmentDetailsAsync(garageId, appointmentId, appointmentDetailDtoForCancellation);
            return result.Map(
                onSuccess: _ => Redirect("https://tbturbotrack.netlify.app/booking/success"),
                onFailure: ProcessError
                );
        }

    }
}
