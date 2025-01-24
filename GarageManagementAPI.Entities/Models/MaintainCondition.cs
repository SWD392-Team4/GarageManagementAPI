namespace GarageManagementAPI.Entities.Models
{
    public class MaintainCondition : BaseEntity<MaintainCondition>
    {
        public Guid PackageId { get; set; }

        public required string ConditionType { get; set; } //days or km

        public required int Threshold { get; set; } //so ngay hoac so km

        public Package? Package { get; set; }
    }
}