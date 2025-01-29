using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Modules.Order.Enum;

public enum OrderStatus
{
    [Display(Name = "En Proceso")]
    InProgress = 1,

    [Display(Name = "Completado")]
    Completed = 2,

    [Display(Name = "Enviado")]
    Shipped = 3,

    [Display(Name = "Rechazado")]
    Rejected = 4,
}
