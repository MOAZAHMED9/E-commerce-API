using E_commerce_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace E_commerce_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Categore> Categore { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);    //ا EF Core، دور في الـ Assembly بتاع المشروع على كل الـ Classes اللي بتعمل IEntityTypeConfiguration<T>، وطبّق الـ configurations بتاعتها تلقائيًا.

            SeedData.Seed(modelBuilder);
        }
      

    }
}
