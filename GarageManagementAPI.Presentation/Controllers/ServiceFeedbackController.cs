using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback;
using GarageManagementAPI.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/services/feebacks")]
    [ApiController]
    public class ServiceFeedbackController : ApiControllerBase
    {
        public ServiceFeedbackController(IServiceManager service) : base(service)
        {
        }
        /// <summary>
        /// Get feedback by service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="serviceFeedbackParameters"></param>
        /// <returns></returns>
        [HttpGet("service/{serviceId:guid}", Name = "GetFeedbackByServiceId")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetFeedbackByServiceId(Guid serviceId, [FromQuery] ServiceFeedBackParameters serviceFeedbackParameters)
        {
            var productResult = await _service.ServiceFeedback.GetServiceFeedBackByIdService(serviceId, serviceFeedbackParameters, trackChanges: false);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Get feedback by id
        /// </summary>
        /// <param name="serviceFeedbackId"></param>
        /// <returns></returns>
        [HttpGet("{serviceFeedbackId:guid}", Name = "GetServiceFeebackById")]
        [Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)},{nameof(SystemRole.Customer)}")]
        public async Task<IActionResult> GetServiceFeebackById(Guid serviceFeedbackId)
        {
            var carPartResult = await _service.ServiceFeedback.GetServiceFeedback(serviceFeedbackId, trackChanges: false, null);

            return carPartResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Create feedback
        /// </summary>
        /// <param name="serviceFeedbackDtoForCreation"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateServiceFeedback")]
        [Authorize(Roles = $"{nameof(SystemRole.Customer)}")]
        public async Task<IActionResult> CreateServiceFeeback([FromBody] ServiceFeedbackDtoForCreation serviceFeedbackDtoForCreation)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("UserId")!);
            var result = await _service.ServiceFeedback.CreateServiceFeedBack(userId, serviceFeedbackDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdServiceFeedback = result.GetValue<ServiceFeedBackDto>();

                    return CreatedAtRoute("GetServiceFeebackById", new { serviceFeedbackId = createdServiceFeedback.Id }, result);
                },
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Update feddback
        /// </summary>
        /// <param name="serviceFeedbackId"></param>
        /// <param name="serviceFeedbackDtoForUpdate"></param>
        /// <returns></returns>
        [HttpPut("{serviceFeedbackId:guid}", Name = "UpdateServiceFeedback")]
        [Authorize(Roles = $"{nameof(SystemRole.Customer)}")]
        public async Task<IActionResult> UpdateServiceFeedback(Guid serviceFeedbackId, [FromBody] ServiceFeedBackDtoForUpdate serviceFeedbackDtoForUpdate)
        {
            var result = await _service.ServiceFeedback
                .UpdateServiceFeedBack(
                serviceFeedbackId,
                serviceFeedbackDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }
    }
}
