using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Http;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IMediaService
    {
        Task<Result<(string? publicId, string? absoluteUrl)>> UploadUserImageAsync(IFormFile file);
        Task<Result<(string? publicId, string? absoluteUrl)>> UploadProductImageAsync(IFormFile file);
        Task<Result<(string? publicId, string? absoluteUrl)>> UploadServiceImageAsync(IFormFile file);
        Task<Result<(string? publicId, string? absoluteUrl)>> UploadBrandImageAsync(IFormFile file);
        Task<Result<(string? publicId, string? absoluteUrl)>> UploadPackageImageAsync(IFormFile file);
        Task<Result<string>> RemoveImage(string publicId);
    }
}
