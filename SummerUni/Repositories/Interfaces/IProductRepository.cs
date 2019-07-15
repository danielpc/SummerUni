using System.Collections.Generic;
using System.Threading.Tasks;
using SummerUni.Entities;

namespace SummerUni.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddProductAsync(Product product);
    }
}