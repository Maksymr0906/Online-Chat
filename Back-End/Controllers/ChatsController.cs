﻿using Microsoft.AspNetCore.Mvc;
using OnlineChat.Models.Dto.Chat;
using OnlineChat.Services.Interface;

namespace OnlineChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _service;

        public ChatsController(IChatService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChat([FromBody] CreateChatRequestDto request)
        {
            var response = await _service.CreateChatAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChats()
        {
            var response = await _service.GetChatsAsync();
            if (response.Count == 0)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetChatById([FromRoute] Guid id)
        {
            var response = await _service.GetChatByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateChat([FromRoute] Guid id, [FromBody] UpdateChatRequestDto request)
        {
            var response = await _service.UpdateChatAsync(id, request);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteChatById([FromRoute] Guid id)
        {
            var response = await _service.DeleteChatByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost("{chatId}/addUser")]
        public async Task<IActionResult> AddUserToChat([FromRoute] Guid chatId, [FromBody] AddUserToChatRequestDto request)
        {
            await _service.AddUserToChatAsync(chatId, request);
            return NoContent();
        }

        [HttpPost("{chatId}/removeUser")]
        public async Task<IActionResult> RemoveUserFromChat([FromRoute]  Guid chatId, [FromBody] RemoveUserFromChatRequestDto request)
        {
            await _service.RemoveUserFromChatAsync(chatId, request);
            return NoContent();
        }
    }
}
