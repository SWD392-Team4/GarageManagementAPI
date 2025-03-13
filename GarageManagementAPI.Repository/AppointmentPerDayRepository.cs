using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class AppointmentPerDayRepository : RepositoryBase<AppointmentPerDay>, IAppointmentPerDayRepository
    {
        public AppointmentPerDayRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<AppointmentPerDay?> GetAppointmentPerDayAsync(Guid garageId, bool trackChanges)
        {
            return await FindByCondition(e => e.GarageId.Equals(garageId), trackChanges).FirstOrDefaultAsync();
        }
    }
}
