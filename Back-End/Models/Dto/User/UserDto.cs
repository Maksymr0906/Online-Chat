using OnlineChat.Models.Dto.Chat;
using OnlineChat.Models.Dto.Message;

namespace OnlineChat.Models.Dto.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public ICollection<ChatDto> CreatedChats { get; set; }
        public ICollection<ChatDto> ParticipatingChats { get; set; }
        public ICollection<MessageDto> Messages { get; set; }
    }
}
