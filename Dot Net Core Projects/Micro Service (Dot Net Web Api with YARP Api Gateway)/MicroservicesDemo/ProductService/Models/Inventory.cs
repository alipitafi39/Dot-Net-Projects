namespace ProductService.Models
{
    public class Inventory
    {
        public int ProductId { get; set; }

        public int AvailableQuantity { get; set; }

        public string Warehouse { get; set; } = string.Empty;
    }
}
