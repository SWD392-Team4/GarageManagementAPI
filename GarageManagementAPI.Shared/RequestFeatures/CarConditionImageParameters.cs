using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class CarConditionImageParameters : RequestParameters 
    {
        [EnumDataType(typeof(ConditionStage))]
        public ConditionStage? Stage { get; set; }
    }
}
