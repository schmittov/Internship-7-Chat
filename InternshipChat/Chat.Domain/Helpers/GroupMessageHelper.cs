using Chat.Data.Entities;
using Chat.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Helpers
{
    public class GroupMessageHelper
    {
        public static void PrintChannelMessages(int groupId, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var groupRepository = new GroupRepository(dbContext);

                var groupChat = groupRepository.GetGroupChatById(groupId);

                var groupMessages = dbContext.GroupMessages
                    .Where(gm => gm.GroupChatId == groupId)
                    .OrderBy(gm => gm.SentAt)
                    .ToList();

                Console.WriteLine($"Poruke u grupi \"{groupChat.Name}\":");

                foreach (var message in groupMessages)
                {
                    var sender = dbContext.Users.Find(message.IdSender);  
                    Console.WriteLine($"({sender.Email}) - {message.SentAt}: {message.MessageContent}");
                }
            }
        }
    }
}
