using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class CarModelConfiguration : ConfigurationBase<CarModel>
    {
        protected override void ModelCreating(EntityTypeBuilder<CarModel> builder)
        {
        }
    }

}
