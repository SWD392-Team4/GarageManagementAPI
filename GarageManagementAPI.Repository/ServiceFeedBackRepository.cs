using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{
    public class ServiceFeedBackRepository : RepositoryBase<ServiceFeedBack>, IServiceFeedBackRepository
    {
        public ServiceFeedBackRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateServiceFeedbackAsync(ServiceFeedBack serviceFeedback)
        {
            await base.CreateAsync(serviceFeedback);
        }

        public async Task<ServiceFeedBack?> GetServiceFeedbackAsync(Guid serviceFeedbackId, bool trackChanges, string? include = null)
        {
            var serviceFeedback = include is null ?
             await FindByCondition(s => s.Id.Equals(serviceFeedbackId), trackChanges).SingleOrDefaultAsync() :
             await FindByCondition(s => s.Id.Equals(serviceFeedbackId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return serviceFeedback;
        }

        public async Task<PagedList<ServiceFeedBack>> GetServiceFeedbackByIdServiceAsync(Guid serviceId, ServiceFeedBackParameters serviceFeedbackParameters, bool trackChanges, string? include = null)
        {
            var serviceFeedback = await FindByCondition(
                s => s.ServiceId == serviceId, trackChanges)              
                .SearchByFeedback(serviceFeedbackParameters.FeedBack) 
                .SearchByDate(serviceFeedbackParameters.CreatedAt) 
                .SearchByDate(serviceFeedbackParameters.UpdatedAt) 
                .SearchByStatus(serviceFeedbackParameters.Status)
                .Sort(serviceFeedbackParameters.OrderBy)
                .IsInclude(include)
                .ToListAsync();

            return PagedList<ServiceFeedBack>.ToPagedList(
                serviceFeedback,
                serviceFeedbackParameters.PageNumber,
                serviceFeedbackParameters.PageSize
            );
        }

        public void UpdateServiceFeedbackAsync(ServiceFeedBack serviceFeedback)
        {
            base.Update(serviceFeedback);
        }
    }
}
