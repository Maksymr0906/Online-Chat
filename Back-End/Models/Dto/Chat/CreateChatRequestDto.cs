namespace OnlineChat.Models.Dto.Chat
{
    public class CreateChatRequestDto
    {
        public string ChatName { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
