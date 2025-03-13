using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IAppointmentPerDayRepository : IRepositoryBase<AppointmentPerDay>
    {
        public Task<AppointmentPerDay?> GetAppointmentPerDayAsync(Guid garageId, bool trackChanges);
    }
}
