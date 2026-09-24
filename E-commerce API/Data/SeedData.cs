//using E_commerce_API.Models;
//using Microsoft.EntityFrameworkCore;

//namespace E_commerce_API.Data
//{
//    public static class SeedData
//    {
//        private static readonly DateTime createat = DateTime.UtcNow;
//        public static void Seed(ModelBuilder modelBuilder)
//        {
//            // =========================
//            // Users
//            // =========================

//            modelBuilder.Entity<User>().HasData(
//                new User
//                {
//                    Id = 1,
//                    UserName = "Admin",
//                    Password = "Admin123", // مؤقتًا للـ Seed
//                    Email = "admin@example.com",
//                    Phone = "01012345678",
//                    Role = enRole.Admin,
//                    IsActive = true,
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new User
//                {
//                    Id = 2,
//                    UserName = "MoazAhmed",
//                    Password = "Customer123",
//                    Email = "moaz@example.com",
//                    Phone = "01112345678",
//                    Role = enRole.Coustomer,
//                    IsActive = true,
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new User
//                {
//                    Id = 3,
//                    UserName = "AhmedAli",
//                    Password = "Customer456",
//                    Email = "ahmed@example.com",
//                    Phone = "01212345678",
//                    Role = enRole.Coustomer,
//                    IsActive = true,
//                    CreateBy = "System",
//                    CreateAt = createat
//                }
//            );


//            // =========================
//            // Categories
//            // =========================

//            modelBuilder.Entity<Categore>().HasData(
//                new Categore
//                {
//                    Id = 1,
//                    Name = "Electronics",
//                    Description = "Electronic devices and accessories",
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new Categore
//                {
//                    Id = 2,
//                    Name = "Clothes",
//                    Description = "Men and women clothes",
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new Categore
//                {
//                    Id = 3,
//                    Name = "Home Appliances",
//                    Description = "Home and kitchen appliances",
//                    CreateBy = "System",
//                    CreateAt = createat
//                }
//            );


//            // =========================
//            // Products
//            // =========================

//            modelBuilder.Entity<Product>().HasData(
//                new Product
//                {
//                    Id = 1,
//                    Name = "iPhone 15",
//                    Description = "Apple iPhone 15 128GB",
//                    Price = 45000,
//                    Stock = 10,
//                    IsAvailable = true,
//                    CategoreId = 1,
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new Product
//                {
//                    Id = 2,
//                    Name = "Samsung Galaxy S24",
//                    Description = "Samsung Galaxy S24 256GB",
//                    Price = 35000,
//                    Stock = 15,
//                    IsAvailable = true,
//                    CategoreId = 1,
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new Product
//                {
//                    Id = 3,
//                    Name = "Wireless Headphones",
//                    Description = "Bluetooth wireless headphones",
//                    Price = 2500,
//                    Stock = 30,
//                    IsAvailable = true,
//                    CategoreId = 1,
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new Product
//                {
//                    Id = 4,
//                    Name = "T-Shirt",
//                    Description = "Cotton T-Shirt",
//                    Price = 600,
//                    Stock = 50,
//                    IsAvailable = true,
//                    CategoreId = 2,
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new Product
//                {
//                    Id = 5,
//                    Name = "Coffee Machine",
//                    Description = "Automatic coffee machine",
//                    Price = 5000,
//                    Stock = 8,
//                    IsAvailable = true,
//                    CategoreId = 3,
//                    CreateBy = "System",
//                    CreateAt = createat
//                }
//            );


//            // =========================
//            // Shopping Carts
//            // =========================

//            modelBuilder.Entity<ShoppingCart>().HasData(
//                new ShoppingCart
//                {
//                    Id = 1,
//                    UserId = 2,
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new ShoppingCart
//                {
//                    Id = 2,
//                    UserId = 3,
//                    CreateBy = "System",
//                    CreateAt = createat
//                }
//            );


//            // =========================
//            // Cart Items
//            // =========================

//            modelBuilder.Entity<CartItem>().HasData(
//                new CartItem
//                {
//                    Id = 1,
//                    ShoppingCartId = 1,
//                    ProductId = 1,
//                    quantity = 1,
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new CartItem
//                {
//                    Id = 2,
//                    ShoppingCartId = 1,
//                    ProductId = 3,
//                    quantity = 2,
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new CartItem
//                {
//                    Id = 3,
//                    ShoppingCartId = 2,
//                    ProductId = 4,
//                    quantity = 3,
//                    CreateBy = "System",
//                    CreateAt = createat                }
//            );


//            // =========================
//            // Orders
//            // =========================

//            modelBuilder.Entity<Order>().HasData(
//                new Order
//                {
//                    Id = 1,
//                    UserId = 2,
//                    totalPrice = 50000,
//                    stutes = enStutes.Delivered,
//                    shippingAddress = "Cairo, Egypt",
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new Order
//                {
//                    Id = 2,
//                    UserId = 3,
//                    totalPrice = 1800,
//                    stutes = enStutes.Processing,
//                    shippingAddress = "Giza, Egypt",
//                    CreateBy = "System",
//                    CreateAt = createat
//                }
//            );


//            // =========================
//            // Order Items
//            // =========================

//            modelBuilder.Entity<OrderItem>().HasData(
//                new OrderItem
//                {
//                    Id = 1,
//                    OrderId = 1,
//                    ProductId = 1,
//                    Quantity = 1,
//                    priceAtPurchase = 45000,
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new OrderItem
//                {
//                    Id = 2,
//                    OrderId = 1,
//                    ProductId = 3,
//                    Quantity = 2,
//                    priceAtPurchase = 2500,
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new OrderItem
//                {
//                    Id = 3,
//                    OrderId = 2,
//                    ProductId = 4,
//                    Quantity = 3,
//                    priceAtPurchase = 600,
//                    CreateBy = "System",
//                    CreateAt = createat
//                }
//            );


//            // =========================
//            // Reviews
//            // =========================

//            modelBuilder.Entity<Review>().HasData(
//                new Review
//                {
//                    Id = 1,
//                    UserId = 2,
//                    ProductId = 1,
//                    OrderId = 1,
//                    rate = 9,
//                    comment = "Excellent product and very good quality.",
//                    CreateBy = "System",
//                    CreateAt = createat
//                },

//                new Review
//                {
//                    Id = 2,
//                    UserId = 3,
//                    ProductId = 4,
//                    OrderId = 2,
//                    rate = 8,
//                    comment = "Good quality and comfortable.",
//                    CreateBy = "System",
//                    CreateAt = createat
//                }
//            );
//        }
//    }
//}