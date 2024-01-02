using Chat.Data.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chat.Data.Entities.Models
{
    public class PrivateMessage : Message
    {
        public int IdRecipient { get; set; }

        public PrivateMessage(int idSender, int idRecipient, string messageContent): base(idSender, messageContent)
        {
            IdRecipient = idRecipient;
        }
    }


}
