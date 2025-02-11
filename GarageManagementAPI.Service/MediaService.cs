using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using GarageManagementAPI.Service.Contracts;
using Microsoft.Extensions.Options;
using GarageManagementAPI.Entities.ConfigurationModels;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.Constant.Request;
using System.Net;

namespace GarageManagementAPI.Service
{
    public class MediaService : IMediaService
    {
        private readonly Cloudinary _cloudinary;
        private readonly CloudinaryConfigurations _configuration;
        private readonly long _maxFileSize = 10 * 1024 * 1024; // 10 MB

        private static readonly string[] _permittedExtensions = { ".jpg", ".jpeg", ".png" };
        private static readonly string[] _permittedMimeTypes = { "image/jpg", "image/jpeg", "image/png" };

        public MediaService(IOptionsSnapshot<CloudinaryConfigurations> configuration)
        {
            _configuration = configuration.Value;
            var account = new Account(
                _configuration.CloudName,
                _configuration.ApiKey,
                _configuration.ApiSecret
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<Result<string>> UploadImageAsync(IFormFile file, string folderName, string fileName)
        {
            if (file == null || file.Length == 0)
            {
                return Result<string>.BadRequest([RequestErrors.GetFileNotFoundErrors()]);
            }

            if (file.Length > _maxFileSize)
            {
                return Result<string>.BadRequest([RequestErrors.GetFileTooLargeErrors()]);
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || !_permittedExtensions.Contains(extension))
            {
                return Result<string>.BadRequest([RequestErrors.GetFileExtensionInvalidErrors()]);
            }

            if (!_permittedMimeTypes.Contains(file.ContentType.ToLowerInvariant()))
            {
                return Result<string>.BadRequest([RequestErrors.GetFileTypeInvalidErrors()]);
            }

            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, stream),
                UniqueFilename = false,
                Overwrite = true,
                AssetFolder = folderName
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode == HttpStatusCode.OK)
            {
                return Result<string>.Ok(uploadResult.SecureUrl.AbsoluteUri);
            }


            return Result<string>.Failure(HttpStatusCode.InternalServerError, [new()
            {
                Code = "UNKNOWN",
                Description = uploadResult.Error.Message
            }]);
        }

        public async Task<Result> RemoveImage()
        {

            //var uploadResult = await _cloudinary.DeleteRelatedResourcesByAssetIds;

            return Result.Ok();
        }
    }
}
