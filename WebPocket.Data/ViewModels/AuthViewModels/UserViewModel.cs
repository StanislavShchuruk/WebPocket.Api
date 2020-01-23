using WebPocket.Data.Entities.AuthEntities;

namespace WebPocket.Data.ViewModels.AuthViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public UserViewModel SetFrom(User entity)
        {
            Username = entity.UserName;
            Email = entity.Email;

            return this;
        }
    }
}
