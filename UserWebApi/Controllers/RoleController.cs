using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserWebApi.DTO;
using UserWebApi.Models;
using UserWebApi.Repository;

namespace UserWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            var role = await _roleRepository.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> AddRole(RoleDTO roleDto)
        {
            var createdRole = await _roleRepository.AddRole(roleDto);

            return Ok(createdRole);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, RoleDTO roleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _roleRepository.UpdateRole(id, roleDTO);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _roleRepository.DeleteRole(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}