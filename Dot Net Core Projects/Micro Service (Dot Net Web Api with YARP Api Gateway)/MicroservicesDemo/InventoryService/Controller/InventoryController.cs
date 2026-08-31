using InventoryService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace InventoryService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private static readonly List<Inventory> InventoryItems = new()
    {
        new Inventory
        {
            ProductId = 1,
            AvailableQuantity = 10,
            Warehouse = "Lahore"
        },

        new Inventory
        {
            ProductId = 2,
            AvailableQuantity = 25,
            Warehouse = "Islamabad"
        },

        new Inventory
        {
            ProductId = 3,
            AvailableQuantity = 50,
            Warehouse = "Karachi"
        }
    };

        // GET: api/inventory
        [HttpGet]
        [Authorize]
        public IActionResult GetInventory()
        {
            return Ok(InventoryItems);
        }

        // GET: api/inventory/1
        [HttpGet("{productId}")]
        [Authorize]
        public IActionResult GetInventoryByProductId(int productId)
        {
            var inventory = InventoryItems
                .FirstOrDefault(x => x.ProductId == productId);

            if (inventory == null)
            {
                return NotFound(new
                {
                    message = "Inventory not found"
                });
            }

            return Ok(inventory);
        }

        [HttpPut("{productId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateInventory(int productId)
        {
            return Ok($"Inventory updated for product {productId}");
        }
    }
}
