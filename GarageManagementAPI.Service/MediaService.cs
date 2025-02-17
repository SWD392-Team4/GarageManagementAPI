using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using GarageManagementAPI.Service.Contracts;
using Microsoft.Extensions.Options;
using GarageManagementAPI.Entities.ConfigurationModels;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.Constant.Request;
using System.Net;
using System.Data;

namespace GarageManagementAPI.Service
{
    public class MediaService : IMediaService
    {
        private readonly Cloudinary _cloudinary;
        private readonly CloudinaryConfigurations _configuration;
        private readonly long _maxFileSize = 10 * 1024 * 1024; // 10 MB

        private static readonly string[] _permittedExtensions = { ".jpg", ".jpeg", ".png" };
        private static readonly string[] _permittedMimeTypes = { "image/jpg", "image/jpeg", "image/png" };

        private const string _userFolder = "User";
        private const string _productFolder = "Product";
        private const string _errorCode = "CloudinaryError";

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

        private async Task<Result<(string? publicId, string? absoluteUrl)>> UploadImageAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
            {
                return Result<(string? publicId, string? absoluteUrl)>.BadRequest([RequestErrors.GetFileNotFoundErrors()]);
            }

            if (file.Length > _maxFileSize)
            {
                return Result<(string? publicId, string? absoluteUrl)>.BadRequest([RequestErrors.GetFileTooLargeErrors()]);
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || !_permittedExtensions.Contains(extension))
            {
                return Result<(string? publicId, string? absoluteUrl)>.BadRequest([RequestErrors.GetFileExtensionInvalidErrors()]);
            }

            if (!_permittedMimeTypes.Contains(file.ContentType.ToLowerInvariant()))
            {
                return Result<(string? publicId, string? absoluteUrl)>.BadRequest([RequestErrors.GetFileTypeInvalidErrors()]);
            }

            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream),
                UniqueFilename = true,
                Overwrite = true,
                AssetFolder = folderName,
                UseAssetFolderAsPublicIdPrefix = true
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode == HttpStatusCode.OK)
            {
                return Result<(string? publicId, string? absoluteUrl)>.Ok((publicId: uploadResult.PublicId, absoluteUrl: uploadResult.SecureUrl.AbsoluteUri));
            }

            return Result<(string? publicId, string? absoluteUrl)>.Failure(uploadResult.StatusCode, [new()
            {
                Code = _errorCode,
                Description = uploadResult.Error.Message
            }]);
        }

        public async Task<Result<(string? publicId, string? absoluteUrl)>> UploadUserImageAsync(IFormFile file)
            => await UploadImageAsync(file, _userFolder);

        public async Task<Result<(string? publicId, string? absoluteUrl)>> UploadProductImageAsync(IFormFile file)
            => await UploadImageAsync(file, _productFolder);

        public async Task<Result<string>> RemoveImage(string publicId)
        {

            var deletionParams = new DeletionParams(publicId)
            {
                ResourceType = ResourceType.Image

            };

            var result = await _cloudinary.DestroyAsync(deletionParams);

            if (result.Error != null)
            {
                return Result<string>.Failure(result.StatusCode, [new()
                {
                    Code = _errorCode,
                    Description = result.Error.Message
                }]);
            }

            return Result<string>.Ok(result.Result);
        }

    }
}
