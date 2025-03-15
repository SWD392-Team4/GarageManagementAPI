using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.ErrorsConstant.GoodsIssued;

namespace GarageManagementAPI.Service
{
    public class InvoiceSellProductService : IInvoiceSellProductService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public InvoiceSellProductService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        public async Task<Result> CreateInvoiceSellProduct(InvoiceSellProductDtoForCreation sellProductDtoForCreation, Guid garageId)
        {
            var totalStock = await _repoManager.ProductAtWarehouse
                .GetTotalStockForProduct(sellProductDtoForCreation.ProductId, garageId);

            if (totalStock < sellProductDtoForCreation.Quantity)
            {
                return Result<InvoiceSellProductDto>.BadRequest(
                    [GoodsIssuedErrors.GetQuantityIsOutOfRange()]);
            }

            var product = await _repoManager.Product.GetProductByIdAsync(sellProductDtoForCreation.ProductId, false);

            var productEntity = product!.OkResult().GetValue<Product>();

            var invoiceSellProductEntity = _mapper.Map<InvoiceSellProduct>(sellProductDtoForCreation);

            invoiceSellProductEntity.Price = productEntity.ProductPrice;

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
