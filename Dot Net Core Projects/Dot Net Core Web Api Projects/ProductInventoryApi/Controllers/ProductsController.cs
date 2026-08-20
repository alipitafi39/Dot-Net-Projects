using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using ProductInventoryApi.Dtos;
using ProductInventoryApi.Models;

namespace ProductInventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableRateLimiting("fixed")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductInventoryDbContext _context;

        public ProductsController(ProductInventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            return Ok(products);

            //      var products = await _context.Products
            //.Select(p => new ProductDto
            //{
            //    ProductId = p.ProductId,
            //    CategoryId = p.CategoryId,
            //    ProductName = p.ProductName,
            //    Price = p.Price,
            //    Quantity = p.Quantity,
            //    SupplierName = p.SupplierName,
            //    CreatedDate = p.CreatedDate,
            //    CategoryName = p.Category.CategoryName
            //})
            //.ToListAsync();

            //      return Ok(products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.ProductId },
                product
            );
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(
            int id,
            Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest(new
                {
                    message = "Product ID mismatch"
                });
            }

            var existingProduct = await _context.Products
                .FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
            existingProduct.SupplierName = product.SupplierName;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products
                .FindAsync(id);

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}