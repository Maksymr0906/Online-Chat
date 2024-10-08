﻿using AutoMapper;
using OnlineChat.Models.Domain;
using OnlineChat.Models.Dto.Message;

namespace OnlineChat.Mapping
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<CreateMessageRequestDto, Message>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
				.ForMember(dest => dest.SentTime, opt => opt.MapFrom(
                    src => DateTime.ParseExact(src.SentTime, "dd.MM.yyyy, HH:mm:ss", 
                    System.Globalization.CultureInfo.InvariantCulture)));

			CreateMap<UpdateMessageRequestDto, Message>();

            CreateMap<Message, MessageDto>();
        }
    }
}
