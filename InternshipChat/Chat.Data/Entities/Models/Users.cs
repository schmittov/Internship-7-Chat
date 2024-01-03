namespace Chat.Data.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public ICollection<PrivateMessage> PrivateMessages { get; set; } = new List<PrivateMessage>();

        public User(string name, string surname, string email, bool isAdmin, string password)
        {
            Id = Id = GenerateUniqueId();
            Name = name;
            Surname = surname;
            Email = email;
            IsAdmin = isAdmin;
            Password = password;
        }
        private static int GenerateUniqueId()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}
   