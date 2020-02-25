using System.Collections.Generic;
using System.Threading.Tasks;
using WebPocket.Services.RequestResults;
using WebPocket.Services.ViewModels.AuthViewModels;
using WebPocket.Services.ViewModels.AuthViewModels.RequestModels;

namespace WebPocket.Services.Interfaces
{
    public interface IUserService
    {
        Task<RequestResult<UserViewModel>> RegisterAsync(RegisterUserRequestModel registerUserViewModel);
        Task<RequestResult<UserViewModel>> LoginAsync(LoginUserRequestModel loginModel);
        Task<RequestResult<IEnumerable<UserViewModel>>> GetUsersAsync();
    }
}
