using Ecommerce.Domain.Common;
using Ecommerce.Domain.Modules.ProductCatalog.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Modules.ProductCatalog.Models;

public class Product : BaseEntity
{
    [Column(TypeName = "NVARCHAR(100)")]
    public string? Name { get; set; }

    [Column(TypeName = "NVARCHAR(5000)")]
    public string? Description { get; set; }

    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal Price { get; set; }

    public int Rating { get; set; }

    [Column(TypeName = "NVARCHAR(100)")]
    public string? Seller {  get; set; }

    public int Stock { get; set; }

    public ProductStatus ProductStatus { get; set; } = ProductStatus.Active;

    public int CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Review>? Reviews { get; set; }

    public virtual ICollection<ProductImage>? ProductImages { get; set; }
}