using Bogus;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class GarageRepository : RepositoryBase<Garage>, IGarageRepository
    {
        public GarageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<PagedList<Garage>> GetAllGaragesAsync(
            GarageParameters garageParameters,
            bool trackChanges)
        {
            var garages = await FindAll(trackChanges)
            .Search(garageParameters.SearchTerm)
            .Sort(garageParameters.OrderBy)
            .Skip((garageParameters.PageNumber - 1) * garageParameters.PageSize)
            .Take(garageParameters.PageSize)
            .Includes(garageParameters.Include)
            .ToListAsync();

            var count = await FindAll(trackChanges)
                .Search(garageParameters.SearchTerm)
                .CountAsync();


            return new PagedList<Garage>(
                garages,
                count,
                garageParameters.PageNumber,
                garageParameters.PageSize);
        }
    }
}
