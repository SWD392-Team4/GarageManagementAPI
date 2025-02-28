using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory;

namespace GarageManagementAPI.Service
{
    public class ServiceHistoryService : IServiceHistoryService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public ServiceHistoryService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetServiceHistoryByServiceIdAsync(Guid ServiceId, ServiceHistoryParameters serviceHistoryParameters, bool trackChanges, string? include = null)
        {
            var servicesWithMetadata = await _repoManager.ServiceHistory.GetServiceHistoryByIdSerivceAsync(ServiceId, serviceHistoryParameters, trackChanges, include);

            var servicesDto = _mapper.Map<IEnumerable<ServiceHistoryDto>>(servicesWithMetadata);

            var servicesShaped = _dataShaper.ServiceHistory.ShapeData(servicesDto, serviceHistoryParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(servicesShaped, servicesWithMetadata.MetaData);
        }
    }
}
