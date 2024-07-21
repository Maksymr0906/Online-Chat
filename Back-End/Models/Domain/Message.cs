namespace OnlineChat.Models.Domain
{
    public class Message : BaseEntity
    {
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public DateTime SentTime { get; set; }
        public Chat Chat { get; set; }
        public User User { get; set; }
    }
}
