using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Modules.Order.Models;

public class Country
{
    [Column(TypeName = "NVARCHAR(100)")]
    public string? CountryName { get; set; }

    public string? IsoCode2 { get; set; }

    public string? IsoCode3 { get; set; }
}
