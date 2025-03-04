using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.SupplierContact;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/supplier/contacts")]
    [ApiController]
    public class SupplierContactController : ApiControllerBase
    {
        public SupplierContactController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)}, {nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetSuppliers([FromQuery] SupplierContactParameters supplierContactParameters)
        {
            var supplierContactsResult = await _service.SupplierContactService.GetSupplierContactsAsync(supplierContactParameters, trackChanges: false);

            return supplierContactsResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{supplierContactId:guid}", Name = "GetSupplierContactById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetSupplierContactById(Guid supplierContactId, [FromQuery] SupplierContactParameters supplierParameters)
        {
            var supplierResult = await _service.SupplierContactService.GetSupplierContactAsync(supplierContactId, supplierParameters, trackChanges: false);

            return supplierResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{supplierId:guid}/supplier", Name = "GetSupplierContactBySupplier")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetSupplierContactBySupplier(Guid supplierId, [FromQuery] SupplierContactParameters supplierParameters)
        {
            var supplierResult = await _service.SupplierContactService.GetSupplierContactsBySupplierAsync(supplierId, supplierParameters, trackChanges: false);

            return supplierResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost(Name = "CreateSupplierContact")]
        public async Task<IActionResult> CreateSupplierContact([FromBody] SupplierContactDtoForCreation supplierContactDtoForCreation)
        {
            var result = await _service.SupplierContactService.CreateSupplierContactAsync(supplierContactDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdsupplier = result.GetValue<SupplierContactDto>();

                    return CreatedAtRoute("GetSupplierContactById", new { supplierContactId = createdsupplier.Id }, result);
                },
                onFailure: ProcessError
                );
        }

        [HttpPut("{supplierContactId:guid}")]
        public async Task<IActionResult> Updatesupplier(Guid supplierContactId, [FromBody] SupplierContactDtoForUpdate supplierContactDtoForUpdate)
        {
            var result = await _service.SupplierContactService
                .UpdateSupplierContact(
                supplierContactId,
                supplierContactDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }
    }
}
