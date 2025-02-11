using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Http;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IMediaService
    {
        Task<Result<string>> UploadImageAsync(IFormFile file);
    }
}
