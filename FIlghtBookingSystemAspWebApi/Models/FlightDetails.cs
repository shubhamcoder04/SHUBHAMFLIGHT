using System.ComponentModel.DataAnnotations;

namespace FIlghtBookingSystemAspWebApi.Models
{
    public class FlightDetails
    {
        [Required]
        [Key]
        public int Flight_ID { get; set; }
        public string Airline { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]

        public string Destination { get; set; }
        public DateTime Departure_Time { get; set; }
        public DateTime Arrival_Time { get; set; }
        public int Total_Seats { get; set; }
        public decimal Fare { get; set; }
    }

}
