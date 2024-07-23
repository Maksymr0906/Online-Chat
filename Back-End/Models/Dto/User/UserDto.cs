namespace OnlineChat.Models.Dto.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public ICollection<Guid> CreatedChatIds { get; set; }
        public ICollection<Guid> ParticipatingChatIds { get; set; }
        public ICollection<Guid> MessageIds { get; set; }
    }
}
