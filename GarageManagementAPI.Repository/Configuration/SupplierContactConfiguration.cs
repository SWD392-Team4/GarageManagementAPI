using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class SupplierContactConfiguration : ConfigurationBase<SupplierContact>
    {
        protected override void ModelCreating(EntityTypeBuilder<SupplierContact> entity)
        {
            entity.HasKey(e => e.Id).HasName("suppliercontact_id_primary");

            entity.ToTable("SupplierContact");

            entity.HasIndex(e => e.SupplierId, "suppliercontact_supplierid_index");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ContactEmail).HasMaxLength(255);
            entity.Property(e => e.ContactPersonName).HasMaxLength(255);
            entity.Property(e => e.ContactPhoneNumber).HasMaxLength(255);
            entity.Property(e => e.ContactPosition).HasMaxLength(255);

            entity.HasOne(d => d.Supplier).WithMany(p => p.SupplierContacts)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("suppliercontact_supplierid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




