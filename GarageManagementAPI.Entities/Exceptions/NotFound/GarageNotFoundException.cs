namespace GarageManagementAPI.Entities.Exceptions.NotFound
{
    public sealed class GarageNotFoundException : NotFoundException
    {
        public GarageNotFoundException(Guid garageId) : base($"The garage with id: {garageId} doesn't exist in the database.")
        {
        }
    }
}
