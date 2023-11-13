using System.Threading.Tasks;
using FlightWebApi.DTO;
using FlightWebApi.Models;
using FlightWebApi.Reposiotry;
using Microsoft.AspNetCore.Mvc;

namespace FlightWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupPermissionController : ControllerBase
    {
        private readonly IGroupRepository _groupPermissionRepository;

        public GroupPermissionController(IGroupRepository groupPermissionRepository)
        {
            _groupPermissionRepository = groupPermissionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupPermission()
        {
            var groupPermissions = await _groupPermissionRepository.GetGroupPermission();
            return Ok(groupPermissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupPermissionById(int id)
        {
            var groupPermission = await _groupPermissionRepository.GetGroupPermissionById(id);
            if (groupPermission == null)
            {
                return NotFound();
            }
            return Ok(groupPermission);
        }

        [HttpPost]
        public async Task<IActionResult> AddGroupPermission(GroupPermissionDTO groupPermissionDto)
        {
            var createGroup = await _groupPermissionRepository.AddGroupPermission(groupPermissionDto);

            return Ok(createGroup);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroupPermission(int id, GroupPermissionDTO groupDto)
        {
            var updated = await _groupPermissionRepository.UpdateGroupPermission(id, groupDto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupPermission(int id)
        {
            var deleted = await _groupPermissionRepository.DeleteGroup(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}