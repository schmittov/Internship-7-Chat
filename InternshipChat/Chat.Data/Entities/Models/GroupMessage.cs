namespace Chat.Data.Entities.Models
{
    public class GroupMessage
    {
        public GroupChat? GroupChat { get; set; }

        public int Id { get; set; }
        public int IdSender { get; set; }
        public int GroupChatId { get; set; }
        public string? MessageContent { get; set; }
        public DateTimeOffset SentAt { get; set; }

        public GroupMessage(int idSender, int groupChatId, string messageContent)
        {
            Id = GenerateUniqueId();
            IdSender = idSender;
            GroupChatId = groupChatId;
            MessageContent = messageContent;
            SentAt = DateTimeOffset.UtcNow;
        }

        protected GroupMessage(int idSender, string messageContent)
        {
            IdSender = idSender;
            MessageContent = messageContent;
        }

        private static int GenerateUniqueId()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}
