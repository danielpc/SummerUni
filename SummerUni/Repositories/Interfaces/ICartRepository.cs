using System.Collections.Generic;
using System.Threading.Tasks;
using SummerUni.Entities;

namespace SummerUni.Repositories
{
    public interface ICartRepository
    {
        Task SaveCartAsync(int id);
        Task AddProductAsync(int id, Product product);
        Task RemoveProductAsync(int id, int productId);
        Task<IEnumerable<Cart>> ListAsync();
    }
}