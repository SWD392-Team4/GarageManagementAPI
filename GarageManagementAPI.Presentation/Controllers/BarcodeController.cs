using GarageManagementAPI.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using ZXing;
using ZXing.QrCode;
using System.Drawing.Imaging;
using ZXing.CoreCompat.System.Drawing;
using ZXing.Common;
using System.Drawing;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("barcode")]
    [ApiController]
    public class BarcodeController : ApiControllerBase
    {
        public BarcodeController(IServiceManager service) : base(service)
        {
        }

        [HttpGet("generate")]
        public IActionResult GenerateBarcode(string barcodeText)
        {
            if (string.IsNullOrEmpty(barcodeText))
            {
                return BadRequest("Barcode text cannot be empty.");
            }

            var width = 300;  
            var height = 100; 
            var margin = 10;  

            // Tạo Barcode
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128, 
                Options = new EncodingOptions
                {
                    Width = width,
                    Height = height,
                    Margin = margin
                }
            };

            using var bitmap = barcodeWriter.Write(barcodeText);
            using var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            var byteArray = stream.ToArray();

            return File(byteArray, "image/png");
        }

        [Authorize(Roles = $"{nameof(SystemRole.Mechanic)}, {nameof(SystemRole.Cashier)}")]
        [HttpGet("scan/garage/{barcode}", Name = "GetProductBarcodeAtGarage")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductByBarcodeGarage(string barcode, [FromQuery] ProductParameters productParameters)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var isInclude = "Brand,ProductCategory,ProductHistories,ProductImages";
            var productResult = await _service.ProductService.GetProductByBarcodeByProductAtGarageAsync(barcode, Guid.Parse(userId), productParameters, trackChanges: false, isInclude);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [Authorize(Roles = $"{nameof(SystemRole.Mechanic)}, {nameof(SystemRole.Cashier)}")]
        [HttpGet("scan/{barcode}", Name = "GetProductBarcode")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductByBarcode(string barcode, [FromQuery] ProductParameters productParameters)
        {
            var isInclude = "Brand,ProductCategory,ProductHistories,ProductImages";
            var productResult = await _service.ProductService.GetProductByBarcodeAsync(barcode, productParameters, trackChanges: false, isInclude);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
