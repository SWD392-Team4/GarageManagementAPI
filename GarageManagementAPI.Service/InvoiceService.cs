using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Invoice.Extension;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ErrorsConstant.GoodsIssued;
using GarageManagementAPI.Shared.DataTransferObjects.Invoice;
using GarageManagementAPI.Shared.ErrorsConstant.ProductAtGarage;
using GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct;

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
 
            var invoiceEntity = _mapper.Map<Entities.Models.Invoice>(invoiceDtoForCreation);

            foreach(var productAtGarage in invoiceDtoForCreation.InvoiceSellProducts)
            {
                var product = await _repoManager.ProductAtGarage.GetProductAtGarage(productAtGarage.ProductId, false);
                if (product == null) return Result<InvoiceDto>.BadRequest(ProductAtGarageErrors.GetProductAtGarageNotFound(productAtGarage.ProductId));
            }

            foreach (var invoiceDetail in invoiceDtoForCreation.InvoiceSellProducts)
            {
                var product = await _repoManager.Product.GetProductByIdAsync(invoiceDetail.ProductId, false);

                var productEntity = product!.OkResult().GetValue<Product>();
                invoiceEntity.EmployeeId = userId;
                invoiceEntity.InvoiceType = InvoiceType.InvocieSell;
                invoiceEntity.GarageId = user!.EmployeeInfo!.WorkplaceId ?? throw new Exception("WorkplaceId cannot be null.");
                invoiceEntity.TotalPrice = invoiceDetail.Quantity * product!.ProductPrice;
            }
            await _repoManager.Invoice.CreateInvoiceAsync(invoiceEntity);


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

            await _repoManager.InvoiceSellProduct.CreateInvoiceSellProductAsync(invoiceSellProductEntity);
            await _repoManager.SaveAsync();

            var invoiceSellProductDto = _mapper.Map<InvoiceSellProductDto>(invoiceSellProductEntity);

            var deductedList = await _repoManager.ProductAtGarage.DeductProductQuantityFromGarageAsync(sellProductDtoForCreation.ProductId, garageId, sellProductDtoForCreation.Quantity);


            foreach (var (productAtGarageId, deductedQuantity) in deductedList)
            {
                var invoiceSellProduct_ProductAtGarage = new InvoiceSellProduct_ProductAtGarage()
                {
                    ProductAtGarageId = productAtGarageId,
                    InvoiceSellProductId = invoiceSellProductDto.Id,
                    QuantityUsed = deductedQuantity
                };
                await _repoManager.InvoiceSellProduct_ProductAtGarage.CreatInvoiceSellProduct_ProductAtGarageAsync(invoiceSellProduct_ProductAtGarage);
                await _repoManager.SaveAsync();
            }
            return Result.NoContent();
        }

        public async Task<Result<InvoiceDto>> GetInvoice(Guid invoiceId, bool trackChanges, string? include = null)
        {
            var invoice = await this.GetAndCheckInvoice(invoiceId, trackChanges, include);
            if (!invoice.IsSuccess) return Result<InvoiceDto>.NotFound(invoice.Errors!);

            var invoiceEntity = invoice.GetValue<Entities.Models.Invoice>();

            var invoiceDto = _mapper.Map<InvoiceDto>(invoiceEntity);
            return Result<InvoiceDto>.Ok(invoiceDto);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetInvoicesForAdmin(Guid? garageId, InvoiceParameters invoiceParameters, bool trackChanges, string? include = null)
        {
            
            var invoices = await _repoManager.Invoice.GetInvoices(garageId, invoiceParameters, trackChanges, include);

            var invoicesDto = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);

            var invoicesShaped = _dataShaper.Invoice.ShapeData(invoicesDto, invoiceParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(invoicesShaped, invoices.MetaData);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetInvoicesForCustomers(string phoneNumber, InvoiceParameters invoiceParameters, bool trackChanges, string? include = null)
        {
            var invoices = await _repoManager.Invoice.GetInvoices(phoneNumber, invoiceParameters, trackChanges, include);

            var invoicesDto = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);

            var invoicesShaped = _dataShaper.Invoice.ShapeData(invoicesDto, invoiceParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(invoicesShaped, invoices.MetaData);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetInvoicesForCahier(Guid userId, InvoiceParameters invoiceParameters, bool trackChanges, string? include = null)
        {
            var user = await _repoManager.User.GetUserByIdAsync(userId, false, "EmployeeInfo");

            var garageId = user!.EmployeeInfo!.WorkplaceId ?? throw new Exception("GarageId cannot be null.");

            var invoices = await _repoManager.Invoice.GetInvoices(garageId, invoiceParameters, trackChanges, include);

            var invoicesDto = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);

            var invoicesShaped = _dataShaper.Invoice.ShapeData(invoicesDto, invoiceParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(invoicesShaped, invoices.MetaData);
        }

        public async Task<Result<InvoiceSellProductDto>> GetInvoiceSellProduct(Guid invoiceId, bool trackChanges, string? include = null)
        {
            var invoiceSellProduct = await this.GetAndCheckInvoiceSellProduct(invoiceId, trackChanges, include);

            var invoiceEntity = invoiceSellProduct.GetValue<InvoiceSellProduct>();

            var invoiceDto = _mapper.Map<InvoiceSellProductDto>(invoiceEntity);
            return Result<InvoiceSellProductDto>.Ok(invoiceDto);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetInvoiceSellProducts(Guid invoiceId, InvoiceSellProductParameters invoiceSellProductParameters, bool trackChanges, string? include = null)
        {
            var invoiceSellProducts = await _repoManager.InvoiceSellProduct.GetInvoiceSellProducts(invoiceId, invoiceSellProductParameters, trackChanges, include);

            var invoiceSellProductsDto = _mapper.Map<IEnumerable<InvoiceSellProductDto>>(invoiceSellProducts);

            var invoiceSellProductsShaped = _dataShaper.InvoiceSellProduct.ShapeData(invoiceSellProductsDto, invoiceSellProductParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(invoiceSellProductsShaped); 
        }

        private async Task<Result<Entities.Models.Invoice>> GetAndCheckInvoice(Guid invoiceId, bool trackChanges, string? include)
        {
            var invoice = await _repoManager.Invoice.GetInvoice(invoiceId, trackChanges, include);
            if (invoice == null) return invoice.NotFound(invoiceId);
            return invoice.OkResult();
        }

        private async Task<Result<Entities.Models.InvoiceSellProduct>> GetAndCheckInvoiceSellProduct(Guid invoiceId, bool trackChanges, string? include)
        {
            var invoice = await _repoManager.InvoiceSellProduct.GetInvoiceSellProduct(invoiceId, trackChanges, include);
            if (invoice == null) return invoice.NotFound(invoiceId);
            return invoice.OkResult();
        }
    }
}
