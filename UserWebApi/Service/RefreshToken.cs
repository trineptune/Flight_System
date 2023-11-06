using Microsoft.AspNet.Identity;
using UserWebApi.Repository;

namespace UserWebApi.Service
{
    public class RefreshToken:IRefreshToken
    {
        private readonly IUserRepository _userRepository;
        public RefreshToken(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void SetRefreshToken(int userId)
        {
            _userRepository.UpdateUserAuthentication(userId);
        }
    }
}
