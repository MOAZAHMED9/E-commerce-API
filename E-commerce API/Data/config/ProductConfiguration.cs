using E_commerce_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_API.Data.config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x=> x.Price).HasPrecision(18,2);

            builder
                .HasOne(x => x.Categore)
                .WithMany(x => x.Products)
                .HasForeignKey(x=> x.CategoreId);

            builder.HasIndex(x => x.Price);
            builder.HasIndex(x => x.IsAvailable);

            builder.HasQueryFilter(x => !x.IsDeleted);



        }
    }
}
