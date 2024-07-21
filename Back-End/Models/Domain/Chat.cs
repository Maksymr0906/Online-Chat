namespace OnlineChat.Models.Domain
{
    public class Chat : BaseEntity
    {
        public string ChatName { get; set; }
        public Guid CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public User User { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<User> Participants { get; set; }
    }
}
