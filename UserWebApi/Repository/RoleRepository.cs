using Microsoft.EntityFrameworkCore;
using UserWebApi.Data;
using UserWebApi.DTO;
using UserWebApi.Models;

namespace UserWebApi.Repository
{
    public class RoleRepository :IRoleRepository
    {
        private readonly UserDbContext _context;
        public RoleRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<RoleDTO> AddRole(RoleDTO roleDto)
        {
            var newRole = new Role
            {
                RoleName = roleDto.RoleName,
            };
            _context.Roles.Add(newRole);
            await _context.SaveChangesAsync();

            return roleDto;
        }

        public async Task<bool> UpdateRole(int id, RoleDTO roleDTO)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return false;
            }

            role.RoleName = roleDTO.RoleName;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return false;
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
