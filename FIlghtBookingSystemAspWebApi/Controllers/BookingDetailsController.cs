using FIlghtBookingSystemAspWebApi.Interfaces;
using FIlghtBookingSystemAspWebApi.Models;
using FIlghtBookingSystemAspWebApi.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace FIlghtBookingSystemAspWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

//ControllerBase provides basic controller functionalities.
    public class BookingDetailsController : ControllerBase
    {
        // Declares a private readonly field to hold the injected booking repository instance.
        private readonly IBookingDetailsRepository _bookingRepository;

        // Constructor for injecting the booking repository dependency
        public BookingDetailsController(IBookingDetailsRepository bookingRepository)
        {
            //Assigns the injected repository to the private field.
            _bookingRepository = bookingRepository;
        }

        [HttpPost]

        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> PostBooking([FromBody] BookingDetailsDto bookingDto)
        {
            // Checks if the incoming model is valid.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map the DTO to the domain model

            var booking = new BookingDetails
            {
                Flight_ID = bookingDto.Flight_ID,
                User_ID = bookingDto.User_ID,
                No_of_passengers = bookingDto.No_of_passengers,
                DateTime = DateTime.UtcNow,
                Passengers = bookingDto.Passengers.Select(p => new Passenger
                {
                    Name = p.Name,
                    Age = p.Age,
                    Gender = p.Gender
                }).ToList()
            };

            try
            {
                // Add the booking using the repository
                var createdBooking = await _bookingRepository.AddBookingAsync(booking);
                // Return the created booking with 201 status code
                return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.Booking_Id }, createdBooking);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            // Retrieve the booking by ID using the repository
            var booking = await _bookingRepository.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }
        [HttpDelete("cancel/{bookingId}")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {

            var result = await _bookingRepository.CancelBookingAsync(bookingId);
            if (!result)
            {
                return NotFound();
            }

            return Ok(new { message = "Booking cancelled successfully" });
        }
    }
}
