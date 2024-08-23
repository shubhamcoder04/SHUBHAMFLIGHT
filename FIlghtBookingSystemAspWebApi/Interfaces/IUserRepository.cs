using FIlghtBookingSystemAspWebApi.DTOs.FIlghtBookingSystemAspWebApi.Dtos;
using FIlghtBookingSystemAspWebApi.Models;

namespace FIlghtBookingSystemAspWebApi.Interfaces
{
    public interface IUserRepository
    {
        Task<UserTable> GetUserByIdAsync(int userId);
        Task<UserTable> AddUserAsync(UserTable user);
        Task<LoginResponseDto?> AuthenticateUserAsync(UserLoginDto login);


        Task<UserTable> GetUserByEmailAsync(string email);
    }
}
