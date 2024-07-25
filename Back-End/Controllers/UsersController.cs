using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineChat.Models.Dto.User;
using OnlineChat.Services.Interface;

namespace OnlineChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto request)
        {
            var response = await _service.CreateUserAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _service.GetUsersAsync();
            if (response.Count == 0)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var response = await _service.GetUserByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequestDto request)
        {
            var response = await _service.UpdateUserAsync(id, request);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteUserById([FromRoute] Guid id)
        {
            var response = await _service.DeleteUserByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetUserByName([FromRoute] string name)
        {
            var response = await _service.GetUserByName(name);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
