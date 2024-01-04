using Chat.Data.Entities.Models;
using Chat.Data.Entities;

namespace Chat.Domain.Repositories
{
    public class GroupRepository
    {
        private readonly InternshipChatDbContext dbContext;

        public GroupRepository(InternshipChatDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<GroupChat> GetGroupChatsForUser(int userId)
        {
            var groupChats = dbContext.UserGroups
                .Where(ug => ug.UserId == userId)
                .Select(ug => ug.GroupChat)
                .ToList();

            return groupChats;
        }
        public GroupChat GetGroupChatById(int groupId)
        {
            return dbContext.GroupChats.Find(groupId);
        }

        
    }
}
