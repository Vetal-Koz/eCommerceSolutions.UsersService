using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByUserId([FromQuery] Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("Invalid User ID");
            } 
            UserDTO response = await _usersService.GetUserByUserId(userId);
            
            if (response == null)
            {
                return NotFound(response);
            }
            
            return Ok(response);
        }
    }
}
