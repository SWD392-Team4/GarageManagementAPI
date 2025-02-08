﻿using Microsoft.EntityFrameworkCore.Storage;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IRepositoryManager
    {
        IWorkplaceRepository Workplace { get; }

        IUserRepository User { get; }

        IEmployeeInfoRepository EmployeeInfo { get; }

        IBrandRepository Brand { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();

        IExecutionStrategy CreateExecutionStrategy();

        Task SaveAsync();
    }
}
