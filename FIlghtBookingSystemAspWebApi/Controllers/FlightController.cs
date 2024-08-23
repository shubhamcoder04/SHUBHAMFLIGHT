
using Microsoft.AspNetCore.Mvc;
using FIlghtBookingSystemAspWebApi.Interfaces;
using FIlghtBookingSystemAspWebApi.Models;
using Microsoft.AspNetCore.Authorization;
namespace FIlghtBookingSystemAspWebApi.Controllers
{
   

    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        // private readonly IFlightRepository _flightRepository;: Declares a private, read-only field that will hold the dependency for the 
        //IFlightRepository interface. This is used to interact with the flight data.
        private readonly IFlightRepository _flightRepository;


        //  This is the constructor for the FlightController class. It takes an IFlightRepository instance as a parameter.
        public FlightController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "UserPolicy")]

        public async Task<IActionResult> GetFlightById(int id)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchFlights([FromQuery] string source, [FromQuery] string destination, [FromQuery] DateTime date)
        {
            var flights = await _flightRepository.SearchFlightsAsync(source, destination, date);
            return Ok(flights);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _flightRepository.GetAllFlightsAsync();  
            return Ok(flights);
        }
        [HttpPost]
       [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> AddFlight([FromBody] FlightDetails flight)
        {
            if (flight == null)
            {
                return BadRequest("Flight details are required");
            }

            // Ensure Flight_ID is not set
            flight.Flight_ID = 0;

            var createdFlight = await _flightRepository.AddFlightAsync(flight);
            return CreatedAtAction(nameof(GetFlightById), new { id = createdFlight.Flight_ID }, createdFlight);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy ="AdminPolicy")]  
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            await _flightRepository.DeleteFlightAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] FlightDetails flight)
        {
            if (flight == null || flight.Flight_ID != id)
            {
                return BadRequest("Flight ID mismatch or flight details are invalid");
            }

            var existingFlight = await _flightRepository.GetFlightByIdAsync(id);
            if (existingFlight == null)
            {
                return NotFound();
            }

            await _flightRepository.UpdateFlightAsync(flight);
            return NoContent();
        }

    }
}