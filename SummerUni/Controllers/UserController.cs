using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummerUni.Entities;
using SummerUni.Repositories;

namespace SummerUni.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCartAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _userRepository.SaveUserAsync(user);

            return Ok(user);
        }

        [HttpGet("{userId}")]
        public async Task<User> GetUserAsync(int userId)
        {
            return await _userRepository.GetUserAsync(userId);
        }
        
        [HttpGet]
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        } 
        
    }
}