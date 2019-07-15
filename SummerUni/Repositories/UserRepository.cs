using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SummerUni.Entities;

namespace SummerUni.Repositories
{
    public class UserRepository: BaseRepository, IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {
        }

        public async Task SaveUserAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users
                .Include(x => x.Cart)
                .ThenInclude(x => x.Products)
                .ToListAsync();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _context.Users
                .Include(x => x.Cart)
                .ThenInclude(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}