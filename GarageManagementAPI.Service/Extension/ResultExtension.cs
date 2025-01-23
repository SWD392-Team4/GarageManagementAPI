using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class ResultExtension
    {
        public static TResultType GetValue<TResultType>(this Result result)
            => (result as Result<TResultType>)!.Value!;
    }
}
