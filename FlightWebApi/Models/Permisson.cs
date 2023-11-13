using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightWebApi.Models
{
    public class Permisson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int TypeId { get; set; }
        public string Note { get; set; }
        public int GroupPermissionId { get; set; }
        public bool ReadAndModify {  get; set; }
        public bool ReadOnly {  get; set; }
        public bool NoPermission {  get; set; }
        public virtual GroupPermission groupPermissions { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}
