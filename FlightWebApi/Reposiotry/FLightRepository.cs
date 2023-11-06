using FlightWebApi.Data;
using FlightWebApi.DTO;
using FlightWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightWebApi.Reposiotry
{
    public class FLightRepository:IFlightRepository
    {
        private readonly FlightDbContext _context;
        public FLightRepository(FlightDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FlightModels>> GetAllFlight()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<FlightModels> GetFlightById(int id)
        {
            return await _context.Flights.FindAsync(id);
        }

        public async Task<FlightDTO> AddFlight(FlightDTO flightDto)
        {
            var newFlight = new FlightModels
            {
                FlightNo = flightDto.FlightNo,
                PointOfLoading = flightDto.PointOfLoading,
                PointOfUnloading = flightDto.PointOfUnloading,
                Date= DateTime.Now,

            };
            _context.Flights.Add(newFlight);
            await _context.SaveChangesAsync();

            return flightDto;
        }

        public async Task<bool> UpdateFlight(int id, FlightDTO flightDTO)
        {
            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return false;
            }

            flight.FlightNo = flightDTO.FlightNo;
            flight.PointOfLoading = flightDTO.PointOfLoading;
            flight.PointOfUnloading= flightDTO.PointOfUnloading;
            flight.Date = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return false;
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
