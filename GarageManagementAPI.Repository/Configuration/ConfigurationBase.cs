using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public abstract class ConfigurationBase<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            SeedData(builder);
            ModelCreating(builder);
        }

        protected virtual void SeedData(EntityTypeBuilder<T> builder) { }

        protected virtual void ModelCreating(EntityTypeBuilder<T> builder) { }
    }
}
