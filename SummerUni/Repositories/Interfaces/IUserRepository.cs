using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SummerUni.Entities;

namespace SummerUni.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<IEnumerable<User>> ListAsync();
    }
}