using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummerUni.Entities;
using SummerUni.Repositories;

namespace SummerUni.Controllers
{
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public ShopController(ICartRepository cartRepository)
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

        [HttpDelete("{userId}/{productId}")]
        public async Task<IActionResult> RemoveProductAsync(int userId, int productId)
        {
            await _cartRepository.RemoveProductAsync(userId, productId);
            return Ok();
        }
    }
}