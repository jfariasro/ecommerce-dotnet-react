using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Modules.ProductCatalog.Enum;

public enum ProductStatus
{
    [Display(Name = "Activo")]
    Active = 1,

    [Display(Name = "Inactivo")]
    Inactive = 2
}
