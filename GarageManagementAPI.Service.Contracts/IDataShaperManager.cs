﻿using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IDataShaperManager
    {
        IDataShaper<WorkplaceDto> Workplace { get; }

        IDataShaper<UserDto> User { get; }
    }
}
