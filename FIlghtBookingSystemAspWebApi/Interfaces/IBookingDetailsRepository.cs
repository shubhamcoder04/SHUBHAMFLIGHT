using FIlghtBookingSystemAspWebApi.Models;

namespace FIlghtBookingSystemAspWebApi.Interfaces
{
    public interface IBookingDetailsRepository
    {
        Task<BookingDetails> AddBookingAsync(BookingDetails booking);
        Task<BookingDetails> GetBookingByIdAsync(int bookingId);

        Task<bool> CancelBookingAsync(int bookingId);
    }

}
