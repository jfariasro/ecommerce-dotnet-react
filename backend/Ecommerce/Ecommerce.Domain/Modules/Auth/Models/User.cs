using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain.Modules.Auth.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;
}
