namespace Chat.Data.Entities.Models
{
    public class PrivateMessage
    {
       
        public User? User { get; set; }

        public int Id { get; set; }
        public int IdSender { get; set; }
        public int IdReciver { get; set; }
        public string? MessageContent { get; set; }
        public DateTimeOffset SentAt { get; set; }

        public PrivateMessage(int idSender, int idReciver, string messageContent)
        {
            Id = GenerateUniqueId();
            IdSender = idSender;
            IdReciver = idReciver;
            MessageContent = messageContent;
            SentAt = DateTime.Now;
        }

        protected PrivateMessage(int idSender, string messageContent)
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



