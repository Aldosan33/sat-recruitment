using Microsoft.AspNetCore.Mvc;
using SatRecruitment.Domain.Models.Request;
using SatRecruitment.Infrastructure.Services;

namespace SatRecruitment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreationDTO model)
        {
            var result = await _userService.AddUserAsync(model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
