namespace OnlineChat.Models.Dto.Chat
{
    public class ChatWithCreatorDto
    {
        public Guid Id { get; set; }
        public string ChatName { get; set; }
        public Guid CreatorUserId { get; set; }
        public string CreatorUserName { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<string> ParticipantIds { get; set; }
        public List<string> MessageIds { get; set; }
    }
}
