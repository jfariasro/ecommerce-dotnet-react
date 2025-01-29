using Ecommerce.Domain.Common;
using Ecommerce.Domain.Modules.ProductCatalog.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Modules.Order.Models;

public class OrderItem : BaseEntity
{
    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int? CartItemId { get; set; }
    public ShoppingCartItem? CartItem { get; set; }
}
