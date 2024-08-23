using Microsoft.AspNetCore.Mvc;
using FIlghtBookingSystemAspWebApi.DTOs;
using FIlghtBookingSystemAspWebApi.Interfaces;
using FIlghtBookingSystemAspWebApi.Models;

namespace FIlghtBookingSystemAspWebApi.Controllers
{


    namespace FlightBS.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CheckInStatusController : ControllerBase
        {
            // Dependencies for the controller
            private readonly ICheckInStatusRepository _checkInStatusRepository;
            private readonly IBookingDetailsRepository _bookingDetailsRepository;
            private readonly IUserRepository _userRepository;

            public CheckInStatusController(IUserRepository iuser, ICheckInStatusRepository checkInStatusRepository, IBookingDetailsRepository bookingDetailsRepository)
            {
                // Constructor for injecting dependencies
                _checkInStatusRepository = checkInStatusRepository;
                _bookingDetailsRepository = bookingDetailsRepository;
                _userRepository = iuser;
            }

            [HttpPost("checkin")]
            public async Task<IActionResult> CheckIn([FromBody] CheckInRequestDto checkInRequest)
            {
                // Retrieve booking details by ID
                var booking = await _bookingDetailsRepository.GetBookingByIdAsync(checkInRequest.Booking_Id);
                // Retrieve user details by booking's user ID
                var bookedby = await _userRepository.GetUserByIdAsync(booking.User_ID);

                // Check if booking exists and email matches

                if (booking == null || bookedby.Email != checkInRequest.Email)
                {
                    return NotFound("Booking not found or email does not match.");
                }

                // Create a new CheckInStatus instance
                var checkInStatus = new CheckInStatus
                {
                    BookingDetails = booking,
                    Booking_Id = checkInRequest.Booking_Id,
                    Flight_ID = booking.Flight_ID,
                    Check_in_Status = true,
                    Seat_Number = GenerateSeatNumber()
                };

                try
                {
                    // Add the check-in status using the repository

                    var createdCheckIn = await _checkInStatusRepository.AddAsync(checkInStatus);
                    var toSend = new
                    {
                        // Create a response object
                        SeatNumber = createdCheckIn.Seat_Number,
                        BookingId = createdCheckIn.Booking_Id,
                        CheckInStatus = createdCheckIn.Check_in_Status,
                        FlightId = createdCheckIn.Flight_ID,

                    };
                    return Ok(toSend);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            private string GenerateSeatNumber()
            {

                return "A1";
            }
        }
    }

}
