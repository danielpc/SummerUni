using SummerUni.Entities;

namespace SummerUni.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ShopContext _context;

        public BaseRepository(ShopContext context)
        {
            _context = context;
        }
    }
}