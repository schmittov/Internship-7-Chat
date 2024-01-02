using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.Entities.Models
{
    public abstract class Message
    {
        public int Id { get; set; }
        public int IdSender { get; set; }
        public int IdReciver { get; set; }
        public string? MessageContent { get; set; }
        public DateTime SentAt { get; set; }

        public Message(int idSender, int idReciver, string messageContent)
        {
            Id = GenerateUniqueId();
            IdSender = idSender;
            IdReciver = idReciver;
            MessageContent = messageContent;
            SentAt = DateTime.Now;
        }

        protected Message(int idSender, string messageContent)
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
