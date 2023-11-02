using UserWebApi.DTO;
using UserWebApi.Models;

namespace UserWebApi.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        List<User> SearchUsersByEmail(string key);
        Task<User> AddUser(UserDTO userdto);
        Task<bool> UpdateUser(int id, UserDTO userDTO);
        Task<bool> DeleteUser(int id);
        Task<bool> ChangePassword(int userId, string currentPassword, string newPassword);

    }
}
