namespace GarageManagementAPI.Shared.Responses.EmployeeErrorResponse
{
    public sealed class EmployeeNotFoundResponse : ApiNotFoundResponse
    {
        public EmployeeNotFoundResponse(Guid id)
        : base($"The employee with id: {id} doesn't exist in the database.")
        {
        }
    }
}
