using AutoMapper;
using GarageManagementAPI.Entities.ConfigurationModels;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Service.Utilities;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GarageManagementAPI.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IOptionsSnapshot<JwtConfiguration> _configuration;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly Random random = new Random();
        private User? _user;

        public AuthenticationService(
            IRepositoryManager repositoryManager,
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
             IOptionsSnapshot<JwtConfiguration> configuration)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _jwtConfiguration = _configuration.Value;
        }

        public string GenerateRandomPassword(int length)
        {
            const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digitChars = "0123456789";
            const string specialChars = "!@#$%^&*()_+-=[]{}|;:'\",.<>?/";
            const string allChars = lowerChars + upperChars + digitChars + specialChars;

            StringBuilder result = new StringBuilder();

            result.Append(lowerChars[random.Next(lowerChars.Length)]);
            result.Append(upperChars[random.Next(upperChars.Length)]);
            result.Append(digitChars[random.Next(digitChars.Length)]);
            result.Append(specialChars[random.Next(specialChars.Length)]);

            for (int i = 4; i <= length; i++)
            {
                result.Append(allChars[random.Next(allChars.Length)]);
            }

            return new string(result.ToString().ToCharArray().OrderBy(c => random.Next()).ToArray());
        }

        public string GenerateUserName(string firstName, string lastName)
        {
            StringBuilder result = new StringBuilder();
            result.Append(firstName.Substring(0, 1));
            result.Append(lastName.Substring(0, 1));
            var dateToString = DateTimeOffset.Now.SEAsiaStandardTime().ToString("yyyyMMddHHmmss");
            result.Append(dateToString);

            return result.ToString();
        }
        private async Task UpdateUserAsync()
        {
            _user!.UpdatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
            await _userManager.UpdateAsync(_user);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtConfiguration.ValidIssuer,
                audience: _jwtConfiguration.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.SEAsiaStandardTime().AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
                signingCredentials: signingCredentials
                );

            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim("UserName", _user!.UserName!),
                new Claim("UserId", _user!.Id.ToString()!),
                new Claim("ImageLink", _user!.ImageLink ?? "N/A"),
                new Claim("FirstName", _user!.FirstName!),
                new Claim("LastName", _user!.LastName!),
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim("Role", role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")!);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);

                return Convert.ToBase64String(randomNumber);
            }
        }

        private Result<ClaimsPrincipal> GetPrincipalFomExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")!)),
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience,
                NameClaimType = "UserName",
                RoleClaimType = "Role",
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                return token.InvalidTokenBadRequest<ClaimsPrincipal>();

            return Result<ClaimsPrincipal>.Ok(principal);
        }

        private async Task<Result> CheckIfUserExist(UserForRegistrationDto userForRegistrationDto)
        {
            var emailRegister = userForRegistrationDto.Email!.ToLower();
            var phoneNumberRegister = userForRegistrationDto.PhoneNumber!.ToLower();
            var userNameRegister = userForRegistrationDto.UserName;

            var check = await _repositoryManager.User.FindByCondition(u =>
                u.Email!.ToLower().Equals(emailRegister) ||
                u.PhoneNumber!.Equals(phoneNumberRegister) ||
                u.UserName!.Equals(userNameRegister), false).AnyAsync();

            if (check)
                return Result.BadRequest([UserErrors.GetUserExistedError(
                   userForRegistrationDto.Email!,
                   userForRegistrationDto.UserName!,
                   userForRegistrationDto.PhoneNumber!)]);

            return Result.Ok();
        }

        private async Task<Result> CheckIfEmployeeExist(string citizenIdentification)
        {

            var check = await _repositoryManager.EmployeeInfo.FindByCondition(u => u.CitizenIdentification.ToLower().Trim().Equals(citizenIdentification.ToLower().Trim()), false).AnyAsync();

            if (check)
                return Result.BadRequest([UserErrors.GetEmployeeExistedError(citizenIdentification)]);

            return Result.Ok();
        }

        public async Task<Result<TokenDto>> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();

            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();

            _user!.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.UtcNow.SEAsiaStandardTime().AddDays(7);

            await UpdateUserAsync();

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


            return Result<TokenDto>.Ok(new()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            });

        }

        public async Task<Result> RegisterUser(UserForRegistrationDto userForRegistrationDto, SystemRole role, string password, IDbContextTransaction? transaction = null)
        {
            var check = await CheckIfUserExist(userForRegistrationDto);
            if (!check.IsSuccess)
                return check;

            _user = _mapper.Map<User>(userForRegistrationDto);
            _user.Status = UserStatus.Active;
            _user.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            _user.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            var isTransactionOwner = false;
            var strategy = _repositoryManager.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                if (transaction == null)
                {
                    transaction = await _repositoryManager.BeginTransactionAsync();
                    isTransactionOwner = true;
                }

                try
                {
                    var result = await _userManager.CreateAsync(_user, password);
                    if (!result.Succeeded)
                        return result.InvalidResult();

                    result = await _userManager.AddToRoleAsync(_user, role.ToString());
                    if (!result.Succeeded)
                        return result.InvalidResult();

                    if (isTransactionOwner)
                        await transaction.CommitAsync();

                    return Result.Ok();
                }
                catch
                {
                    if (isTransactionOwner)
                        await transaction.RollbackAsync();
                    throw;
                }
            });
        }

        public async Task<Result> RegisterEmployeeInfo(UserForRegistrationEmployeeDto userForRegistrationEmployeeDto, SystemRole role, string password)
        {
            var result = await CheckIfWorkplaceExist((Guid)userForRegistrationEmployeeDto.WorkplaceId!);
            if (!result.IsSuccess)
                return result;

            result = await CheckIfEmployeeExist(userForRegistrationEmployeeDto.CitizenIdentification!);
            if (!result.IsSuccess)
                return result;

            var strategy = _repositoryManager.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _repositoryManager.BeginTransactionAsync();
                try
                {
                    result = await RegisterUser(userForRegistrationEmployeeDto, role, password, transaction);
                    if (!result.IsSuccess)
                        return result;

                    var employeeInfoEntity = _mapper.Map<EmployeeInfo>(userForRegistrationEmployeeDto);
                    employeeInfoEntity.Id = _user!.Id;
                    await _repositoryManager.EmployeeInfo.CreateAsync(employeeInfoEntity);
                    await _repositoryManager.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }

                return result;
            });
        }

        private async Task<Result> CheckIfWorkplaceExist(Guid workplaceId)
        {
            var workplace = await _repositoryManager.Workplace.GetWorkplaceByIdAsync(workplaceId, false);
            if (workplace is null)
                return Result.NotFound([WorkplaceErrors.GetWorkplaceNotFoundError(workplaceId)]);

            return Result.NoContent();
        }

        public async Task<Result> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = userForAuth.UserName!.Contains("@")
               ? await _userManager.FindByEmailAsync(userForAuth.UserName)
               : await _userManager.FindByNameAsync(userForAuth.UserName);

            if (_user is null || !await _userManager.CheckPasswordAsync(_user, userForAuth.Password!))
            {
                var error = userForAuth.UserName.Contains("@")
                    ? UserErrors.GetUserNotFoundWithEmailError(userForAuth.UserName)
                    : UserErrors.GetUserNotFoundWithUsernameError(userForAuth.UserName);
                return Result.NotFound([error]);
            }

            if (!_user.EmailConfirmed)
                return Result.Unauthorized([UserErrors.GetConfirmEmailRequiredError()]);

            return Result.Ok();
        }

        public async Task<Result<TokenDto>> RefreshToken(TokenDto tokenDto)
        {
            var principalResult = GetPrincipalFomExpiredToken(tokenDto.AccessToken!);

            if (!principalResult.IsSuccess)
                return Result<TokenDto>.BadRequest(principalResult.Errors!);

            var principal = principalResult.GetValue<ClaimsPrincipal>();

            var user = await _userManager.FindByNameAsync(principal!.Identity!.Name!);

            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow.SEAsiaStandardTime())
                return tokenDto.RefreshToken!.InvalidTokenBadRequest<TokenDto>();

            _user = user;

            return await CreateToken(populateExp: false);
        }

        public async Task<Result<string>> CreateForgotPasswordUrl(string email)
        {
            _user = await _userManager.FindByEmailAsync(email);
            if (_user == null)
                return Result<string>.NotFound([UserErrors.GetUserNotFoundWithEmailError(email)]);

            if (!_user.EmailConfirmed)
                return Result<string>.Unauthorized([UserErrors.GetConfirmEmailRequiredError()]);

            var token = await _userManager.GeneratePasswordResetTokenAsync(_user);

            var baseUrl = _jwtConfiguration.ValidAudience;
            var builder = new UriBuilder(baseUrl!)
            {
                Path = "authen/reset-password",
                Query = $"email={email}&token={Uri.EscapeDataString(token)}"
            };
            var resetPasswordUrl = builder.ToString();

            return Result<string>.Ok(resetPasswordUrl);

        }

        public async Task<Result<string>> CreateConfirmEmailUrl(string email)
        {
            _user = await _userManager.FindByEmailAsync(email);
            if (_user == null)
                return Result<string>.NotFound([UserErrors.GetUserNotFoundWithEmailError(email)]);

            if (_user.EmailConfirmed)
                return Result<string>.BadRequest([UserErrors.GetEmailAlreadyConfirmedError()]);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(_user);

            var baseUrl = _jwtConfiguration.ValidAudience;
            var builder = new UriBuilder(baseUrl!)
            {
                Path = "authen/confirm-email",
                Query = $"email={email}&token={Uri.EscapeDataString(token)}"
            };
            var resetPasswordUrl = builder.ToString();

            return Result<string>.Ok(resetPasswordUrl);

        }

        public async Task<Result> ConfirmEmail(UserForConfirmEmail userForConfirmEmail)
        {
            _user = await _userManager.FindByEmailAsync(userForConfirmEmail.Email!);
            if (_user == null)
                return Result.NotFound([UserErrors.GetUserNotFoundWithEmailError(userForConfirmEmail.Email!)]);

            var result = await _userManager.ConfirmEmailAsync(_user, Uri.UnescapeDataString(userForConfirmEmail.Token!));

            if (!result.Succeeded)
                return result.InvalidResult();

            await UpdateUserAsync();

            return Result.Ok();
        }

        public async Task<Result> ResetPassword(UserForResetPasswordDto userForResetPasswordDto)
        {
            _user = await _userManager.FindByEmailAsync(userForResetPasswordDto.Email!);
            if (_user == null)
                return Result<IdentityResult>.NotFound([UserErrors.GetUserNotFoundWithEmailError(userForResetPasswordDto.Email!)]);

            var resetPassResult = await _userManager.ResetPasswordAsync(_user, Uri.UnescapeDataString(userForResetPasswordDto.Token!), userForResetPasswordDto.Password!);

            if (!resetPassResult.Succeeded)
                return resetPassResult.InvalidResult();

            await UpdateUserAsync();

            return Result<IdentityResult>.Ok(resetPassResult);
        }

        public async Task<Result> ChangePassword(string username, UserForChangePasswordDto userForChangePasswordDto)
        {
            _user = await _userManager.FindByNameAsync(username);
            if (_user == null || !await _userManager.CheckPasswordAsync(_user, userForChangePasswordDto.CurrentPassword!))
                return Result<IdentityResult>.NotFound([UserErrors.GetUserNotFoundWithUsernameError(username)]);

            var resetPassResult = await _userManager.ChangePasswordAsync(_user, userForChangePasswordDto.CurrentPassword!, userForChangePasswordDto.NewPassword!);

            if (!resetPassResult.Succeeded)
                return resetPassResult.InvalidResult();

            await UpdateUserAsync();

            return Result<IdentityResult>.Ok(resetPassResult);
        }
    }
}
