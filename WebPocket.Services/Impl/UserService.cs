using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebPocket.Common.RequestResult;
using WebPocket.Data.Entities.AuthEntities;
using WebPocket.Data.ViewModels.AuthViewModels;
using WebPocket.Data.ViewModels.AuthViewModels.RequestModels;
using WebPocket.Services.Interfaces;
using WebPocket.Services.Settings;
using WebPocket.Common.Logging;

namespace WebPocket.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger _logger;

        public UserService(UserManager<User> userManager, JwtSettings jwtSettings, ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _logger = loggerFactory.CreateLogger(GetType());
        }

        public async Task<RequestResult<UserViewModel>> RegisterAsync(RegisterUserRequestModel registerModel)
        {
            var result = new RequestResult<UserViewModel>();

            try
            {
                var newUser = new User()
                {
                    Email = registerModel.Email,
                    UserName = registerModel.Username
                };

                var createdUser = await _userManager.CreateAsync(newUser, registerModel.Password);

                if (!createdUser.Succeeded)
                {
                    result.Errors = createdUser.Errors.Select(er => er.Description).ToArray();
                    return result;
                }

                var userViewModel = new UserViewModel().SetFrom(newUser);
                userViewModel.Token = GenerateAuthenticationToken(newUser);

                result.Obj = userViewModel;
                result.SetStatusOK();
            }
            catch (Exception ex)
            {
                result.SetInternalServerError();
                _logger.LogException(ex);
            }

            return result;
        }

        public async Task<RequestResult<UserViewModel>> LoginAsync(LoginUserRequestModel loginModel)
        {
            var result = new RequestResult<UserViewModel>();

            try
            {
                User user = string.IsNullOrEmpty(loginModel.Email)
                    ? await _userManager.FindByNameAsync(loginModel.Username)
                    : await _userManager.FindByEmailAsync(loginModel.Email);

                if (user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
                {
                    result.Errors = new[] { "Incorrect username or password." };
                    return result;
                }

                var userViewModel = new UserViewModel().SetFrom(user);
                userViewModel.Token = GenerateAuthenticationToken(user);

                result.Obj = userViewModel;
                result.SetStatusOK();
            }
            catch (Exception ex)
            {
                result.SetInternalServerError();
                _logger.LogException(ex);
            }

            return result;
        }

        public async Task<RequestResult<List<UserViewModel>>> GetUsersAsync()
        {
            var result = new RequestResult<List<UserViewModel>>();

            try
            {
                var users = await _userManager.Users
                    .Select(u => new UserViewModel() 
                    { 
                        Username = u.UserName,
                        Email = u.Email
                    })
                    .OrderBy(u => u.Username)
                    .ToListAsync();

                result.Obj = users;
                result.SetStatusOK();
            }
            catch (Exception ex)
            {
                result.SetInternalServerError();
                _logger.LogException(ex);
            }

            return result;
        }

        private string GenerateAuthenticationToken(User user)
        {
            var now = DateTime.UtcNow;
            var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString(), ClaimValueTypes.Integer64),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim("id", user.Id)
                    }),
                Expires = now.AddSeconds(_jwtSettings.AccessTokenLifeTime),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
