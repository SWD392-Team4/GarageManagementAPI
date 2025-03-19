using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;

namespace GarageManagementAPI.Repository
{
    public class AppointmentReplacementPart_ProductAtGarageRepository : RepositoryBase<AppointmentReplacementPart_ProductAtGarage>, IAppointmentReplacementPart_ProductAtGarageRepository
    {
        public AppointmentReplacementPart_ProductAtGarageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
