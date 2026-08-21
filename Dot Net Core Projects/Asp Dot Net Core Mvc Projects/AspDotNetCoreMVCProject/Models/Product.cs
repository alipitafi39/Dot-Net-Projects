using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspDotNetCoreMVCProject.Models;

public partial class Product
{
    public int ProductId { get; set; }

    [Required]
    [StringLength(150)]
    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string? SupplierName { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Category Category { get; set; } = null!;
}
