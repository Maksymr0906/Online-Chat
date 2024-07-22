using OnlineChat.Models.Dto.Message;
using OnlineChat.Models.Dto.User;

namespace OnlineChat.Models.Dto.Chat
{
    public class ChatDto
    {
        public Guid Id { get; set; }
        public string ChatName { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public ICollection<MessageDto> Messages { get; set; }
        public ICollection<UserDto> Participants { get; set; }
    }
}
