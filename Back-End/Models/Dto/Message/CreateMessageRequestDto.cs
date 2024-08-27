namespace OnlineChat.Models.Dto.Message
{
    public class CreateMessageRequestDto
    {
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public string SentTime { get; set; }
    }
}
