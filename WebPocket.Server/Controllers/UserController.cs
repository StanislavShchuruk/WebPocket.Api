using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPocket.Common.RequestResult;
using WebPocket.Data.Entities.AuthEntities;
using WebPocket.Data.ViewModels.AuthViewModels;
using WebPocket.Services.Interfaces;

namespace WebPocket.Web.Controllers
{
    [AllowAnonymous]
    public class UserController : ApiBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("get-users")]
        public async Task<RequestResult<List<UserViewModel>>> GetUsersAsync()
        {
            return await _userService.GetUsersAsync();
        }
    }
}
