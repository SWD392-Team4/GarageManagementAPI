namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserDtoWithRelation : UserDto
    {
        public virtual EmployeeInfoDto? EmployeeInfo { get; set; }
    }
}
