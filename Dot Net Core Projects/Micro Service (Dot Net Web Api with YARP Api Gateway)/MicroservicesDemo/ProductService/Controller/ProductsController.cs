using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using System.Net.Http.Headers;

namespace ProductService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsController(
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private static readonly List<Product> Products = new()
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 1200,
                Quantity = 10
            },

            new Product
            {
                Id = 2,
                Name = "Keyboard",
                Price = 80,
                Quantity = 25
            },

            new Product
            {
                Id = 3,
                Name = "Mouse",
                Price = 40,
                Quantity = 50
            }
        };

        // GET: api/products
        [HttpGet]
        [Authorize]
        public IActionResult GetProducts()
        {
            return Ok(Products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetProduct(int id)
        {
            // ==========================================
            // 1. Get Product
            // ==========================================

            var product = new Product
            {
                Id = id,
                Name = "Laptop",
                Price = 1000
            };


            // ==========================================
            // 2. Get JWT from incoming request
            // ==========================================

            var authorizationHeader =
                Request.Headers.Authorization.ToString();


            // ==========================================
            // 3. Create HttpClient
            // ==========================================

            var client =
                _httpClientFactory
                    .CreateClient("InventoryService");


            // ==========================================
            // 4. Forward JWT to InventoryService
            // ==========================================

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                client.DefaultRequestHeaders.Authorization =
                    AuthenticationHeaderValue.Parse(
                        authorizationHeader);
            }


            // ==========================================
            // 5. Call InventoryService
            // ==========================================

            var response =
                await client.GetAsync(
                    $"/api/inventory/{id}");


            // ==========================================
            // 6. Check response
            // ==========================================

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode(
                    (int)response.StatusCode,
                    "InventoryService call failed");
            }


            // ==========================================
            // 7. Read inventory response
            // ==========================================

            var inventory =
                await response.Content
                    .ReadFromJsonAsync<Inventory>();


            // ==========================================
            // 8. Return combined response
            // ==========================================

            return Ok(new
            {
                Product = product,

                Inventory = inventory
            });
        }

        // POST: api/products
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct(Product product)
        {
            product.Id = Products.Count + 1;

            Products.Add(product);

            return Ok(product);
        }
    }
}
