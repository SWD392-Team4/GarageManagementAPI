using GarageManagementAPI.Presentation.ModelBinders;
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
        //[HttpGet]
        //public async Task<IActionResult> GetAppointmentDetails(Guid garageId, Guid appointmentId)
        //{
        //    var result = await _service.AppointmentDetailService.GetAppointmentDetail(garageId, appointmentId);
        //    return result.Map(
        //        onSuccess: Ok,
        //        onFailure: ProcessError
        //        );
        //}


        //[HttpPost]
        //public async Task<IActionResult> CreateAppointmentDetails(Guid garageId, Guid appointmentId, [FromBody] List<AppointmentDetailDtoForCreation> appointmentDetailDtoForCreation)
        //{
        //    var result = await _service.AppointmentDetailService.CreateAppointmentDetails(garageId, appointmentId, appointmentDetailDtoForCreation);
        //    return result.Map(
        //        onSuccess: CreatedAtRoute("GetAppointmentDetail", new { garageId, appointmentId, appointmentDetailId = result.Value }, result.Value),
        //        onFailure: ProcessError
        //        );
        //}



        //[HttpDelete("({ids})")]
        //public async Task<IActionResult> DeleteAppointmentDetail(Guid garageId, Guid appointmentId, [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        //{
        //    var result = await _service.AppointmentDetailService.DeleteAppointmentDetails(garageId, appointmentId, ids);
        //    return result.Map(
        //        onSuccess: Ok,
        //        onFailure: ProcessError
        //        );
        //}
    }
}
