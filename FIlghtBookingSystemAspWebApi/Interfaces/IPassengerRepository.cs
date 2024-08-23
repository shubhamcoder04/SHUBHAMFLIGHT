namespace FIlghtBookingSystemAspWebApi.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FIlghtBookingSystemAspWebApi.Models;

    namespace FlightBS.Repository
    {
        public interface IPassengerRepository
        {
            Task<IEnumerable<Passenger>> GetPassengersByBookingIdAsync(int bookingId);
            Task<Passenger> AddPassengerAsync(Passenger passenger);
            Task AddPassengersAsync(IEnumerable<Passenger> passengers);
        }
    }

}
