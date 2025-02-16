using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Utilities;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service
{
    public class EmployeeInfoService : IEmployeeInfoService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public EmployeeInfoService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

    }
}
