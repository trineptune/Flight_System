namespace FlightWebApi.Models
{
    public class Configuration
    {
        public int Id { get; set; }
        public int RoleId {  get; set; }
        public int DocumentId {  get; set; }
        public virtual FlightDocument Document { get; set; }
    }
}
