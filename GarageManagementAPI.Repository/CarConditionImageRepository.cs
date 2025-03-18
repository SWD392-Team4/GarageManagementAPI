using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Repository
{
    public class CarConditionImageRepository : RepositoryBase<CarConditionImage>, ICarConditionImageRepository
    {
        public CarConditionImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
