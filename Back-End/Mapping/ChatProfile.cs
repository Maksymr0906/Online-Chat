using AutoMapper;
using OnlineChat.Models.Domain;
using OnlineChat.Models.Dto.Chat;

namespace OnlineChat.Mapping
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<CreateChatRequestDto, Chat>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Messages, opt => opt.Ignore())
                .ForMember(dest => dest.Participants, opt => opt.Ignore());

            CreateMap<Chat, ChatDto>()
                .ForMember(dest => dest.MessageIds, opt => opt.MapFrom(src => src.Messages.Select(m => m.Id)))
                .ForMember(dest => dest.ParticipantIds, opt => opt.MapFrom(src => src.Participants.Select(p => p.Id)));

            CreateMap<UpdateChatRequestDto, Chat>()
                .ForMember(dest => dest.Messages, opt => opt.Ignore())
                .ForMember(dest => dest.Participants, opt => opt.Ignore());

            CreateMap<Chat, ChatWithCreatorDto>()
               .ForMember(dest => dest.CreatorUserName, opt => opt.MapFrom(src => src.User.UserName))
               .ForMember(dest => dest.MessageIds, opt => opt.MapFrom(src => src.Messages.Select(m => m.Id)))
               .ForMember(dest => dest.ParticipantIds, opt => opt.MapFrom(src => src.Participants.Select(p => p.Id)));
        }
    }
}
