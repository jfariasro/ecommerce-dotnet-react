using Ecommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Modules.ProductCatalog.Models;

public class Review : BaseEntity
{
    [Column(TypeName = "NVARCHAR(100)")]
    public string? Name { get; set; }

    public int Rating { get; set; }

    [Column(TypeName = "NVARCHAR(5000)")]
    public string? Comment { get; set; }

    public int ProductId { get; set; }
}
