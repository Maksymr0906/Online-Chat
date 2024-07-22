using AutoMapper;
using OnlineChat.Models.Domain;
using OnlineChat.Models.Dto.Message;

namespace OnlineChat.Mapping
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<CreateMessageRequestDto, Message>();
            CreateMap<UpdateMessageRequestDto, Message>();
            CreateMap<Message, MessageDto>();
        }
    }
}
