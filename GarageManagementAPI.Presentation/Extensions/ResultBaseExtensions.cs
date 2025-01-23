using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Presentation.Extensions
{
    public static class ResultBaseExtensions
    {
        public static TResultType GetValue<TResultType>(this Result result)
            => (result as Result<TResultType>)!.Value!;
    }
}
