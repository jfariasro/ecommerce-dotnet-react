using Ecommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Modules.ProductCatalog.Models;

public class ProductImage : BaseEntity
{
    [Column(TypeName = "NVARCHAR(5000)")]
    public string? Url { get; set; }

    public int ProductId { get; set; }

    public string? PublicCode { get; set; }
}
