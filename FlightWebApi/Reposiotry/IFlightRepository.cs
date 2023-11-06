using FlightWebApi.DTO;
using FlightWebApi.Models;

namespace FlightWebApi.Reposiotry
{
    public interface IFlightRepository
    {
        Task<IEnumerable<FlightModels>> GetAllFlight();
        Task<FlightModels> GetFlightById(int id);
        Task<FlightDTO> AddFlight(FlightDTO flightDto);
        Task<bool> UpdateFlight(int id, FlightDTO flightDTO);
        Task<bool> DeleteFlight(int id);
    }
}
