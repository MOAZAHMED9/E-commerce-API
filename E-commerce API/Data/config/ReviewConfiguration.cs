using E_commerce_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_API.Data.config
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            // خصبتلنا مشكله هنا ف انشاء الداتا بيز . علشان الريفيو تابعه لuser و تابعه order و ال order تابع للuser  ف حصل خاحه اسمها multiple cascade
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(x=> x.Product)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => new { x.UserId, x.ProductId }).IsUnique();

            builder.Property(x => x.rate);

            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}
