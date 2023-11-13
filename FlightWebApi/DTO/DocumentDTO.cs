using FlightWebApi.Models;

namespace FlightWebApi.DTO
{
    public class DocumentDTO
    {
        public int IdFlight { get; set; }
        public string DocumentName { get; set; }
        public double Version { get; set; }
        public int TypeId { get; set; }
        public string Note { get; set; }
        public string FilePath { get; set; }
        public DateTime Date { get; set; }
    }
}
