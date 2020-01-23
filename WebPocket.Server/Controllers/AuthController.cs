using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebPocket.Common.RequestResult;
using WebPocket.Data.ViewModels.AuthViewModels.RequestModels;
using WebPocket.Services.Interfaces;

namespace WebPocket.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiBaseController
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<RequestResult> RegisterAsync(RegisterUserRequestModel registerUser)
        {
            return await _userService.RegisterAsync(registerUser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<RequestResult> LoginAsync(LoginUserRequestModel loginUser)
        {
            return await _userService.LoginAsync(loginUser);
        }
    }
}