using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IServiceFeedBackRepository
    {
        Task<ServiceFeedBack?> GetServiceFeedbackAsync(Guid serviceFeedbackId, bool trackChanges, string? include = default);
        Task<PagedList<ServiceFeedBack>> GetServiceFeedbackByIdServiceAsync(Guid serviceId, ServiceFeedBackParameters serviceFeedbackParameters, bool trackChanges, string? include = default);
        Task CreateServiceFeedbackAsync(ServiceFeedBack serviceFeedback);
        void UpdateServiceFeedbackAsync(ServiceFeedBack serviceFeedback);
    }
}
