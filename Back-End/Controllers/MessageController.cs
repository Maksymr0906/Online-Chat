using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineChat.Models.Dto.Message;
using OnlineChat.Services.Interface;

namespace OnlineChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessageRequestDto request)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetMessageById([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateMessage([FromRoute] Guid id, [FromBody] UpdateMessageRequestDto request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteMessageById([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
