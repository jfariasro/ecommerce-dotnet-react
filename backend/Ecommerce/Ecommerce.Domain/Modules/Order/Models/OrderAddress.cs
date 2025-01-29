using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Modules.Order.Models;

public class OrderAddress : BaseEntity
{
    public string? Name { get; set; }

    public string? City { get; set; }

    public string? Department { get; set; }

    public string? PostalCode { get; set; }

    public string? ContactName { get; set; }

    public string? Country { get; set; }
}
