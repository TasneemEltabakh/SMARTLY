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
           
            return Ok();
        }
        public CartController(Database db)
        {
            this.db = db;
        }

            [HttpPost]
        public IActionResult UpdateQuantity([FromBody] QuantityUpdateRequest request)
        {
           
            int id = request.Id;
            int quantity = request.Quantity;

         

            return Ok(); 
        }

        public class QuantityUpdateRequest
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
        }
    }
}