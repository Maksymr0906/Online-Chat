using AutoMapper;
using OnlineChat.Models.Domain;
using OnlineChat.Models.Dto.Chat;

namespace OnlineChat.Mapping
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<CreateChatRequestDto, Chat>();
            CreateMap<UpdateChatRequestDto, Chat>();
            CreateMap<Chat, ChatDto>();
        }
    }
}
