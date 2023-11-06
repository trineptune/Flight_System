namespace FlightWebApi.DTO
{
    public class FlightDTO
    {
        public String FlightNo { get; set; }
        public string PointOfLoading { get; set; }
        public string PointOfUnloading { get; set; }
        public DateTime Date { get; set; }
    }
}
