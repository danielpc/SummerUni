using System.Collections.Generic;
using System.Threading.Tasks;
using SummerUni.Entities;

namespace SummerUni.Repositories
{
    public interface ICartRepository
    {
        Task AddProductAsync(int userId, Product product);
        Task RemoveProductAsync(int userId, int productId);
        Task<IEnumerable<Cart>> ListAsync();
    }
}