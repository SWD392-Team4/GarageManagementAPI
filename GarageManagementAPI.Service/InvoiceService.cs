using AutoMapper;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Invoice;
using GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct;
using GarageManagementAPI.Shared.ErrorsConstant.GoodsIssued;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.Extension;

namespace GarageManagementAPI.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public InvoiceService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<InvoiceDto>> CreateInvoice(InvoiceDtoForCreation invoiceDtoForCreation, Guid userId)
        {
            var user = await _repoManager.User.GetUserByIdAsync(userId, false, "EmployeeInfo");
 
            var invoiceEntity = _mapper.Map<Invoice>(invoiceDtoForCreation);

            foreach (var invoiceDetail in invoiceDtoForCreation.InvoiceSellProducts)
            {
                var product = await _repoManager.Product.GetProductByIdAsync(invoiceDetail.ProductId, false);

                var productEntity = product!.OkResult().GetValue<Product>();
                invoiceEntity.EmployeeId = userId;
                invoiceEntity.GarageId = user!.EmployeeInfo!.WorkplaceId ?? throw new Exception("WorkplaceId cannot be null.");
                invoiceEntity.TotalPrice = invoiceDetail.Quantity * product!.ProductPrice;
            }
            await _repoManager.InvoiceRepository.CreateInvoiceAsync(invoiceEntity);


            foreach (var invoiceDetail in invoiceDtoForCreation.InvoiceSellProducts) {
                await this.CreateInvoiceSellProduct(invoiceDetail, user!.EmployeeInfo!.WorkplaceId, invoiceEntity.Id);
            }
            await _repoManager.SaveAsync();

            var invoiceDto = _mapper.Map<InvoiceDto>(invoiceEntity);
            return invoiceDto.CreatedResult();
        }

        public async Task<Result> CreateInvoiceSellProduct(InvoiceSellProductDtoForCreation sellProductDtoForCreation, Guid? garageId, Guid InvoiceId)
        {
            var totalStock = await _repoManager.ProductAtGarage
                .GetTotalStockForProduct(sellProductDtoForCreation.ProductId, garageId);

            if (totalStock < sellProductDtoForCreation.Quantity)
            {
                return Result<InvoiceSellProductDto>.BadRequest(
                    [GoodsIssuedErrors.GetQuantityIsOutOfRange()]);
            }

            var product = await _repoManager.Product.GetProductByIdAsync(sellProductDtoForCreation.ProductId, false);

            var productEntity = product!.OkResult().GetValue<Product>();

            var invoiceSellProductEntity = _mapper.Map<InvoiceSellProduct>(sellProductDtoForCreation);

            invoiceSellProductEntity.InvoiceId = InvoiceId;

            invoiceSellProductEntity.Price = productEntity.ProductPrice;
            invoiceSellProductEntity.CreatedAt = DateTime.UtcNow.SEAsiaStandardTime();

            await _repoManager.InvoiceSellProductRepository.CreateInvoiceSellProductAsync(invoiceSellProductEntity);
            await _repoManager.SaveAsync();

            var invoiceSellProductDto = _mapper.Map<InvoiceSellProductDto>(invoiceSellProductEntity);

            var deductedList = await _repoManager.ProductAtGarage.DeductProductQuantityFromGarageAsync(sellProductDtoForCreation.ProductId, garageId, sellProductDtoForCreation.Quantity);


            foreach (var (productAtGarageId, deductedQuantity) in deductedList)
            {
                var invoiceSellProduct_ProductAtGarage = new InvoiceSellProduct_ProductAtGarage()
                {
                    ProductductAtGarageId = productAtGarageId,
                    InvoiceSellProductId = invoiceSellProductDto.InvoiceId,
                    QuantityUsed = deductedQuantity
                };
                await _repoManager.InvoiceSellProduct_ProductAtGarage.CreatInvoiceSellProduct_ProductAtGarageAsync(invoiceSellProduct_ProductAtGarage);
                await _repoManager.SaveAsync();
            }
            return Result.NoContent();
        }
    }
}
