using Ecommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Modules.Order.Models;

public class ShoppingCartItem : BaseEntity
{
    public string? ProductName { get; set; }

    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string? ProductImage { get; set; }

    public string? CategoryName { get; set; }

    public Guid? ShoppingCartMasterId { get; set; }

    public int ProductId { get; set; }

    public int Stock { get; set; }

    public int ShoppingCartId { get; set; }

    public virtual ShoppingCart ShoppingCart { get; set; }
}
