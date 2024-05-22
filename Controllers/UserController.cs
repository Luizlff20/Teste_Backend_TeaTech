using Microsoft.AspNetCore.Mvc;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Services;
using Backend_TeaTech.DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Backend_TeaTech.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend_TeaTech.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// List all users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users.
        /// </remarks>
        [Authorize(Roles = "Employee:Coordinator")]
        [HttpGet("list")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult ListAllUser()
        {
            try
            {
                var users = _userService.ListAllUser();
                return Ok(new { message = "List retrieved successfully", users });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("You are not authorized to perform this action.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the list of users: {ex.Message}");
            }
        }

        /// <summary>
        /// User login.
        /// </summary>
        /// <remarks>
        /// Logs a user into the system.
        /// </remarks>
        [HttpPost("login")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        public IActionResult Login([FromBody] UserRequestDTO req)
        {
            try
            {
                if (string.IsNullOrEmpty(req.Email) || string.IsNullOrEmpty(req.Password))
                {
                    return BadRequest("Invalid login data");
                }

                string token = _userService.Login(req.Email, req.Password);

                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(new { message = "Login successful", Token = token });
                }
                else
                {
                    return Unauthorized(new { message = "Invalid email or password" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }

        }

        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <remarks>
        /// Deletes a user by its ID.
        /// </remarks>
        [Authorize(Roles = "Employee:Coordinator")]
        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                _userService.DeleteUserById(id);
                return Ok("User deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("You are not authorized to perform this action.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Get a user by ID.
        /// </summary>
        /// <remarks>
        /// Retrieves a user by its ID.
        /// </remarks>
        [Authorize]
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult GetUserById(Guid id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }
                return Ok(user);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("You are not authorized to perform this action.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request." + ex);
            }
        }
    }
}