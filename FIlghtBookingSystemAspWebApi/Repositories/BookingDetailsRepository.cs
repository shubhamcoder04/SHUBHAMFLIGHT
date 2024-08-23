using FIlghtBookingSystemAspWebApi.Data;
using FIlghtBookingSystemAspWebApi.Interfaces;
using FIlghtBookingSystemAspWebApi.Models;
using Microsoft.EntityFrameworkCore;


namespace FIlghtBookingSystemAspWebApi.Repositories
{
    public class BookingDetailsRepository : IBookingDetailsRepository
    {
        private readonly AppDbContext _context;

        public BookingDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BookingDetails> AddBookingAsync(BookingDetails booking)
        {
            // Find the flight by ID
            var flight = await _context.FlightDetails.FindAsync(booking.Flight_ID);
            if (flight == null) throw new KeyNotFoundException("Flight not found.");

            // Calculate the total amount based on fare and number of passengers

            booking.Total_Amount = flight.Fare * booking.No_of_passengers;

            // Generate a unique transaction number

            booking.TransactionNumber = Guid.NewGuid().ToString();

            // Set the booking date and time to the current UTC time
            booking.DateTime = DateTime.UtcNow;

            _context.BookingDetails.Add(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        // Method to get booking details by ID asynchronously
        public async Task<BookingDetails> GetBookingByIdAsync(int bookingId)
        {
            // Include passengers in the booking details

            return await _context.BookingDetails.Include(b => b.Passengers).FirstOrDefaultAsync(b => b.Booking_Id == bookingId);
        }

        // Method to cancel a booking asynchronously

        public async Task<bool> CancelBookingAsync(int bookingId)
        {

            // Include passengers in the booking details

            var booking = await _context.BookingDetails
                .Include(b => b.Passengers) // Include the passengers
                .FirstOrDefaultAsync(b => b.Booking_Id == bookingId);

            if (booking == null)
            {
                return false;
            }

            // Remove associated passengers
            _context.Passengers.RemoveRange(booking.Passengers);

            // Remove the booking
            _context.BookingDetails.Remove(booking);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
    

