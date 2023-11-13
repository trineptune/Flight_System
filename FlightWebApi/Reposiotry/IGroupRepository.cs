using FlightWebApi.DTO;
using FlightWebApi.Models;

namespace FlightWebApi.Reposiotry
{
    public interface IGroupRepository
    {

        Task<IEnumerable<GroupPermission>> GetGroupPermission();
        Task<GroupPermission> GetGroupPermissionById(int id);
        Task<GroupPermissionDTO> AddGroupPermission(GroupPermissionDTO groupPermissionDto);
        Task<bool> UpdateGroupPermission(int id, GroupPermissionDTO groupDto);
        Task<bool> DeleteGroup(int id);
    }
}
