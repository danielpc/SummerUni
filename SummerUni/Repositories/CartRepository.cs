using System.Collections.Generic;
using System.Linq;
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


        public async Task SaveCartAsync(int id)
        {
            await _context.Carts.AddAsync(new Cart {Id = id});
            await _context.SaveChangesAsync();
        }

        public async Task AddProductAsync(int id, Product product)
        {
            var user = await _context.Users
                .Include(x => x.Cart)
                .ThenInclude(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);
            user.Cart.Products.Add(product);
            
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(int id, int productId)
        {
            var user = await _context.Users
                .Include(x => x.Cart)
                .ThenInclude(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);
            user.Cart.Products.Remove(_context.Products.Find(productId));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cart>> ListAsync()
        {
            return await _context.Carts.Include(x => x.Products).ToListAsync();
        }
    }
}