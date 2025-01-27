using AutoMapper;
using GarageManagementAPI.Entities.ConfigurationModels;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;

namespace GarageManagementAPI.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IOptionsSnapshot<JwtConfiguration> _configuration;
        private readonly JwtConfiguration _jwtConfiguration;
        private User? _user;

        public AuthenticationService(
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
             IOptionsSnapshot<JwtConfiguration> configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _jwtConfiguration = _configuration.Value;        }



        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtConfiguration.ValidIssuer,
                audience: _jwtConfiguration.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),                signingCredentials: signingCredentials
                );

            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user!.UserName !)
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
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
                ValidAudience = _jwtConfiguration.ValidAudience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                return token.InvalidTokenBadRequest<ClaimsPrincipal>();

            return Result<ClaimsPrincipal>.Ok(principal);
        }


        public async Task<Result<TokenDto>> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();

            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();

            _user!.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


            return Result<TokenDto>.Ok(new()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            });
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto, bool IsCustomer)
        {
            var check = await _userManager.FindByEmailAsync(userForRegistrationDto.Email!);
            if (check != null) return IdentityResult.Failed(
                    [
                        new(User)
                    ]
                );
            var user = _mapper.Map<User>(userForRegistrationDto);

            user.Status = SystemStatus.Active;

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password!);

                if (!result.Succeeded)
                    return result;

                if (IsCustomer)
                    await _userManager.AddToRoleAsync(user, SystemRole.Customer.ToString());
                else
                    await _userManager.AddToRoleAsync(user, userForRegistrationDto.Role.ToString());

                transaction.Complete();

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName!);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password!));

            return result;
        }

        public async Task<Result<TokenDto>> RefreshToken(TokenDto tokenDto)
        {
            var principalResult = GetPrincipalFomExpiredToken(tokenDto.AccessToken!);

            if (!principalResult.IsSuccess)
                return Result<TokenDto>.BadRequest(principalResult.Errors!);

            var principal = principalResult.GetValue<ClaimsPrincipal>();

            var user = await _userManager.FindByNameAsync(principal!.Identity!.Name!);

            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return tokenDto.RefreshToken!.InvalidTokenBadRequest<TokenDto>();

            _user = user;

            return await CreateToken(populateExp: false);
        }
    }
}
