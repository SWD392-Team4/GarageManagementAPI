using GarageManagementAPI.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ApiControllerBase
    {
        public DashboardController(IServiceManager service) : base(service)
        {
        }

        /// <summary>
        /// Get appoiment theo năm 
        /// </summary>
        /// <param name="garageId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("appointment/{year}", Name = "GetAppointmentDashBoard")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetAppointmentDashBoard(Guid? garageId, int year)
        {
            var productResult = await _service.AppointmentService.GetAppointmentCountByMonth(year, garageId, trackChanges: false);
            return Ok(productResult);
        }

        /// <summary>
        /// Get doanh số 
        /// </summary>
        /// <param name="garageId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("sales/{year}", Name = "GetRevenue")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetRevenue(Guid? garageId, int year)
        {
            var productResult = await _service.InvoiceService.GetMonthlyRevenueByYear(garageId, year, trackChanges: false);
            return Ok(productResult);
        }

        /// <summary>
        /// Lấy sản phẩm sắp hết hàng tại tất cả warehouse
        /// </summary>
        /// <param name="lowStockProduct"></param>
        ///  <param name="warehouseId"></param>
        /// <returns></returns>
        [HttpGet("LowStockProduct/{lowStockProduct:int}", Name = "GetLowStockProduct")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetLowStockProduct(int lowStockProduct, Guid warehouseId)
        {
            var productResult = await _service.ProductService.GetLowStockProducts(lowStockProduct, warehouseId, trackChanges: false);

            return Ok(productResult);
        }

        /// <summary>
        /// Get sum product has received
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        [HttpGet("goodsReceivedByDate", Name = "GetGoodsReceivedByDate")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetGoodsReceivedByDate(Guid? warehouseId, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var productResult = await _service.GoodsReceivedDetailService.GetSumGoodsReceivedByDate(warehouseId, startDate, endDate);

            return Ok(productResult);
        }

        /// <summary>
        /// Get sum product has issued
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        [HttpGet("goodsIssuedByDate", Name = "GoodsIssuedByDate")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetGoodsIssuedByDate(Guid? warehouseId, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var productResult = await _service.GoodsIssuedDetailService.GetSumGoodsIssuedByDate(warehouseId, startDate, endDate);

            return Ok(productResult);
        }
    }
}
