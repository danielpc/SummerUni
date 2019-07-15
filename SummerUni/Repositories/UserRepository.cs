using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SummerUni.Entities;

namespace SummerUni.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {
        }
        
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        
    }
}