using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightWebApi.Models
{
    public class FlightDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public int IdFlight {  get; set; }
        public string DocumentName {  get; set; }
        public double Version {  get; set; }
        public string Type {  get; set; }
        public string Note {  get; set; }
        public ICollection<RoleModel>? Permission {  get; set; }
        public DateTime Date { get; set; }
        public virtual FlightModels FlightModels { get; set; }
    }
}
