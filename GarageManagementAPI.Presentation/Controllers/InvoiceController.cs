using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Invoice;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;

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
            return Ok(createdProduct);
            //return CreatedAtRoute("GetProductById", new { productId = createdProduct.Id }, createProductResult);
        }

        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}, {nameof(SystemRole.Customer)}, {nameof(SystemRole.Administrator)}")]
        [HttpGet("cashier")]
        public async Task<IActionResult> GetInvoicesByCahier([FromQuery] InvoiceParameters invoiceParameters)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var invocesResult = await _service.InvoiceService.GetInvoicesForCahier(Guid.Parse(userId!), invoiceParameters, trackChanges: false);
            return invocesResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("customer")]
        public async Task<IActionResult> GetInvoices(string phonenumber, [FromQuery] InvoiceParameters invoiceParameters)
        {
            if (string.IsNullOrWhiteSpace(phonenumber))
            {
                return BadRequest(new { Message = "Phone number is required." });
            }
            var invocesResult = await _service.InvoiceService.GetInvoicesForCustomers(phonenumber, invoiceParameters, trackChanges: false);
            return invocesResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [Authorize(Roles = $"{nameof(SystemRole.Customer)}, {nameof(SystemRole.Administrator)}")]
        [HttpGet("admin/{garageId:guid}")]
        public async Task<IActionResult> GetInvoicesByAdmin(Guid garageId, [FromQuery] InvoiceParameters invoiceParameters)
        {
            var invocesResult = await _service.InvoiceService.GetInvoicesForAdmin(garageId, invoiceParameters, trackChanges: false);
            return invocesResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}, {nameof(SystemRole.Customer)}, {nameof(SystemRole.Administrator)}")]
        [HttpGet("invoice/{invoiceId:guid}")]
        public async Task<IActionResult> GetInvoice(Guid invoiceId)
        {
            var invoiceResult = await _service.InvoiceService.GetInvoice(invoiceId, trackChanges: false);
            return invoiceResult.Map(
               onSuccess: Ok,
               onFailure: ProcessError
                );
        }


        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}, {nameof(SystemRole.Customer)}, {nameof(SystemRole.Administrator)}")]
        [HttpGet("detail-sell-products/{invoiceId:guid}")]
        public async Task<IActionResult> GetInvoiceSellProducts(Guid invoiceId, [FromQuery] InvoiceSellProductParameters invoiceSellProductParameters)
        {
            var invocesResult = await _service.InvoiceService.GetInvoiceSellProducts(invoiceId, invoiceSellProductParameters, trackChanges: false, "Product");
            return invocesResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}, {nameof(SystemRole.Customer)}, {nameof(SystemRole.Administrator)}")]
        [HttpGet("invoice/invoice-sell-product/{invoiceSellProductId:guid}")]
        public async Task<IActionResult> GetInvoiceSellProduct(Guid invoiceSellProductId)
        {
            var invoiceResult = await _service.InvoiceService.GetInvoiceSellProduct(invoiceSellProductId, trackChanges: false);
            return invoiceResult.Map(
               onSuccess: Ok,
               onFailure: ProcessError
                );
        }
    }
}
