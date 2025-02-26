using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceImage;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IServiceImageService
    {
        public Task<Result<IEnumerable<ExpandoObject>>> GetImageByIdService(Guid serviceId, ServiceImageParameters serviceImageParameters, bool trackChanges);
        public Task<Result<ServiceImageDto>> CreateImageService(Guid serviceId, string imgId, string imgUrl);
        public Task<Result> UpdateServiceImage(Guid serviceImageId, ServiceImageDtoForUpdate serviceImageDtoForUpdate);

    }
}
