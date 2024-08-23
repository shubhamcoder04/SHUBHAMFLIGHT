using FIlghtBookingSystemAspWebApi.Data;
using FIlghtBookingSystemAspWebApi.DTOs.FIlghtBookingSystemAspWebApi.Dtos;
using FIlghtBookingSystemAspWebApi.Interfaces;
using FIlghtBookingSystemAspWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FIlghtBookingSystemAspWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        //to interact with database
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public UserRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Method to get a user by their ID asynchronously

        public async Task<UserTable> GetUserByIdAsync(int userId)
        {
            return await _context.UserTables.FindAsync(userId);
        }


        // Method to add a new user asynchronously

        public async Task<UserTable> AddUserAsync(UserTable user)
        {
            _context.UserTables.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Method to get a user by their email asynchronously
        public async Task<UserTable> GetUserByEmailAsync(string email) 
        {
            return await _context.UserTables.SingleOrDefaultAsync(u => u.Email == email);
        }

        // Method to authenticate a user asynchronously 

        public async Task<LoginResponseDto?> AuthenticateUserAsync(UserLoginDto req)
        {
            try
            {
                // Find the user by email and password

                var existingUser = await _context.UserTables.FirstOrDefaultAsync(x=>x.Email == req.Email && x.Password==req.Password);
                if (existingUser != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                    new Claim(ClaimTypes.NameIdentifier, existingUser.User_ID.ToString()),
                    new Claim(ClaimTypes.Email, existingUser.Email),
                    new Claim(ClaimTypes.Role, existingUser.Role)
                }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                        Issuer = _configuration["Jwt:Issuer"],
                        Audience = _configuration["Jwt:Audience"]
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var genToken = tokenHandler.WriteToken(token);
                    var res = new LoginResponseDto
                    {
                        token = genToken,
                    };
                    return res;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
}
