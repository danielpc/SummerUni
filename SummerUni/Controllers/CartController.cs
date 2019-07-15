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

        [HttpPost("{cartId}")]
        public async Task<IActionResult> CreateCartAsync(int cartId)
        {
            await _cartRepository.SaveCartAsync(cartId);
            return Ok();
        }
        
        [HttpGet]
        public async Task<IEnumerable<Cart>> ListAsync()
        {
            return await _cartRepository.ListAsync();
        }
    }
}