using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("search")]
        public ActionResult<IEnumerable<User>> SearchUsersByEmail(string key)
        {
            var users = _userRepository.SearchUsersByEmail(key);
            return Ok(users);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Role>> AddUser(UserDTO userDTO)
        {
            var createdUser = await _userRepository.AddUser(userDTO);

            return Ok(createdUser);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userRepository.UpdateUser(id, userDTO);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userRepository.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [Authorize(Roles = "Admin,Pilot,Crew,GO Staff")]
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(int userId, string currentPassword, string newPassword)
        {
            var result = await _userRepository.ChangePassword(userId, currentPassword, newPassword);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}