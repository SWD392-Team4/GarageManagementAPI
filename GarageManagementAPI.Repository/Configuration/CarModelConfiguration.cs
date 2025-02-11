using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class CarModelConfiguration : ConfigurationBase<CarModel>
    {
        protected override void ModelCreating(EntityTypeBuilder<CarModel> entity)
        {
            entity.HasKey(e => e.Id).HasName("carmodel_id_primary");

            entity.ToTable("CarModel");

            entity.HasIndex(e => e.BrandId, "carmodel_brandid_index");

            entity.HasIndex(e => e.CarCategoryId, "carmodel_carcategoryid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.ModelName).HasMaxLength(255);
            entity.Property(e => e.ModelYear).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Brand).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carmodel_brandid_foreign");

            entity.HasOne(d => d.CarCategory).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.CarCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carmodel_carcategoryid_foreign");

            entity.HasMany(d => d.Products).WithMany(p => p.CarModels)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCarModel",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productcarmodel_productid_foreign"),
                    l => l.HasOne<CarModel>().WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productcarmodel_carmodelid_foreign"),
                    j =>
                    {
                        j.HasKey("CarModelId", "ProductId").HasName("productcarmodel_carmodelid_productid_primary");
                        j.ToTable("ProductCarModel");
                    });


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




