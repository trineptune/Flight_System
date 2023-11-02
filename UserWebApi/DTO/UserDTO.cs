namespace UserWebApi.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime TokenCreated { get; set; } = DateTime.Now;
        public DateTime TokenExpires { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }
}
