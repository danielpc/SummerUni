using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummerUni.Entities;
using SummerUni.Repositories;

namespace SummerUni.Controllers
{
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _userRepository.ListAsync();
            return users;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _userRepository.AddAsync(user);

            return Ok(user);

        }

    }
}