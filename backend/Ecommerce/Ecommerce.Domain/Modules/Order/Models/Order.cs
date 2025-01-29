using Ecommerce.Domain.Common;
using Ecommerce.Domain.Modules.Order.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Modules.Order.Models;

public class Order : BaseEntity
{
    public Order()
    {
    }

    public Order(
        string? customerName,
        string? customerUserName,
        OrderAddress? orderAddress,
        decimal subtotal,
        decimal total,
        decimal tax,
        decimal shippingPrice)
    {
        CustomerName = customerName;
        CustomerUserName = customerUserName;
        OrderAddress = orderAddress;
        Subtotal = subtotal;
        Total = total;
        Tax = tax;
        ShippingPrice = shippingPrice;
    }

    public string? CustomerName { get; set; }

    public string? CustomerUserName { get; set; }

    public OrderAddress? OrderAddress { get; set; }

    public IReadOnlyList<OrderItem>? OrderItems { get; set; }

    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal Subtotal { get; set; }

    public OrderStatus OrderStatus { get; set; } = OrderStatus.InProgress;

    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal Total { get; set; }

    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal Tax { get; set; }

    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal ShippingPrice { get; set; }

    public string? PaymentIntentId { get; set; }

    public string? ClientSecret { get; set; }

    public string? ApiKey { get; set; }
}
