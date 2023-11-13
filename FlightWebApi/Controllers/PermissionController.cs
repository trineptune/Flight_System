using System.Threading.Tasks;
using FlightWebApi.DTO;
using FlightWebApi.Models;
using FlightWebApi.Reposiotry;
using Microsoft.AspNetCore.Mvc;

namespace FlightWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermission()
        {
            var permissions = await _permissionRepository.GetAllPermission();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            var permission = await _permissionRepository.GetPermissionById(id);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }

        [HttpPost]
        public async Task<IActionResult> AddPermission(PermissionDTO permissionDto)
        {
            var createPermission = await _permissionRepository.AddPermission(permissionDto);

            return Ok(createPermission);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id, PermissionDTO permissionDto)
        {
            var updated = await _permissionRepository.UpdatePermission(id, permissionDto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var deleted = await _permissionRepository.DeletePermission(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("{id}/readAndModify")]
        public async Task<IActionResult> SetReadAndModify(int id)
        {
            await _permissionRepository.ReadAndModify(id);
            return NoContent();
        }

        [HttpPost("{id}/readOnly")]
        public async Task<IActionResult> SetReadOnly(int id)
        {
            await _permissionRepository.ReadOnly(id);
            return NoContent();
        }

        [HttpPost("{id}/noPermission")]
        public async Task<IActionResult> SetNoPermission(int id)
        {
            await _permissionRepository.NoPermission(id);
            return NoContent();
        }
    }
}