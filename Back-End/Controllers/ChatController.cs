using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineChat.Models.Dto.Chat;
using OnlineChat.Services.Interface;

namespace OnlineChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _service;

        public ChatController(IChatService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChat([FromBody] CreateChatRequestDto request)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChats()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetChatById([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateChat([FromRoute] Guid id, [FromBody] UpdateChatRequestDto request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteChatById([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
