namespace FIlghtBookingSystemAspWebApi.DTOs
{
    
        public class BookingDetailsDto
        {
            public int Flight_ID { get; set; }

            public int User_ID { get; set; }
        public int No_of_passengers { get; set; }
        
        public int Booking_Id { get; set; }
        public List<PassengerDto> Passengers { get; set; }
        }
    }

