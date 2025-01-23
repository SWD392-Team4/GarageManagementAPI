using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.Constant.Request
{
    /// <summary>
    /// Provides predefined error messages and helper methods for request-related errors.
    /// </summary>
    public static class RequestErrors
    {
        #region Error Messages
        public const string NullOrInvalidInput = "The input for '{0}' is invalid or null. Please provide a valid value.";
        public const string TooManyRequests = "You have made too many requests. Please wait a moment and try again.";
        public const string TooManyRequestsWithRetryAfter = "You have exceeded the request limit. Please wait {0} second(s) before retrying.";
        public const string InvalidToken = "The request is invalid due to a malformed or incorrect token. Please check and try again.";
        #endregion

        #region Static Methods
        /// <summary>
        /// Generates an error result for invalid or null input.
        /// </summary>
        /// <param name="objectName">The name of the object that is invalid or null.</param>
        public static ErrorsResult GetInvalidInputError(string objectName)
           => new ErrorsResult
           {
               Code = nameof(NullOrInvalidInput),
               Description = string.Format(NullOrInvalidInput, objectName)
           };

        /// <summary>
        /// Generates an error result for too many requests with a retry-after period.
        /// </summary>
        /// <param name="seconds">The number of seconds to wait before retrying.</param>
        public static ErrorsResult GetTooManyRequestsWithRetryAfterError(double seconds)
            => new ErrorsResult
            {
                Code = nameof(TooManyRequestsWithRetryAfter),
                Description = string.Format(TooManyRequestsWithRetryAfter, seconds)
            };

        /// <summary>
        /// Generates an error result for too many requests without additional metadata.
        /// </summary>
        public static ErrorsResult GetTooManyRequestsError()
            => new ErrorsResult
            {
                Code = nameof(TooManyRequests),
                Description = TooManyRequests
            };

        /// <summary>
        /// Generates an error result for an invalid token.
        /// </summary>
        public static ErrorsResult GetInvalidTokenError()
            => new ErrorsResult
            {
                Code = nameof(InvalidToken),
                Description = InvalidToken
            };
        #endregion
    }
}
