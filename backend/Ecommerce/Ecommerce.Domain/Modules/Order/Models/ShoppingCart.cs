using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Modules.Order.Models;

public class ShoppingCart : BaseEntity
{
    public Guid? ShoppingCartMasterId { get; set; }

    public virtual ICollection<ShoppingCartItem>? ShoppingCartItems { get; set; }
}
