using Microsoft.AspNetCore.Mvc;
using OnlineChat.Models.Dto.Message;
using OnlineChat.Services.Interface;

namespace OnlineChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessagesController(IMessageService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessageRequestDto request)
        {
            var response =  await _service.CreateMessageAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var response = await _service.GetMessagesAsync();
            if (response.Count == 0)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetMessageById([FromRoute] Guid id)
        {
            var response = await _service.GetMessageByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateMessage([FromRoute] Guid id, [FromBody] UpdateMessageRequestDto request)
        {
            var response = await _service.UpdateMessageAsync(id, request);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteMessageById([FromRoute] Guid id)
        {
            var response = await _service.DeleteMessageByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
