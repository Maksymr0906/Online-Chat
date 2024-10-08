﻿using OnlineChat.Models.Dto.Chat;

namespace OnlineChat.Services.Interface
{
    public interface IChatService
    {
        Task<ChatDto> CreateChatAsync(CreateChatRequestDto request);
        Task<ICollection<ChatDto>> GetChatsAsync();
        Task<ChatDto?> GetChatByIdAsync(Guid id);
        Task<ChatDto?> UpdateChatAsync(Guid id, UpdateChatRequestDto request);
        Task<ChatDto?> DeleteChatByIdAsync(Guid id);
        Task AddUserToChatAsync(Guid chatId, AddUserToChatRequestDto request);
        Task RemoveUserFromChatAsync(Guid chatId, RemoveUserFromChatRequestDto request);
    }
}
