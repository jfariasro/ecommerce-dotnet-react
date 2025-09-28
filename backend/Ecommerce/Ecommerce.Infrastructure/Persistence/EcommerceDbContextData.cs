using Ecommerce.Application.Models.Auth;
using Ecommerce.Domain.Modules.Auth.Models;
using Ecommerce.Domain.Modules.Order.Models;
using Ecommerce.Domain.Modules.ProductCatalog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ecommerce.Infrastructure.Persistence;

public class EcommerceDbContextData
{
    public static async Task LoadDataAsync(
        EcommerceDbContext context,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        ILoggerFactory loggerFactory)
    {
        try
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(PermissionRole.Admin));
                await roleManager.CreateAsync(new IdentityRole(PermissionRole.User));
            }

            if (!userManager.Users.Any())
            {
                var userAdmin = new User
                {
                    FirstName = "Juan",
                    LastName = "Perez",
                    UserName = "juan.perez",
                    Email = "juan@gmail.com",
                    PhoneNumber = "1234567890",
                    ImageUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/vaxidrez.jpg?alt=media&token=14a28860-d149-461e-9c25-9774d7ac1b24",
                };

                await userManager.CreateAsync(userAdmin, "LolamentoDmejoras190*");

                await userManager.AddToRoleAsync(userAdmin, PermissionRole.Admin);

                var user = new User
                {
                    FirstName = "Lucía",
                    LastName = "Gómez",
                    UserName = "lucia.gomez",
                    Email = "lucia@gmail.com",
                    PhoneNumber = "0987654321",
                    ImageUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/avatar-1.webp?alt=media&token=58da3007-ff21-494d-a85c-25ffa758ff6d",
                };

                await userManager.CreateAsync(user, "AdminLuci@2025");

                await userManager.AddToRoleAsync(user, PermissionRole.User);

            }

            if (!context.Categories.Any())
            {
                var categoryData = File.ReadAllText("../Ecommerce.Infrastructure/Data/category.json");
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                if (categories is not null)
                {
                    await context.Categories.AddRangeAsync(categories);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Products.Any())
            {
                var productData = File.ReadAllText("../Ecommerce.Infrastructure/Data/product.json");
                var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                if (products is not null)
                {
                    await context.Products.AddRangeAsync(products);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.ProductImages.Any())
            {
                var productImageData = File.ReadAllText("../Ecommerce.Infrastructure/Data/image.json");
                var productImages = JsonConvert.DeserializeObject<List<ProductImage>>(productImageData);
                if (productImages is not null)
                {
                    await context.ProductImages.AddRangeAsync(productImages);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Country.Any())
            {
                var countryData = File.ReadAllText("../Ecommerce.Infrastructure/Data/countries.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);
                if (countries is not null)
                {
                    await context.Country.AddRangeAsync(countries);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Reviews.Any())
            {
                var reviewData = File.ReadAllText("../Ecommerce.Infrastructure/Data/review.json");
                var reviews = JsonConvert.DeserializeObject<List<Review>>(reviewData);
                if (reviews is not null)
                {
                    await context.Reviews.AddRangeAsync(reviews);
                    await context.SaveChangesAsync();
                }
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<EcommerceDbContextData>();
            logger.LogError(ex, "Se produjo un error al cargar los datos iniciales en la base de datos.");
            throw;
        }
    }
}
