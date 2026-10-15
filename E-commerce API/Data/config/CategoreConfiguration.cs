using E_commerce_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_API.Data.config
{
    public class CategoreConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(20);
            builder.Property(x=> x.Description).HasMaxLength(100);

            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}
