using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummerUni.Entities;
using SummerUni.Repositories;

namespace SummerUni.Controllers
{
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AddOrderAsync(int userId, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _cartRepository.AddProductAsync(userId, product);

            return Ok();
        }
        
        [HttpGet]
        public async Task<IEnumerable<Cart>> ListAsync()
        {
            return await _cartRepository.ListAsync();
        }
    }
}