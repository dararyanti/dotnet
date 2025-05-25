using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using training.Models.DTO;
using training.Exceptions;
using training.Repositories;

namespace training.Controllers
{
    [EnableCors("GatewayCors")]
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Authentication API for user registration and login")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("register")]
        [SwaggerOperation(Summary = "Register a new user", Description = "Provide username, password, and optional roles")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Invalid registration request");
            }

            var existingUserByUsername = await _userManager.FindByNameAsync(request.Username);
            var existingUserByEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingUserByUsername != null)
            {
                throw new BadRequestException($"Username '{request.Username}' is already taken.");
            }

            if (existingUserByEmail != null)
            {
                throw new BadRequestException($"Email '{request.Email}' is already registered.");
            }

            var newUser = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User creation failed. Ensure password meets the requirements.");
            }

            if (request.Roles != null && request.Roles.Any())
            {
                var roleResult = await _userManager.AddToRolesAsync(newUser, request.Roles);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Failed to assign roles to the user.");
                }
            }

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "User login", Description = "Authenticate with username or email and password, returns JWT token")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Invalid login request");
            }

            IdentityUser? user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(request.Username);
                if (user == null)
                {
                    throw new UserNotFoundException("No user found with the given username or email.");
                }
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("Incorrect password.");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenRepository.CreateJWTToken(user, roles.ToList());

            Response.Cookies.Append("token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });

            var response = new LoginResponseDto
            {
                JwtToken = token
            };

            return Ok(response);
        }
    }
}
