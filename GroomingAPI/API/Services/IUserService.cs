using API.Models;

namespace GroomingAPI.Services
{
    public interface IUserService
    {
        long GetUserId();
        void SetUser(User currentUser);
    }
}