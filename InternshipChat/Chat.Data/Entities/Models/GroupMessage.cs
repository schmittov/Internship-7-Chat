using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.Entities.Models
{
    public class GroupMessage : Message
    {
        public int IdGroup { get; set; }

        public GroupMessage(int idSender, int idGroup, string messageContent): base(idSender, messageContent)
        {
            IdGroup = idGroup;
        }
    }
}
