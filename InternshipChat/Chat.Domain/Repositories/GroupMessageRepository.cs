using Chat.Data.Entities;
using Chat.Data.Entities.Models;

namespace Chat.Domain.Repositories
{
    public class GroupMessageRepository
    {
        private readonly InternshipChatDbContext dbContext;

        public GroupMessageRepository(InternshipChatDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void AddGroupMessage(GroupMessage groupMessage)
        {
            dbContext.GroupMessages.Add(groupMessage);
            dbContext.SaveChanges();
        }
    }

    
}
