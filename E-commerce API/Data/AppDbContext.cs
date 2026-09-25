using E_commerce_API.Models;
using E_commerce_API.Services.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace E_commerce_API.Data
{
    public class AppDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public AppDbContext(DbContextOptions<AppDbContext> options , ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
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



        public override async Task<int> SaveChangesAsync( CancellationToken cancellationToken = default)
        {
            ApplyAuditing();
            return await base.SaveChangesAsync( cancellationToken);
        }






        private void ApplyAuditing()
        {
            var statuts = ChangeTracker.Entries<BaseEntity>().ToList();
            foreach (var entry in statuts)
            {
                if(entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdateBy = _currentUserService.UserName;
                    entry.Entity.UpdateAt = DateTime.UtcNow;

                    entry.Property(x => x.CreateAt)                     
                       .IsModified = false;

                    entry.Property(x => x.CreateBy)
                        .IsModified = false;

                }


                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreateBy = _currentUserService.UserName ?? "System";
                    entry.Entity.CreateAt = DateTime.UtcNow;

                }


            }

        }
    }
}
