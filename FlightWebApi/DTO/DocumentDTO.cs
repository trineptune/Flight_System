namespace FlightWebApi.DTO
{
    public class DocumentDTO
    {
        public int IdFlight { get; set; }
        public string DocumentName { get; set; }
        public double Version { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public ICollection<string> Permission { get; set; }
    }
}
