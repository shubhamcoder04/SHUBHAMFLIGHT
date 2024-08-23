using FIlghtBookingSystemAspWebApi.Models;

namespace FIlghtBookingSystemAspWebApi.Interfaces
{
    public interface ICheckInStatusRepository
    {
        Task<CheckInStatus> AddAsync(CheckInStatus checkInStatus);
    }
}
