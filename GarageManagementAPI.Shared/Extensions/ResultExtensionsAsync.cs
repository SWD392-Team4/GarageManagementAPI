using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Shared.ResultModel;
using System.Net;

namespace GarageManagementAPI.Shared.Extensions
{
    public static class ResultExtensionsAsync
    {
        // GetValueAsync
        public static async Task<TResultType> GetValueAsync<TResultType>(this Task<Result> resultTask)
        {
            var result = await resultTask.ConfigureAwait(false);
            return ((Result<TResultType>)result).Value!;
        }

        // ThenAsync
        public static async Task<Result<TOut>> ThenAsync<TIn, TOut>(this Task<Result<TIn>> resultTask, Func<TIn, Task<Result<TOut>>> nextStep)
        {
            var result = await resultTask.ConfigureAwait(false);
            return result.IsSuccess ? await nextStep(result.Value!).ConfigureAwait(false) : Result<TOut>.Failure(result.StatusCode, result.Errors!);
        }

        // ThenIfAsync
        public static async Task<Result<TOut>> ThenIfAsync<TIn, TOut>(this Task<Result<TIn>> resultTask, bool condition, Func<TIn, Task<Result<TOut>>> nextStep)
        {
            var result = await resultTask.ConfigureAwait(false);
            return result.IsSuccess && condition
                ? await nextStep(result.Value!).ConfigureAwait(false)
                : Result<TOut>.Failure(result.StatusCode, result.Errors!);
        }

        // SafeExecuteAsync
        public static async Task<Result<TOut>> SafeExecuteAsync<TIn, TOut>(this Task<Result<TIn>> resultTask, Func<TIn, Task<TOut>> func, List<ErrorsResult> fallbackError)
        {
            try
            {
                var result = await resultTask.ConfigureAwait(false);
                return result.IsSuccess
                    ? Result<TOut>.Success(await func(result.Value!).ConfigureAwait(false), result.StatusCode)
                    : Result<TOut>.Failure(result.StatusCode, result.Errors!);
            }
            catch
            {
                return Result<TOut>.Failure(HttpStatusCode.InternalServerError, fallbackError);
            }
        }

        // InspectAsync
        public static async Task<Result<TIn>> InspectAsync<TIn>(this Task<Result<TIn>> resultTask, Func<TIn, Task> action)
        {
            var result = await resultTask.ConfigureAwait(false);
            if (result.IsSuccess)
            {
                await action(result.Value!).ConfigureAwait(false);
            }
            return result;
        }
    }
}
