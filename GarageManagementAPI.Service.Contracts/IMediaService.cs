using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Http;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IMediaService
    {
        Task<Result<(string? publicId, string? absoluteUrl)>> UploadUserImageAsync(IFormFile file);

        Task<Result<string>> RemoveImage(string publicId);
    }
}
