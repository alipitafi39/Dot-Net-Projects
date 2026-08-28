using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

namespace ClientService.Controllers;

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

    // GET: api/products
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        // Create HttpClient
        var client =
            _httpClientFactory.CreateClient("ApiGateway");

        // Call API Gateway
        var response =
            await client.GetAsync("api/products");

        // Check response
        if (!response.IsSuccessStatusCode)
        {
            var error =
                await response.Content.ReadAsStringAsync();

            return StatusCode(
                (int)response.StatusCode,
                error);
        }

        // Convert JSON to C# object
        var products =
            await response.Content
                .ReadFromJsonAsync<List<ProductDto>>();

        return Ok(products);
    }

    // GET: api/products/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var client =
            _httpClientFactory.CreateClient("ApiGateway");

        var response =
            await client.GetAsync($"api/products/{id}");

        if (!response.IsSuccessStatusCode)
        {
            var error =
                await response.Content.ReadAsStringAsync();

            return StatusCode(
                (int)response.StatusCode,
                error);
        }

        var product =
            await response.Content
                .ReadFromJsonAsync<ProductDto>();

        return Ok(product);
    }
}

public class ProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}