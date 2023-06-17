using Microsoft.AspNetCore.Mvc;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly Database db;
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            // Implement the deletion logic here
            // Delete the item with the specified id from the cart

            // Return appropriate response
            return Ok();
        }
        public CartController(Database db)
        {
            this.db = db;
        }

            [HttpPost]
        public IActionResult UpdateQuantity([FromBody] QuantityUpdateRequest request)
        {
            // Get the ID and quantity from the request
            int id = request.Id;
            int quantity = request.Quantity;

           // db.UpdateCart(id, quantity,user);

         

            return Ok(); // Return an HTTP 200 OK response to indicate success
        }

        public class QuantityUpdateRequest
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
        }
    }
}