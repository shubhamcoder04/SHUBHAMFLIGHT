using FIlghtBookingSystemAspWebApi.Models;

namespace FIlghtBookingSystemAspWebApi.Interfaces
{
    public interface IFlightRepository
    {
        Task<FlightDetails> GetFlightByIdAsync(int flightId);
        Task<IEnumerable<FlightDetails>> GetAllFlightsAsync();

        Task<IEnumerable<FlightDetails>> SearchFlightsAsync(string source, string destination, DateTime date);
        Task<FlightDetails> AddFlightAsync(FlightDetails flight);
        Task<FlightDetails> UpdateFlightAsync(FlightDetails flight);
        Task DeleteFlightAsync(int flightId);
    }
}
