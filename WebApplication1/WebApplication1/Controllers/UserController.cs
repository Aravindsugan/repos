using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUserDetails/{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var userDetails = await _userService.GetUserDetails(id);

            if (userDetails == null)
            {
                return NotFound();
            }

            return Ok(userDetails);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            var createdUser = await _userService.CreateUser(createUserRequest);

            if (createdUser == null)
            {
                return BadRequest("Failed to create user");
            }

            return Created("", createdUser);
        }
    }
}