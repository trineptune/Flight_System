using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using UserWebApi.Data;
using UserWebApi.DTO;
using UserWebApi.Models;

namespace UserWebApi.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public List<User> SearchUsersByEmail(string key)
        {
            var users = _context.Users
    .AsEnumerable()
    .Where(u => u.Email.Contains(key, StringComparison.OrdinalIgnoreCase) )
    .ToList();
            return users;
        }

        public async Task<User> AddUser(UserDTO userdto)
        {
            var newUser = new User
            {
               Email = userdto.Email,
               Name = userdto.Name,
               RoleId = userdto.RoleId,
               Password = userdto.Password
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<bool> UpdateUser(int id, UserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }
            user.Email = userDTO.Email;
            user.Name = userDTO.Name;
            user.RoleId = userDTO.RoleId;
            user.Password = userDTO.Password;   

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    
        public async Task<bool> ChangePassword(int userId, string currentPassword, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return false;
            }

            if (user.Password != currentPassword)
            {
                return false;
            }

            user.Password = newPassword;
            await _context.SaveChangesAsync();

            return true;
        }

       
    }
}
