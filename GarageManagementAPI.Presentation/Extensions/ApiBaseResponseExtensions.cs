using GarageManagementAPI.Shared.Responses;

namespace GarageManagementAPI.Presentation.Extensions
{
    public static class ApiBaseResponseExtensions
    {
        public static TResultType GetResult<TResultType>(this ApiBaseResponse apiBaseResponse)
            => (apiBaseResponse as ApiOkResponse<TResultType>)!.Result;
    }
}
