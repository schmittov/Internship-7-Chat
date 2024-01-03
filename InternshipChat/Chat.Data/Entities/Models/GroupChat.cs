namespace Chat.Data.Entities.Models
{
    public class GroupChat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserGroup> GroupUsers { get; set; } = new List<UserGroup>();

        public GroupChat(string name)
        {
            Id = Id = GenerateUniqueId();
            Name = name;
        }
        private static int GenerateUniqueId()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}
