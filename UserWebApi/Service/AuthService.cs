using Azure.Core;
using System.Collections.Generic;
using UserWebApi.Data;
using UserWebApi.DTO;
using UserWebApi.Models;
using UserWebApi.Repository;

namespace UserWebApi.Service
{
    public class AuthService
    {

        private readonly UserDbContext _context;
        private readonly JwtService _jwtService;
        private readonly IUserRepository _repo;
        public AuthService(UserDbContext context, JwtService jwtService, IUserRepository user)
        {
            _context = context;
            _jwtService = jwtService;
            _repo = user;
        }

        public string Authenticate(LoginDTO userDTO, HttpContext httpContext)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userDTO.Email && u.Password == userDTO.Password && u.Role.Id == userDTO.Role);

            if (user != null)
            {
                httpContext.Session.SetInt32("UserId", user.Id);

                return _jwtService.GenerateToken(user);
            }

            return null;
        }

    }
}
