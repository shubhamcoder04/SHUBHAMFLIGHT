using FIlghtBookingSystemAspWebApi.Data;
using FIlghtBookingSystemAspWebApi.Interfaces;
using FIlghtBookingSystemAspWebApi.Models;


namespace FIlghtBookingSystemAspWebApi.Repositories
{
    using System.Threading.Tasks;
   

    public class CheckInStatusRepository : ICheckInStatusRepository
    {
        private readonly AppDbContext _context;

        // Constructor for injecting the database context

        public CheckInStatusRepository(AppDbContext context)
        {
            _context = context;
        }

        // Method to add a new CheckInStatus record to the database 

        public async Task<CheckInStatus> AddAsync(CheckInStatus checkInStatus)
        {
            // Add the new CheckInStatus entity to the DbContext
            _context.CheckInStatuses.Add(checkInStatus);
            _context.SaveChanges();
            // Return the added CheckInStatus entity
            return checkInStatus;
        }
    }
}
