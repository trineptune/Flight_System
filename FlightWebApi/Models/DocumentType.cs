using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightWebApi.Models
{
    public class DocumentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public string TypeName {  get; set; }
        public virtual FlightDocument Documents { get; set; }
        public ICollection<Permisson> permissons { get; set; }
    }
}
