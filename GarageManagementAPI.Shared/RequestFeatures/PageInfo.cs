using System.Collections;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public record PageInfo(IEnumerable items, MetaData MetaData);
}
