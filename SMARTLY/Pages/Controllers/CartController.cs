using Microsoft.AspNetCore.Mvc;

namespace SMARTLY.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            // Implement the deletion logic here
            // Delete the item with the specified id from the cart

            // Return appropriate response
            return Ok();
        }
    }
}