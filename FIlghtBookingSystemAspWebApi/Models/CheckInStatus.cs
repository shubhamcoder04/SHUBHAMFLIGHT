using System.ComponentModel.DataAnnotations;

namespace FIlghtBookingSystemAspWebApi.Models
{
    public class CheckInStatus
    {
        [Key]
        public int Check_in_Id { get; set; }
        public bool Check_in_Status { get; set; }
        public string Seat_Number { get; set; }
        public int Booking_Id { get; set; }
        public int Flight_ID { get; set; }
        public BookingDetails BookingDetails { get; set; }
    }

}
