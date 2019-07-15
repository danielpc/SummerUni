using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SummerUni.Entities;

namespace SummerUni.Repositories
{
    public class CartRepository : BaseRepository, ICartRepository
    {
        public CartRepository(ShopContext context) : base(context)
        {
        }
        
        public async Task AddProductAsync(int userId, Product product)
        {
            var user = await _context.Users.FindAsync(userId);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            user.Cart.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(int userId, int productId)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cart>> ListAsync()
        {
            return await _context.Carts.ToListAsync();
        }
    }
}