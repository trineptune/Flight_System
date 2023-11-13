using FlightWebApi.Data;
using FlightWebApi.DTO;
using FlightWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightWebApi.Reposiotry
{
    public class GroupPermissionRepository:IGroupRepository
    {
        private readonly FlightDbContext _context;
        public GroupPermissionRepository(FlightDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GroupPermission>> GetGroupPermission()
        {
            return await _context.GroupPermission.ToListAsync();
        }

        public async Task<GroupPermission> GetGroupPermissionById(int id)
        {
            return await _context.GroupPermission.FindAsync(id);
        }

        public async Task<GroupPermissionDTO> AddGroupPermission(GroupPermissionDTO groupPermissionDto)
        {
            var newGroup = new GroupPermission
            {
                RoleName = groupPermissionDto.RoleName,
                UserId= groupPermissionDto.UserId,

            };
            _context.GroupPermission.Add(newGroup);
            await _context.SaveChangesAsync();

            return groupPermissionDto;
        }

        public async Task<bool> UpdateGroupPermission(int id, GroupPermissionDTO groupDto)
        {
            var group = await _context.GroupPermission.FindAsync(id);

            if (group == null)
            {
                return false;
            }
            group.RoleName = groupDto.RoleName; 
            group.UserId = groupDto.UserId;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteGroup(int id)
        {
            var group = await _context.GroupPermission.FindAsync(id);
            if (group == null)
            {
                return false;
            }

            _context.GroupPermission.Remove(group);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
