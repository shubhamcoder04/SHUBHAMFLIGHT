using FIlghtBookingSystemAspWebApi.Data;
using FIlghtBookingSystemAspWebApi.Interfaces;
using FIlghtBookingSystemAspWebApi.Models;
using Microsoft.EntityFrameworkCore;


namespace FIlghtBookingSystemAspWebApi.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AppDbContext _context;

        public FlightRepository(AppDbContext context)
        {
            _context = context;
        }

        // Method to get flight details by flight ID asynchronously

        public async Task<FlightDetails> GetFlightByIdAsync(int flightId)
        {
            return await _context.FlightDetails.FindAsync(flightId);
        }

        // Method to get all flight details asynchronously
        public async Task<IEnumerable<FlightDetails>> GetAllFlightsAsync()
        {
            return await _context.FlightDetails.ToListAsync();
        }

        // Method to add a new flight record asynchronously

        public async Task<FlightDetails> AddFlightAsync(FlightDetails flight)
        {
            _context.FlightDetails.Add(flight);
            await _context.SaveChangesAsync();
            return flight;
        }

        // Method to update an existing flight record asynchronously

        public async Task<FlightDetails> UpdateFlightAsync(FlightDetails flight)
        {
            var existingFlight = await _context.FlightDetails.FindAsync(flight.Flight_ID);
            if (existingFlight != null)
            {
                _context.Entry(existingFlight).State = EntityState.Detached;
            }

            _context.FlightDetails.Update(flight);
            await _context.SaveChangesAsync();
            return flight;
        }

        // Method to search for flights based on source, destination, and date asynchronously
        public async Task<IEnumerable<FlightDetails>> SearchFlightsAsync(string source, string destination, DateTime date)
        {
            return await _context.FlightDetails
                .Where(f => f.Source == source && f.Destination == destination && f.Departure_Time.Date == date.Date)
                .ToListAsync();
        }



        // Method to delete a flight record by flight ID asynchronously
        public async Task DeleteFlightAsync(int flightId)
        {
            var flight = await _context.FlightDetails.FindAsync(flightId);
            if (flight != null)
            {
                _context.FlightDetails.Remove(flight);
                await _context.SaveChangesAsync();
            }
        }

    }

}
