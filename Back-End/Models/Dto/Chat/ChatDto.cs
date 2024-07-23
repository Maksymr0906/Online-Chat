namespace OnlineChat.Models.Dto.Chat
{
    public class ChatDto
    {
        public Guid Id { get; set; }
        public string ChatName { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public ICollection<Guid> MessageIds { get; set; }
        public ICollection<Guid> ParticipantIds { get; set; }
    }
}
