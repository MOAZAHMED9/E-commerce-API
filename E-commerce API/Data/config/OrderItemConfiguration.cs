using E_commerce_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_API.Data.config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .HasOne(x=> x.Order)
                .WithMany(x=>x.OrderItems)
                .HasForeignKey(x=> x.OrderId);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.ProductId);

            builder.Property(x => x.priceAtPurchase).HasPrecision(18, 2);
            builder.HasQueryFilter(x => !x.IsDeleted);


        }
    }
}
