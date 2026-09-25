using E_commerce_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_API.Data.config
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder
                .HasOne(x=> x.ShoppingCart)
                .WithMany(x=> x.CartItems)
                .HasForeignKey(x=>x.ShoppingCartId);

            builder.HasQueryFilter(x => !x.IsDeleted );
        }
    }
}
