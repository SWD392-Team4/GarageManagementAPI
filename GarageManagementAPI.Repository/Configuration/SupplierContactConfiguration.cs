using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
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

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
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

        protected override void SeedData(EntityTypeBuilder<SupplierContact> entity)
        {
            entity.HasData(
                    new SupplierContact()
                    {
                        Id = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                        SupplierId = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                        ContactPersonName = "John Doe",
                        ContactPosition = "Support",
                        ContactPhoneNumber = "0123456789",
                        ContactEmail = "john.doe@suppliera.com",
                    },
                    new SupplierContact()
                    {
                        Id = new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                        SupplierId = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                        ContactPersonName = "Jane Smith",
                        ContactPosition = "Manager",
                        ContactPhoneNumber = "0987654321",
                        ContactEmail = "jane.smith@supplierb.com",
                    },
                    new SupplierContact()
                    {
                        Id = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                        SupplierId = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                        ContactPersonName = "Michael Johnson",
                        ContactPosition = "Director",
                        ContactPhoneNumber = "0365478921",
                        ContactEmail = "michael.j@supplierc.com",
                    },
                    new SupplierContact()
                    {
                        Id = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                        SupplierId = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                        ContactPersonName = "Sales",
                        ContactPosition = "123 Street",
                        ContactPhoneNumber = "0932154786",
                        ContactEmail = "emily.d@supplierd.com",
                    }
             );
        }
    }
}




