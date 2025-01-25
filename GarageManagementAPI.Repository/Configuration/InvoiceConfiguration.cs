using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class InvoiceConfiguration : ConfigurationBase<Invoice>
    {
        protected override void ModelCreating(EntityTypeBuilder<Invoice> entity)
        {
            entity.HasKey(e => e.Id).HasName("invoice_appointmentid_primary");

            entity.ToTable("Invoice");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CustomerEmail).HasMaxLength(255);
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.CustomerPhoneNumber).HasMaxLength(255);
            entity.Property(e => e.InvoiceType).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.Appointment).WithOne(p => p.Invoice)
                .HasForeignKey<Invoice>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_appointmentid_foreign");

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoiceCustomers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("invoice_customerid_foreign");

            entity.HasOne(d => d.Employee).WithMany(p => p.InvoiceEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_employeeid_foreign");

            entity.HasOne(d => d.Garage).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.GarageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_garageid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();

            entity.Property(e => e.InvoiceType)
                .HasConversion<string>();
        }
    }
}




