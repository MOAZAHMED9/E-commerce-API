using E_commerce_API.Data;
using E_commerce_API.DTOs.ShoppingCart;
using E_commerce_API.DTOs.Order;
using E_commerce_API.Models;
using E_commerce_API.Services.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderItem = E_commerce_API.Models.OrderItem;
using E_commerce_API.Exception;

namespace E_commerce_API.Services.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger<ShoppingCartService> _logger;

        public ShoppingCartService(AppDbContext context, ICurrentUserService currentUserService, ILogger<ShoppingCartService> logger)
        {
            _context = context;
            _currentUserService = currentUserService;
            _logger = logger;
        }

        public async Task<ShoppingCartDto> GetMyCart()
        {
            var userid = _currentUserService.UserId;

            var cart = await _context.ShoppingCarts
               .Where(s => s.UserId == userid)
               .Select(s => new ShoppingCartDto
               {
                   Items = s.CartItems
                    .Select(i => new CartItemDto
                    {
                        productId = i.ProductId,
                        productName = i.Product.Name,
                        Quantity = i.quantity
                    })
                .ToList()
               })
               .FirstOrDefaultAsync();


            return cart;
        }




        public async Task<bool> AddProduct(int id, int quantity)
        {


            if (id < 1 || quantity < 1)
            {
                throw new BadRequestException("Invalid product ID or quantity.");
            }


            var product = await _context.Products
                .Where(x => x.Id == id && x.IsAvailable)
                .Select(s => new { s.Id, s.Stock })
                .FirstOrDefaultAsync();


            if (product == null || quantity > product.Stock)
            {
                throw new NotFoundException("Product not available or insufficient stock.");
            }



            var userid = _currentUserService.UserId;

            var shopcart = await _context.ShoppingCarts
                .Where(x => x.UserId == userid)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();



            //بشوف في product موجود ف نفس ال shopcart 
            var foundProductinitem = await _context.CartItems
                .FirstOrDefaultAsync(x => x.ProductId == product.Id && x.ShoppingCartId == shopcart);

            if (foundProductinitem != null)
            {
                if (foundProductinitem.quantity + quantity > product.Stock)
                {
                    throw new BadRequestException("Adding this quantity exceeds available stock.");
                }

                foundProductinitem.quantity += quantity;
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Product with ID: {product.Id} quantity updated in cart for user ID: {userid}");

                return true;
            }




            var cartitem = new CartItem
            {
                ProductId = product.Id,
                quantity = quantity,
                ShoppingCartId = shopcart
            };

            await _context.CartItems.AddAsync(cartitem);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product with ID: {product.Id} added to cart for user ID: {userid}");
            return true;

        }




        public async Task<bool> UpdateQuantity(int Productid, int quantity)
        {

            if (Productid < 1 || quantity < 1)
            {
                throw new BadRequestException("Invalid product ID or quantity.");
            }


            var product = await _context.Products
                .Where(x => x.Id == Productid && x.IsAvailable)
                .Select(s => new { s.Id, s.Stock })
                .FirstOrDefaultAsync();


            if (product == null || quantity > product.Stock)
            {
                throw new NotFoundException("Product not available or insufficient stock.");
            }



            var userid = _currentUserService.UserId;

            var shopcart = await _context.ShoppingCarts
                .Where(x => x.UserId == userid)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            var foundProductinitem = await _context.CartItems
               .FirstOrDefaultAsync(x => x.ProductId == product.Id && x.ShoppingCartId == shopcart);

            if (foundProductinitem == null)
            {
                throw new NotFoundException("Product not found in cart.");
            }

            foundProductinitem.quantity = quantity;
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product with ID: {product.Id} quantity updated to {quantity} in cart for user ID: {userid}");


            return true;
        }



        public async Task<bool> DeleteProduct(int ProductId)
        {
            if (ProductId < 1)
            {
                throw new BadRequestException("Invalid product ID.");
            }

            var userid = _currentUserService.UserId;

            var shopcart = await _context.ShoppingCarts
               .Where(x => x.UserId == userid)
               .Select(x => x.Id)
               .FirstOrDefaultAsync();




            var result = await _context.CartItems
                .FirstOrDefaultAsync(x => x.ProductId == ProductId && x.ShoppingCartId == shopcart);

            if (result == null)
            {
                throw new NotFoundException("Product not found in cart.");
            }

            _context.CartItems.Remove(result);           // hard deleted
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product with ID: {ProductId} removed from cart for user ID: {userid}");

            return true;
        }



        public async Task<bool> ClearCart()
        {
            var userid = _currentUserService.UserId;

            var shopcart = await _context.ShoppingCarts
               .Where(x => x.UserId == userid)
               .Select(x => x.Id)
               .FirstOrDefaultAsync();


            var result = await _context.CartItems
                .Where(x => x.ShoppingCartId == shopcart)
                .ToListAsync();

            if (result == null)
            {
                return true;
            }

            _context.CartItems.RemoveRange(result);           // hard deleted
            await _context.SaveChangesAsync();
            _logger.LogInformation($"All products removed from cart for user ID: {userid}");

            return true;
        }



        public async Task<OrderDto?> CheckoutAsync(string address)
        {

            using var transaction = await _context.Database.BeginTransactionAsync(); // لو حصل اي error في اي حاجه بعد ما عملت ال checkout  و قبل ما اعمل save changes  هيعمل rollback و يرجع كل حاجه زي ما كانت قبل ال checkout

            try
            {
                var userid = _currentUserService.UserId.Value;


                var shopcart = await _context.ShoppingCarts
                   .Where(x => x.UserId == userid)
                   .FirstOrDefaultAsync();

                var result = await _context.CartItems
                     .Where(x => x.ShoppingCartId == shopcart.Id)
                     .Include(x => x.Product)                     //لو جبت الكارت ايتيم من غيرها . النفجيشن مش هيكون محمل الداتا بتاعتها 
                     .ToListAsync();
                


                if (result.IsNullOrEmpty())
                {
                    throw new BadRequestException("Cart is empty.");
                }

                // حلينا مشكله ال N+1 query problem  لما جبت الكارت ايتيم من غير ال include  و بعدين كل كارت ايتيم عملت عليه access لل product  كل واحد فيهم عمل query لوحده و ده هيزود ال queries علي الداتا بيز  و هيبطئ الاداء
                foreach (var item in result)
                {
                    if (item.Product == null)
                    {
                        throw new NotFoundException($"Product with ID {item.ProductId} not found.");
                    }

                    if (!item.Product.IsAvailable)
                    {
                        throw new BadRequestException($"Product with ID {item.ProductId} is not available.");
                    }

                    if (item.quantity > item.Product.Stock)
                    {
                        throw new BadRequestException($"Not enough stock for product {item.ProductId}. Requested: {item.quantity}, Available: {item.Product.Stock}.");
                    }
                }





                var totalprice = 0m;
                foreach (var item in result)
                {
                    totalprice += item.Product.Price * item.quantity;
                }


                var order = new Models.Order
                {
                    totalPrice = totalprice,
                    stutes = enStutes.Pending,
                    shippingAddress = address,
                    UserId = userid

                };
                await _context.Order.AddAsync(order);

                foreach (var item in result)
                {
                    var orderitem = new OrderItem
                    {
                        Quantity = item.quantity,
                        priceAtPurchase = item.Product.Price,
                        ProductId = item.ProductId,
                        Order = order,                                 ////// 

                    };
                    await _context.OrderItems.AddAsync(orderitem);
                }
                

                foreach (var item in result)
                {
                    
                    var affected = await _context.Products
                    .Where(p => p.Id == item.ProductId && p.IsAvailable && p.Stock >= item.quantity)

                    .ExecuteUpdateAsync(s => s.SetProperty(p => p.Stock, p => p.Stock - item.quantity)); ///////////????

                    if (affected == 0)
                    {
                        throw new BadRequestException($"Not enough stock for product {item.ProductId}");
                    }
                }

                _context.CartItems.RemoveRange(result);           // hard deleted

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
              
                _logger.LogInformation($"Checkout completed for user ID: {userid}, Order ID: {order.Id}, Total Price: {totalprice}");
                
                return new OrderDto { Id = order.Id, Address = order.shippingAddress, userId = order.UserId, totalPrice = order.totalPrice, stutes = order.stutes };
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Checkout failed for user ID: {UserId}", _currentUserService.UserId);

                await transaction.RollbackAsync();

                throw;
            }

        }
    }
}
