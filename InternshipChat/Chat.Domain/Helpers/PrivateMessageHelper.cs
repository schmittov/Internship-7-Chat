using Chat.Data.Entities;
using Chat.Domain.MethodesAndFunctions;
using Chat.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chat.Domain.Helpers
{
    public static class PrivateMessageHelper
    {
        public static void PrintUsersByMessageHistory(string userEmail, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);

                var currentUser = userRepository.GetUserByEmail(userEmail);

                if (currentUser == null)
                {
                    Console.WriteLine($"Korisnik s emailom {userEmail} nije pronađen.");
                    return;
                }

                Console.WriteLine($"Trenutni korisnik ID: {currentUser.Id}");

                var chatHistory = dbContext.PrivateMessages
                    .Where(pm => pm.IdSender == currentUser.Id || pm.IdSender == currentUser.Id)
                    .OrderBy(pm => pm.SentAt)
                    .ToList();

                Console.WriteLine($"{userEmail}");

                var uniqueUserIds = chatHistory
                    .SelectMany(pm => new[] { pm.IdSender, pm.IdReciver })
                    .Distinct();

                foreach (var userId in uniqueUserIds)
                {
                    if (userId != currentUser.Id)
                    {
                        var user = userRepository.GetUserById(userId);
                        if (user != null)
                        {
                            Console.WriteLine($"{user.Name} {user.Surname} ({user.Email})");
                        }
                    }
                }
            }

        }

        public static void WriteNewMessage(string userEmail, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);
                var currentUser = userRepository.GetUserByEmail(userEmail);


                Console.WriteLine($"Trenutni korisnik ID: {currentUser.Id}");
                var allContacts = dbContext.Users
                    .Where(user => user.Email != userEmail)
                    .ToList();

                int currentOption = 0;

                while (true)
                {
                    Console.Clear();        
                    currentOption = Navigation.UserNavigation(allContacts);
        
                    if (currentOption == -1)
                        break;
                    

                    var selectedContact = allContacts[currentOption];

                    Console.Clear();
                    Console.WriteLine($"Odabrali ste kontakt: {selectedContact.Name} {selectedContact.Surname} ({selectedContact.Email})");
                    
                    Console.Write("Unesite poruku: ");
                    string messageContent = Console.ReadLine();

                    break;
                }
            }
        }
    }
}
