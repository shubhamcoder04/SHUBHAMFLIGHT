using Microsoft.AspNetCore.Mvc;
using FIlghtBookingSystemAspWebApi.Interfaces;
using FIlghtBookingSystemAspWebApi.Models;
using FIlghtBookingSystemAspWebApi.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FIlghtBookingSystemAspWebApi.DTOs.FIlghtBookingSystemAspWebApi.Dtos;

namespace FIlghtBookingSystemAspWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // Dependencies for the controller
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;



        // Constructor for injecting dependencies
        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            // Check if the user already exists by email

            var existingUser = await _userRepository.GetUserByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                return Conflict(new { message = "User with this email already exists." });
            }

            var user = new UserTable
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                Phone_no = userDto.Phone_no,
                Role = userDto.Role,
            };

            // Add the new user using the repository

            var createdUser = await _userRepository.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.User_ID }, createdUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginUser)
        {
            // Authenticate the user using the repository
            var res = await _userRepository.AuthenticateUserAsync(loginUser);
            if (res == null)
            {
                return Unauthorized();
            }
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            // Retrieve user details by ID
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


    }
}
