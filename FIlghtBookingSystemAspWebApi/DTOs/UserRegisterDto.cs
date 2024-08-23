using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FIlghtBookingSystemAspWebApi.DTOs
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone_no { get; set; }

        public string Role { get; set; }
    }
}
