using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Invoice;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpPost(Name = "CreateInvoice")]
        public async Task<IActionResult> CreateProduct([FromBody] InvoiceDtoForCreation invoiceDtoForCreation)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var createProductResult = await _service.InvoiceService.CreateInvoice(invoiceDtoForCreation, Guid.Parse(userId!));
            if (!createProductResult.IsSuccess)
            {
                return ProcessError(createProductResult);
            }

            var createdProduct = createProductResult.GetValue<InvoiceDto>();
            return Ok(createdProduct);
            //return CreatedAtRoute("GetProductById", new { productId = createdProduct.Id }, createProductResult);
        }
    }
}
