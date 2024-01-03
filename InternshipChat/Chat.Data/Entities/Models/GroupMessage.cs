namespace Chat.Data.Entities.Models
{
    public class GroupMessage : Message
    {
        public int IdGroup { get; set; }

        public ICollection<GroupChat> GroupMessages { get; set; } = new List<GroupChat>();

        public GroupMessage(int idSender, int idGroup, string messageContent): base(idSender, messageContent)
        {
            IdGroup = idGroup;
        }
    } 
}
