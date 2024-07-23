namespace OnlineChat.Models.Dto.Chat
{
    public class UpdateChatRequestDto
    {
        public string ChatName { get; set; }
        public Guid CreatorUserId { get; set; }
    }
}
