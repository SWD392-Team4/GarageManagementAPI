using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class WorkplaceExtension
    {
        public static Result<Workplace> OkResult(this Workplace workplace)
            => Result<Workplace>.Ok(workplace);

        public static Result<WorkplaceDto> OkResult(this WorkplaceDto workplaceDto)
            => Result<WorkplaceDto>.Ok(workplaceDto);

        public static Result<WorkplaceDto> CreatedResult(this WorkplaceDto workplaceDto)
            => Result<WorkplaceDto>.Created(workplaceDto);

        public static Result<Workplace> NotFound(this Workplace? workplace, Guid workplaceId)
            => Result<Workplace>.NotFound([WorkplaceErros.GetWorkplaceNotFoundError(workplaceId)]);
    }
}
