using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Shared.ResultModel;
using System.Net;

namespace GarageManagementAPI.Shared.Extension
{
    public static class ResultExtension
    {
        public static TResultType GetValue<TResultType>(this Result result)
            => (result as Result<TResultType>)!.Value!;

        public static Result<TOut> Then<TIn, TOut>(this Result<TIn> result, Func<TIn, Result<TOut>> nextStep)
        {
            return result.IsSuccess ? nextStep(result.Value!) : Result<TOut>.Failure(HttpStatusCode.BadRequest, result.Errors!);
        }

        public static Result<TOut> SafeExecute<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func, List<ErrorsResult> fallbackError)
        {
            try
            {
                return result.IsSuccess ?
                    Result<TOut>.Success(func(result.Value!), HttpStatusCode.OK) : Result<TOut>.Failure(HttpStatusCode.BadRequest, result.Errors!);
            }
            catch
            {
                return Result<TOut>.Failure(HttpStatusCode.InternalServerError, fallbackError);
            }
        }

        public static Result<TIn> Inspect<TIn>(this Result<TIn> result, Action<TIn> action)
        {
            if (result.IsSuccess)
            {
                action(result.Value!);
            }
            return result;
        }

    }
}
