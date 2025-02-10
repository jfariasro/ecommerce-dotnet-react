using Ecommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Modules.ProductCatalog.Models;

public class Category : BaseEntity
{
    [Column(TypeName = "NVARCHAR(100)")]
    public string? Name { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
}