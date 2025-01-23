using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.Constant.Employee
{
    public class EmployeeErrors
    {
        #region employee const errrors
        public const string EmployeeNotFound = "The specific employee with id {0} doesn't exist.";
        #endregion

        #region employee errors static method
        public static ErrorsResult GetEmployeeNotFoundError(Guid employeeId)
            => new ErrorsResult
            {
                Code = nameof(EmployeeNotFound),
                Description = string.Format(EmployeeNotFound, employeeId)
            };
        #endregion
    }
}
