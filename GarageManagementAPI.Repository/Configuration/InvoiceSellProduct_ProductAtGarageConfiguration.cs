using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository.Configuration
{
    public class InvoiceSellProduct_ProductAtGarageConfiguration : ConfigurationBase<InvoiceSellProduct_ProductAtGarage>
    {
        protected override void ModelCreating(EntityTypeBuilder<InvoiceSellProduct_ProductAtGarage> entity)
        {

            entity.HasKey(gp => new { gp.ProductAtGarageId, gp.InvoiceSellProductId });

            entity.HasOne(gp => gp.ProductAtGarage)
                .WithMany(gid => gid.InvoiceSellProduct_ProductAtGarage)
                .HasForeignKey(gp => gp.ProductAtGarageId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(gp => gp.InvoiceSellProduct)
                .WithMany(pw => pw.InvoiceSellProduct_ProductAtGarage)
                .HasForeignKey(gp => gp.InvoiceSellProduct)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
