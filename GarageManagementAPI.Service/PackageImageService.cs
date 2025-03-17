using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.PackageImage;
using GarageManagementAPI.Shared.ErrorsConstant.Package;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Shared.ErrorsConstant.PackageImages;

namespace GarageManagementAPI.Service
{
    public class PackageImageService : IPackageImageService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public PackageImageService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<IEnumerable<PackageImageDto>>> CreatePackageImageAsync(Guid packageId, IEnumerable<(string? ImageId, string? ImageLink)> imageTuples)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, trackChanges: false);
            if (package is null)
                return Result<IEnumerable<PackageImageDto>>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageImages = new List<PackageImage>();
            foreach (var imageItem in imageTuples)
            {
                var packageImage = new PackageImage
                {
                    PackageId = packageId,
                    ImageLink = imageItem.ImageLink,
                    ImageId = imageItem.ImageId
                };
                packageImages.Add(packageImage);
            }
            await _repoManager.PackageImage.CreatesAsync(packageImages.ToArray());
            await _repoManager.SaveAsync();

            var packageImagesDto = _mapper.Map<IEnumerable<PackageImageDto>>(packageImages);

            return Result<IEnumerable<PackageImageDto>>.Ok(packageImagesDto);
        }

        public async Task<Result<PackageImageDto>> GetPackageImageByIdAsync(Guid packageId, Guid id)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, trackChanges: false);
            if (package is null)
                return Result<PackageImageDto>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageImage = await _repoManager.PackageImage.GetPackageImageByIdAsync(packageId, id, trackChanges: false);
            if (packageImage is null)
                return Result<PackageImageDto>.NotFound(PackageImageErrors.GetPackageImageNotFoundError(id));

            var packageImageDto = _mapper.Map<PackageImageDto>(packageImage);

            return Result<PackageImageDto>.Ok(packageImageDto);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetPackageImageByPackageIdAsync(Guid packageId, PackageImageParameters packageImageParameters)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, trackChanges: false);
            if (package is null)
                return Result<IEnumerable<ExpandoObject>>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageImages = await _repoManager.PackageImage.GetPackageImagesByPackageIdAsync(packageId, trackChanges: false, packageImageParameters);

            var packageImageDtos = _mapper.Map<IEnumerable<PackageImageDto>>(packageImages);

            var packageImageShaped = _dataShaper.PackageImage.ShapeData(packageImageDtos, packageImageParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(packageImageShaped, packageImages.MetaData);
        }

        public async Task<Result<IEnumerable<PackageImageDto>>> GetPackageImageByPackageIdAsync(Guid packageId)
        {
            var packageImages = await _repoManager.PackageImage.FindByCondition(e => e.PackageId.Equals(packageId), trackChanges: false).ToListAsync();

            if (!packageImages.Any())
                return Result<IEnumerable<PackageImageDto>>.NotFound(PackageImageErrors.GetPackageImageNotFoundError(packageId));

            var packageImageDtos = _mapper.Map<IEnumerable<PackageImageDto>>(packageImages);

            return Result<IEnumerable<PackageImageDto>>.Ok(packageImageDtos);
        }

        public async Task<Result> RemoveAllPackageImageOfPackageAsync(Guid packageId)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, trackChanges: false);
            if (package is null)
                return Result<IEnumerable<PackageImageDto>>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageImages = await _repoManager.PackageImage.GetPackageImagesByPackageIdAsync(packageId, trackChanges: false);

            if (!packageImages.Any())
                return Result.Ok();

            _repoManager.PackageImage.Deletes(packageImages.ToArray());
            await _repoManager.SaveAsync();

            return Result.Ok();
        }

        public async Task<Result> RemovePackageImageAsync(Guid packageId, Guid packageImageId)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, trackChanges: false);
            if (package is null)
                return Result.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageImage = await _repoManager.PackageImage.GetPackageImageByIdAsync(packageId, packageImageId, trackChanges: false);

            if (packageImage is null)
                return Result.NotFound(PackageImageErrors.GetPackageImageNotFoundError(packageImageId));

            _repoManager.PackageImage.Delete(packageImage);
            await _repoManager.SaveAsync();

            return Result.Ok();
        }
    }
}
