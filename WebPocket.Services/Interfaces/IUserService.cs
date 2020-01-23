using System.Collections.Generic;
using System.Threading.Tasks;
using WebPocket.Common.RequestResult;
using WebPocket.Data.Entities.AuthEntities;
using WebPocket.Data.ViewModels.AuthViewModels;
using WebPocket.Data.ViewModels.AuthViewModels.RequestModels;

namespace WebPocket.Services.Interfaces
{
    public interface IUserService
    {
        Task<RequestResult<UserViewModel>> RegisterAsync(RegisterUserRequestModel registerUserViewModel);
        Task<RequestResult<UserViewModel>> LoginAsync(LoginUserRequestModel loginModel);
        Task<RequestResult<List<UserViewModel>>> GetUsersAsync();
    }
}
