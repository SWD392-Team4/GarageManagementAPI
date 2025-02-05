﻿using AutoMapper;
using GarageManagementAPI.Entities.ConfigurationModels;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace GarageManagementAPI.Service
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<IWorkplaceService> _workplaceService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<IEmployeeInfoService> _employeeInfoService;
        private readonly Lazy<IUserService> _userService;

        public ServiceManager(
            IRepositoryManager repositoryManager,
            IMapper mapper,
            IDataShaperManager dataShaper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptionsSnapshot<JwtConfiguration> jwtConfiguration,
            IOptionsSnapshot<MailConfiguration> mailConfiguration)
        {


            _authenticationService = new Lazy<IAuthenticationService>(
                () => new AuthenticationService(
                    repositoryManager,
                    mapper,
                    userManager,
                    signInManager,
                    jwtConfiguration));

            _workplaceService = new Lazy<IWorkplaceService>(
                () => new WorkplaceService(
                    repositoryManager,
                    mapper,
                    dataShaper));

            _mailService = new Lazy<IMailService>(
                () => new MailService(mailConfiguration));

            _employeeInfoService = new Lazy<IEmployeeInfoService>(() =>
            new EmployeeInfoService(
                repositoryManager,
                    mapper));

            _userService = new Lazy<IUserService>(() =>
            new UserService(
                repositoryManager,
                mapper,
                userManager,
                dataShaper));
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IWorkplaceService WorkplaceService => _workplaceService.Value;

        public IMailService MailService => _mailService.Value;

        public IEmployeeInfoService EmployeeInfoService => _employeeInfoService.Value;

        public IUserService UserService => _userService.Value;
    }
}
