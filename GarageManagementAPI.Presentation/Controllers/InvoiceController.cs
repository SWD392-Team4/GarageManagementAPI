using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Invoice;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoiceController : ApiControllerBase
    {
        public InvoiceController(IServiceManager service) : base(service)
        {
        }

        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}")]
        [HttpPost(Name = "CreateInvoice")]
        public async Task<IActionResult> CreateProduct([FromBody] InvoiceDtoForCreation invoiceDtoForCreation)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var createProductResult = await _service.InvoiceService.CreateInvoice(invoiceDtoForCreation, Guid.Parse(userId!));

            if (!createProductResult.IsSuccess)
                return ProcessError(createProductResult);

            var createdProduct = createProductResult.GetValue<InvoiceDto>();
            var getInvoiceResult = await GetInvoice(createdProduct.Id);
            return Ok(createdProduct);
            //return CreatedAtRoute("GetProductById", new { productId = createdProduct.Id }, createProductResult);
        }

        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}, {nameof(SystemRole.Customer)}, {nameof(SystemRole.Administrator)}")]
        [HttpGet("cashier")]
        public async Task<IActionResult> GetInvoicesByCahier([FromQuery] InvoiceParameters invoiceParameters)
        {
            var include = "InvoicePackageDetails, InvoiceServiceDetails, InvoiceSellProducts, Product";
            var userId = HttpContext.User.FindFirstValue("UserId");
            var invocesResult = await _service.InvoiceService.GetInvoicesForCahier(Guid.Parse(userId!), invoiceParameters, trackChanges: false, include);
            return invocesResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("customer")]
        public async Task<IActionResult> GetInvoices(string phonenumber, string gmail,[FromQuery] InvoiceParameters invoiceParameters)
        {
            if (string.IsNullOrWhiteSpace(phonenumber))
            {
                return BadRequest(new { Message = "Phone number is required." });
            }
            var invocesResult = await _service.InvoiceService.GetInvoicesForCustomers(phonenumber, gmail, invoiceParameters, trackChanges: false);
            return invocesResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [Authorize(Roles = $"{nameof(SystemRole.Customer)}, {nameof(SystemRole.Administrator)}")]
        [HttpGet("admin/{garageId:guid}")]
        public async Task<IActionResult> GetInvoicesByAdmin(Guid garageId, [FromQuery] InvoiceParameters invoiceParameters)
        {
            var include = "InvoicePackageDetails, InvoiceServiceDetails, InvoiceSellProducts, Product";
            var invocesResult = await _service.InvoiceService.GetInvoicesForAdmin(garageId, invoiceParameters, trackChanges: false, include);
            return invocesResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}, {nameof(SystemRole.Customer)}, {nameof(SystemRole.Administrator)}")]
        [HttpGet("invoice/{invoiceId:guid}")]
        public async Task<IActionResult> GetInvoice(Guid invoiceId)
        {
            var include = "InvoicePackageDetails, InvoiceServiceDetails, InvoiceSellProducts, Product";
            var invoiceResult = await _service.InvoiceService.GetInvoice(invoiceId, trackChanges: false, include);
            return invoiceResult.Map(
               onSuccess: Ok,
               onFailure: ProcessError
                );
        }


        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}, {nameof(SystemRole.Customer)}, {nameof(SystemRole.Administrator)}")]
        [HttpGet("detail-sell-products/{invoiceId:guid}")]
        public async Task<IActionResult> GetInvoiceSellProducts(Guid invoiceId, [FromQuery] InvoiceSellProductParameters invoiceSellProductParameters)
        {
            var include = "InvoicePackageDetails, InvoiceServiceDetails, InvoiceSellProducts, Product";
            var invocesResult = await _service.InvoiceService.GetInvoiceSellProducts(invoiceId, invoiceSellProductParameters, trackChanges: false, include);
            return invocesResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}, {nameof(SystemRole.Customer)}, {nameof(SystemRole.Administrator)}")]
        [HttpGet("invoice/invoice-sell-product/{invoiceSellProductId:guid}")]
        public async Task<IActionResult> GetInvoiceSellProduct(Guid invoiceSellProductId)
        {
            var include = "InvoicePackageDetails, InvoiceServiceDetails, InvoiceSellProducts, Product";
            var invoiceResult = await _service.InvoiceService.GetInvoiceSellProduct(invoiceSellProductId, trackChanges: false, include);
            return invoiceResult.Map(
               onSuccess: Ok,
               onFailure: ProcessError
                );
        }
    }
}
