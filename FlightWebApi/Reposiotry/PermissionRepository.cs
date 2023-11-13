using FlightWebApi.Data;
using FlightWebApi.DTO;
using FlightWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightWebApi.Reposiotry
{
    public class PermissionRepository:IPermissionRepository
    {
        private readonly FlightDbContext _context;
        public PermissionRepository(FlightDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Permisson>> GetAllPermission()
        {
            return await _context.Permission.ToListAsync();
        }

        public async Task<Permisson> GetPermissionById(int id)
        {
            return await _context.Permission.FindAsync(id);
        }

        public async Task<PermissionDTO> AddPermission(PermissionDTO permissionDTO)
        {
            var newPermission  = new Permisson
            {
                TypeId=permissionDTO.TypeId,
                Note=permissionDTO.Note,
                GroupPermissionId=permissionDTO.GroupPermissionId,
                NoPermission= false,
                ReadAndModify=false,
                ReadOnly=false

            };
            _context.Permission.Add(newPermission);
            await _context.SaveChangesAsync();

            return permissionDTO;
        }

        public async Task<bool> UpdatePermission(int id, PermissionDTO permissionDTO)
        {
            var permission = await _context.Permission.FindAsync(id);

            if (permission == null)
            {
                return false;
            }
            permission.TypeId = permissionDTO.TypeId;
            permission.Note = permissionDTO.Note;
            permission.GroupPermissionId=permissionDTO.GroupPermissionId;
            permission.ReadOnly=permissionDTO.ReadOnly;
            permission.NoPermission=permissionDTO.NoPermission;
            permission.ReadAndModify=permissionDTO.ReadAndModify;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePermission(int id)
        {
            var permission = await _context.Permission.FindAsync(id);
            if (permission == null)
            {
                return false;
            }

            _context.Permission.Remove(permission);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task ReadAndModify(int id)
        {
            var Id = await GetPermissionById(id);
            if (Id != null)
            {
                Id.ReadAndModify = true;
                Id.ReadOnly = false;
                Id.NoPermission = false;
                _context.Permission.Update(Id);
                await _context.SaveChangesAsync();
            }
        }
        public async Task ReadOnly(int id)
        {
            var Id = await GetPermissionById(id);
            if (Id != null)
            {
                Id.ReadOnly = true;
                Id.NoPermission = false;
                Id.ReadAndModify=false;
                _context.Permission.Update(Id);
                await _context.SaveChangesAsync();
            }
        }
        public async Task NoPermission(int id)
        {
            var Id = await GetPermissionById(id);
            if (Id != null)
            {
                Id.NoPermission = true;
                Id.ReadOnly = false;
                Id.ReadAndModify = false;
                _context.Permission.Update(Id);
                await _context.SaveChangesAsync();
            }
        }
    }
}
