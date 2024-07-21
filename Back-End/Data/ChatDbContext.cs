using Microsoft.EntityFrameworkCore;
using OnlineChat.Models.Domain;

namespace OnlineChat.Data
{
    public class ChatDbContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        public ChatDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-many relationship between Chat and Message
            modelBuilder.Entity<Chat>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Chat)
                .HasForeignKey(m => m.ChatId);

            // Configure one-to-many relationship between User and Message
            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId);

            // Configure many-to-many relationship between Chat and User
            modelBuilder.Entity<Chat>()
                .HasMany(c => c.Participants)
                .WithMany(u => u.ParticipatingChats)
                .UsingEntity(j => j.ToTable("ChatParticipants"));

            // Configure one-to-many relationship between User and Chat
            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedChats)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.CreatorUserId);
        }
    }
}
