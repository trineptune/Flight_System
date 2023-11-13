using FlightWebApi.DTO;
using FlightWebApi.Models;
using FlightWebApi.Reposiotry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightWebApi.Controllers
{
    [ApiController]
    [Route("api/flights")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;

        public FlightController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightModels>>> GetAllFlights()
        {
            var flights = await _flightRepository.GetAllFlight();
            return Ok(flights);
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightModels>> GetFlightById(int id)
        {
            var flight = await _flightRepository.GetFlightById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }
       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<FlightDTO>> AddFlight(FlightDTO flightDto)
        {
            var createdFlight = await _flightRepository.AddFlight(flightDto);

            return Ok(createdFlight);
        }
       // [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, FlightDTO flightDto)
        {
            var success = await _flightRepository.UpdateFlight(id, flightDto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
       // [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var success = await _flightRepository.DeleteFlight(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}