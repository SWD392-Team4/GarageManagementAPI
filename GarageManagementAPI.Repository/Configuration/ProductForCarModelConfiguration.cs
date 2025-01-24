using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ProductForCarModelConfiguration : ConfigurationBase<ProductForCarModel>
    {
        protected override void ModelCreating(EntityTypeBuilder<ProductForCarModel> builder)
        {
            builder
                .HasOne(pfcm => pfcm.CarModel)
                .WithMany(cm => cm.ProductForCarModels)
                .HasForeignKey(pfcm => pfcm.CarModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(pfcm => pfcm.Product)
                .WithMany(p => p.ProductForCarModels)
                .HasForeignKey(pfcm => pfcm.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
