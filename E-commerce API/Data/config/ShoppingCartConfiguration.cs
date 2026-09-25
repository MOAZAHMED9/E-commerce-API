using E_commerce_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_API.Data.config
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
           builder
                .HasOne(x=> x.User)
                .WithOne(x=> x.ShoppingCart)
                .HasForeignKey<ShoppingCart>(x=> x.UserId);

            builder.HasQueryFilter(x => !x.IsDeleted);



        }
    }
}
