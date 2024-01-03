namespace Chat.Data.Entities.Models
{
    public class UserGroup
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int GroupChatId { get; set; }
        public GroupChat GroupChat { get; set; } = null!;
    } 
}
