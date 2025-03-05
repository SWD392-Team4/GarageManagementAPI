using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.Supplier;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : ApiControllerBase
    {
        public SupplierController(IServiceManager service) : base(service)
        {
        }
        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)}, {nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetSuppliers([FromQuery] SupplierParameters supplierParameters)
        {
            var supplierResult = await _service.SupplierService.GetSuppliersAsync(supplierParameters, trackChanges: false);

            return supplierResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{supplierId:guid}", Name = "GetSupplierById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetsupplierById(Guid supplierId, [FromQuery] SupplierParameters supplierParameters)
        {
            var supplierResult = await _service.SupplierService.GetSupplierAsync(supplierId, supplierParameters, trackChanges: false);

            return supplierResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost(Name = "Createsupplier")]
        public async Task<IActionResult> CreateSupplier([FromBody] SupplierDtoForCreation supplierDtoForCreation)
        {
            var result = await _service.SupplierService.CreateSupplierAsync(supplierDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdsupplier = result.GetValue<SupplierDto>();

                    return CreatedAtRoute("GetSupplierById", new { supplierId = createdsupplier.Id }, result);
                },
                onFailure: ProcessError
                );
        }

        [HttpPut("{supplierId:guid}")]
        public async Task<IActionResult> Updatesupplier(Guid supplierId, [FromBody] SupplierDtoForUpdate supplierDtoForUpdate)
        {
            var result = await _service.SupplierService
                .UpdateSupplier(
                supplierId,
                supplierDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }
    }
}
