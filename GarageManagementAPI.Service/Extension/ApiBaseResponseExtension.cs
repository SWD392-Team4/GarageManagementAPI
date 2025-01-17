using GarageManagementAPI.Shared.Responses;

namespace GarageManagementAPI.Service.Extension
{
    public static class ApiBaseResponseExtension
    {
        public static TResultType GetResult<TResultType>(this ApiBaseResponse apiBaseResponse)
            => (apiBaseResponse as ApiOkResponse<TResultType>)!.Result;
    }
}
