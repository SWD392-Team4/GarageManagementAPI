using ZXing;
using ZXing.Common;
using System.Drawing.Imaging;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ZXing.CoreCompat.System.Drawing;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Authorization;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/barcode")]
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

        [HttpGet("scan/garage/{barcode}/{garageId:guid}", Name = "GetProductBarcodeAtGarage")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductByBarcodeGarage(string barcode, Guid garageId,[FromQuery] ProductParameters productParameters)
        {
            var isInclude = "Brand,ProductCategory,ProductHistories,ProductImages";
            var productResult = await _service.ProductService.GetProductByBarcodeByProductAtGarageAsync(barcode, garageId, productParameters, trackChanges: false, isInclude);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("scan/{barcode}", Name = "GetProductBarcode")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductByBarcode(string barcode, [FromQuery] ProductParameters productParameters)
        {
            var isInclude = "Brand,ProductCategory,ProductHistories,ProductImages,CarModels,CarParts";
            var productResult = await _service.ProductService.GetProductByBarcodeAsync(barcode, productParameters, trackChanges: false, isInclude);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
