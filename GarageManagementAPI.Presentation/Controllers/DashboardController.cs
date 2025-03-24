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
        /// Lấy doanh số nha anh Tân ơi
        /// </summary>
        /// <param name="garageId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("revenue/{year}", Name = "GetMonthlySalesByYearDashBoard")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetMonthlySalesByYearDashBoard(Guid? garageId, int year)
        {
            var productResult = await _service.InvoiceService.GetMonthlySalesByYear(garageId, year, trackChanges: false);
            return Ok(productResult);
        }

        /// <summary>
        /// Get services in year
        /// </summary>
        /// <param name="garageId"></param>
        /// <param name="year"></param>
        /// <returns></returns>

        [HttpGet("services/{year}", Name = "GetServicesDashBoard")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetServicesDashBoard(Guid? garageId, int year)
        {
            var productResult = await _service.AppointmentService.GetServices(year, garageId, trackChanges: false);
            return Ok(productResult);
        }

        /// <summary>
        /// Total packages in year
        /// </summary>
        /// <param name="garageId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("pakages/{year}", Name = "GetPagekagesDashBoard")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetPagekagesDashBoard(Guid? garageId, int year)
        {
            var productResult = await _service.AppointmentService.GetPakages(year, garageId, trackChanges: false);
            return Ok(productResult);
        }

        /// <summary>
        /// Total product sell in year
        /// </summary>
        /// <param name="garageId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("productsell/{year}", Name = "GetProductSellDashBoard")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductSellDashBoard(Guid? garageId, int year)
        {
            var productResult = await _service.InvoiceSellProductService.GetSales(year, garageId, trackChanges: false);
            return Ok(productResult);
        }

        [HttpGet("package/{year}", Name = "GetPackageDashBoard")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetPackageDashBoard(Guid? garageId, int year)
        {
            var productResult = await _service.AppointmentDetailService.GetTotalEachPackage(year, garageId, trackChanges: false);
            return Ok(productResult);
        }


        [HttpGet("service/{year}", Name = "GetServiceDashBoard")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetServiceDashBoard(Guid? garageId, int year)
        {
            var productResult = await _service.AppointmentDetailService.GetTotalEachService(year, garageId, trackChanges: false);
            return Ok(productResult);
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

        [HttpGet("customers/{year}", Name = "GetCustomers")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetCustomers(Guid? garageId, int year)
        {
            var productResult = await _service.AppointmentService.GetCustomers(year, garageId, trackChanges: false);
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
        public async Task<IActionResult> GetLowStockProduct(int lowStockProduct, Guid? warehouseId)
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
