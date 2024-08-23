namespace FIlghtBookingSystemAspWebApi.DTOs
{
    namespace FIlghtBookingSystemAspWebApi.Dtos
    {
       

        public class UserLoginDto
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class LoginResponseDto
        {
            public string token { get; set; }
        }
    }

}
