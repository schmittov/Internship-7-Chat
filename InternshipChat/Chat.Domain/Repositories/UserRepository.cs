using Chat.Data.Entities;
using Chat.Data.Entities.Models;

namespace Chat.Domain.Repositories
{
    public class UsersRepository
    {
        private readonly InternshipChatDbContext dbContext;

        public UsersRepository(InternshipChatDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GetUserByEmailPassword(string email, string password)
        {
            return dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        public User GetUserByEmail(string email)
        {
            return dbContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetUserById(int userId)
        {
            return dbContext.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
