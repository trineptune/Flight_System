using FlightWebApi.DTO;
using FlightWebApi.Models;
namespace FlightWebApi.Reposiotry
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permisson>> GetAllPermission();
        Task<Permisson> GetPermissionById(int id);
        Task<PermissionDTO> AddPermission(PermissionDTO permissionDTO);
        Task<bool> UpdatePermission(int id, PermissionDTO permissionDTO);
        Task<bool> DeletePermission(int id);
        Task ReadAndModify(int id);
        Task ReadOnly(int id);
        Task NoPermission(int id);
    }
}
