using System.Collections.Generic;
using System.Threading.Tasks;
using SummerUni.Entities;

namespace SummerUni.Repositories
{
    public interface IUserRepository
    {
        Task SaveUserAsync(User user);
        Task<IEnumerable<User>> ListAsync();
        Task<User> GetUserAsync(int userId);
    }
}