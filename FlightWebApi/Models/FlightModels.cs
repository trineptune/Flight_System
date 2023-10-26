using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightWebApi.Models
{
    public class FlightModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String FlightNo {  get; set; }
        public string PointOfLoading {  get; set; }
        public string PointOfUnloading {  get; set; }
        public DateTime Date {  get; set; }
        public ICollection<FlightDocument> FlightDocuments { get; set; }
    }
}
