using GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart;

namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail
{
    public class AppointmentDetailDtoForCreation : AppointmentDetailDtoForManipulation
    {
        public IEnumerable<ReplacementPartDtoForCreation>? ReplacementParts { get; set; }

    }

}
