namespace FIlghtBookingSystemAspWebApi.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FIlghtBookingSystemAspWebApi.Data;
    using FIlghtBookingSystemAspWebApi.Interfaces.FlightBS.Repository;
    using FIlghtBookingSystemAspWebApi.Models;
    using Microsoft.EntityFrameworkCore;

    namespace FlightBS.Repository
    {
        public class PassengerRepository : IPassengerRepository
        {
            private readonly AppDbContext _context;

            public PassengerRepository(AppDbContext context)
            {
                _context = context;
            }

            // Method to get passengers by booking ID asynchronously

            public async Task<IEnumerable<Passenger>> GetPassengersByBookingIdAsync(int bookingId)
            {
                return await _context.Passengers
                    .Where(p => p.BookingId == bookingId)
                    .ToListAsync();
            }
            // Method to add a new passenger record asynchronously

            public async Task<Passenger> AddPassengerAsync(Passenger passenger)
            {
                _context.Passengers.Add(passenger);
                await _context.SaveChangesAsync();
                return passenger;
            }

            // Method to add multiple passenger records asynchronously

            public async Task AddPassengersAsync(IEnumerable<Passenger> passengers)
            {
                _context.Passengers.AddRange(passengers);
                await _context.SaveChangesAsync();
            }
        }
    }

}
