using System.ComponentModel.DataAnnotations;

namespace FIlghtBookingSystemAspWebApi.Models
{
    public class UserTable
    {
        [Key]
        [Required(ErrorMessage = "User Id is required")]
        public int User_ID { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, ErrorMessage = "Password length cannot exceed 15 characters")]
        public string Password { get; set; }

        [StringLength(50, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string Phone_no { get; set; }
        public string Role { get; set; }

        public ICollection<BookingDetails> BookingDetails { get; set; }
    }

}
