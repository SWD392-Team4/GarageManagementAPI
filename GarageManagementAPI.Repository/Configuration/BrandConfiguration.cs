using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class BrandConfiguration : ConfigurationBase<Brand>
    {
        protected override void ModelCreating(EntityTypeBuilder<Brand> entity)
        {
            entity.HasKey(e => e.Id).HasName("brand_id_primary");

            entity.ToTable("Brand");

            entity.HasIndex(e => e.BrandName, "brand_brandname_unique").IsUnique();

            // Đảm bảo cột Id có giá trị GUID được sinh ra tự động từ cơ sở dữ liệu
            entity.Property(e => e.Id)
                .HasDefaultValueSql("NEWID()")  // Cấu hình cơ sở dữ liệu sinh GUID
                .ValueGeneratedOnAdd();         // Đảm bảo GUID sẽ được tạo khi thêm mới
            entity.Property(e => e.BrandName).HasMaxLength(255);
            entity.Property(e => e.LinkLogo).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            // Chuyển đổi giá trị Status từ Enum sang chuỗi khi lưu vào cơ sở dữ liệu
            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




