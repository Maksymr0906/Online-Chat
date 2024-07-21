namespace OnlineChat.Models.Domain
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public ICollection<Chat> CreatedChats { get; set; }
        public ICollection<Chat> ParticipatingChats { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
