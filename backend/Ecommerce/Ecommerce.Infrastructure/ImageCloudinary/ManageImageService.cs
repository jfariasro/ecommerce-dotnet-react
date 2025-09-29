using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Ecommerce.Application.Contracts.Infrastructure;
using Ecommerce.Application.Models.ImageManagement;
using Microsoft.Extensions.Options;
using System.Net;

namespace Ecommerce.Infrastructure.ImageCloudinary;

public class ManageImageService : IManageImageService
{
    public ClodinarySettings _clodinarySettings { get; }

    public ManageImageService(IOptions<ClodinarySettings> clodinarySettings)
    {
        _clodinarySettings = clodinarySettings.Value;
    }

    public async Task<ImageResponse> UploadImageAsync(ImageData imageData)
    {
        var account = new Account(
            _clodinarySettings.CloudName,
            _clodinarySettings.ApiKey,
            _clodinarySettings.ApiSecret);

        var cloudinary = new Cloudinary(account);

        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(imageData.FileName, imageData.FileStream),
        };

        var uploadResult = await cloudinary.UploadAsync(uploadParams);

        if (uploadResult.StatusCode == HttpStatusCode.OK)
        {
            return new ImageResponse
            {
                //ImageUrl = uploadResult.Url.ToString(),
                ImageUrl = uploadResult.SecureUrl.AbsoluteUri,
                PublicId = uploadResult.PublicId
            };
        }
        else
        {
            throw new Exception("La imagen no se pudo guardar");
        }
    }
}
