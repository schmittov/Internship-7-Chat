namespace Chat.Data.Entities.Models
{
    public class GroupChat
    {
        public int GroupChatId { get; set; }
        public string Name { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public ICollection<GroupMessage> GroupMessages { get; set; } = new List<GroupMessage>();

        public GroupChat(string name)
        {
            GroupChatId = GroupChatId = GenerateUniqueId();
            Name = name;
        }
        private static int GenerateUniqueId()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}
