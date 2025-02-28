using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IServiceFeedbackService
    {
        Task<Result<IEnumerable<ExpandoObject>>> GetServiceFeedBackByIdService(Guid serviceId, ServiceFeedBackParameters serviceFeedBackParameterdParameters, bool trackChanges, string? include = null);
        public Task<Result<ExpandoObject>> GetServiceFeedback(Guid serviceFeedbackId, bool trackChanges, string? include);
        public Task<Result<ServiceFeedBackDto>> CreateServiceFeedBack(Guid userId,ServiceFeedbackDtoForCreation serviceFeedBackDtoForCreation);
        public Task<Result> UpdateServiceFeedBack(Guid serviceFeedBackId, ServiceFeedBackDtoForUpdate serviceFeedBackDtoForUpdate, bool trackChanges);
    }
}
