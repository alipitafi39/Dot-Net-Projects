namespace ProductInventoryApi.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? SupplierName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CategoryName { get; set; }
    }
}
