using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserWebApi.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime TokenCreated { get; set; } = DateTime.Now;
        public DateTime TokenExpires { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public virtual Role Role { get; set; }

    }
}
