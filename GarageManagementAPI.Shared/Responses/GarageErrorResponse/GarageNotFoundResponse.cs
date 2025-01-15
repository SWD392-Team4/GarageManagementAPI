namespace GarageManagementAPI.Shared.Responses.GarageErrorResponse
{
    public sealed class GarageNotFoundResponse : ApiNotFoundResponse
    {
        public GarageNotFoundResponse(Guid id)
        : base($"The garage with id: {id} doesn't exist in the database.")
        {
        }
    }
}
