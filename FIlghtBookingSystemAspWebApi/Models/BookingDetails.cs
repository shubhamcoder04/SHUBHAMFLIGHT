using System.ComponentModel.DataAnnotations;

namespace FIlghtBookingSystemAspWebApi.Models
{
    public class BookingDetails
    {
        [Key]
        public int Booking_Id { get; set; }

        public int Flight_ID { get; set; }
        public decimal Total_Amount { get; set; }
        public int User_ID { get; set; }
        public int No_of_passengers { get; set; }
        public string TransactionNumber { get; set; }
        public DateTime DateTime { get; set; }

        public ICollection<Passenger> Passengers { get; set; }

        public UserTable User { get; set; }
    }

}
