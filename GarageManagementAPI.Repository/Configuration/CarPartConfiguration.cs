using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class CarPartConfiguration : ConfigurationBase<CarPart>
    {
        protected override void ModelCreating(EntityTypeBuilder<CarPart> entity)
        {
            entity.HasKey(e => e.Id).HasName("carpart_id_primary");

            entity.ToTable("CarPart");

            entity.HasIndex(e => e.CarPartCategoryId, "carpart_carpartcategoryid_index");

            entity.HasIndex(e => e.PartName, "carpart_partname_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PartName).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.CarPartCategory).WithMany(p => p.CarParts)
                .HasForeignKey(d => d.CarPartCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carpart_carpartcategoryid_foreign");

            entity.HasMany(d => d.Products).WithMany(p => p.CarParts)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCarPart",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productcarpart_productid_foreign"),
                    l => l.HasOne<CarPart>().WithMany()
                        .HasForeignKey("CarPartId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productcarpart_carpartid_foreign"),
                    j =>
                    {
                        j.HasKey("CarPartId", "ProductId").HasName("productcarpart_carpartid_productid_primary");
                        j.ToTable("ProductCarPart");
                    });


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




