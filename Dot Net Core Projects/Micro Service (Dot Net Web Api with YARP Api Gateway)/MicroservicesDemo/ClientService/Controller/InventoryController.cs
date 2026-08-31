using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

namespace ClientService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public InventoryController(
        IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: api/inventory/1
    [HttpGet("{productId}")]
    public async Task<IActionResult> GetInventory(int productId)
    {
        // Create HttpClient
        var client =
            _httpClientFactory.CreateClient("ApiGateway");

        // Call Gateway
        var response =
            await client.GetAsync(
                $"api/inventory/{productId}");

        // Check response
        if (!response.IsSuccessStatusCode)
        {
            var error =
                await response.Content.ReadAsStringAsync();

            return StatusCode(
                (int)response.StatusCode,
                error);
        }

        // Convert JSON to C#
        var inventory =
            await response.Content
                .ReadFromJsonAsync<InventoryDto>();

        return Ok(inventory);
    }
}

public class InventoryDto
{
    public int ProductId { get; set; }

    public int AvailableQuantity { get; set; }

    public string Warehouse { get; set; } = string.Empty;
}