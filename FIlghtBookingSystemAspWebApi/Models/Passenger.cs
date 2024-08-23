using System.ComponentModel.DataAnnotations;

namespace FIlghtBookingSystemAspWebApi.Models
{
    public class Passenger
    {
        [Key]
        public int Passenger_Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int BookingId { get; set; }
    }

}
