using E_commerce_API.Data;
using E_commerce_API.DTOs.ShoppingCart;
using E_commerce_API.Models;
using E_commerce_API.Services.Audit;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_API.Services.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public ShoppingCartService(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<ShoppingCartDto> GetMyCart()
        {
            var userid = _currentUserService.UserId;

            var cart = await _context.ShoppingCarts
               .Where(s => s.UserId == userid.Value)
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
                return false;
            }


            var product = await _context.Products
                .Where(x => x.Id == id)
                .Select(s => new { s.Id, s.Stock })
                .FirstOrDefaultAsync();


            if (product == null || quantity> product.Stock)
            {
                return false;
            }



            var userid = _currentUserService.UserId;

            var shopcart = await _context.ShoppingCarts
                .Where(x=>x.UserId == userid.Value)
                .Select(x=>x.Id)
                .FirstOrDefaultAsync();



            //بشوف في product موجود ف نفس ال shopcart 
            var foundProductinitem = await _context.CartItems
                .FirstOrDefaultAsync(x=> x.ProductId==product.Id && x.ShoppingCartId == shopcart);

            if (foundProductinitem != null)
            {
                if (foundProductinitem.quantity + quantity > product.Stock)
                {
                    return false;
                }

                foundProductinitem.quantity += quantity;
                await _context.SaveChangesAsync();
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
            return true;

        }




        public async Task<bool> UpdateQuantity(int Productid, int quantity)
        {

            if (Productid < 1 || quantity < 1)
            {
                return false;
            }


            var product = await _context.Products
                .Where(x => x.Id == Productid)
                .Select(s => new { s.Id, s.Stock })
                .FirstOrDefaultAsync();


            if (product == null || quantity > product.Stock)
            {
                return false;
            }



            var userid = _currentUserService.UserId;

            var shopcart = await _context.ShoppingCarts
                .Where(x => x.UserId == userid.Value)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            var foundProductinitem = await _context.CartItems
               .FirstOrDefaultAsync(x => x.ProductId == product.Id && x.ShoppingCartId == shopcart);

            if (foundProductinitem == null)
            {
                return false;
            }

            foundProductinitem.quantity = quantity;
            await _context.SaveChangesAsync();


            return true;
        }



        public async Task<bool> DeleteProduct(int ProductId)
        {
            if(ProductId< 1)
            {
                return false;
            }

            var userid = _currentUserService.UserId.Value;

            var shopcart = await _context.ShoppingCarts
               .Where(x => x.UserId == userid)
               .Select(x => x.Id)
               .FirstOrDefaultAsync();




            var result = await _context.CartItems
                .FirstOrDefaultAsync(x=> x.ProductId == ProductId &&  x.ShoppingCartId == shopcart);

            if (result == null)
            {
                return false;
            }

            _context.CartItems.Remove(result);           // hard deleted
            await _context.SaveChangesAsync();

            return true;
        }



        public async Task<bool> ClearCart()
        {
            var userid = _currentUserService.UserId.Value;

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

            return true;
        }
    }
}
