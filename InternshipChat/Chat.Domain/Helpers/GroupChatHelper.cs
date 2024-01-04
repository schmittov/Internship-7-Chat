using Chat.Data.Entities;
using Chat.Data.Entities.Models;
using Chat.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Chat.Domain.MethodesAndFunctions;
namespace Chat.Domain.Helpers
{
    public static class GroupChatHelper
    {
        public static void WriteGroups(int userId, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var groupRepository = new GroupRepository(dbContext);
                var groupChats = groupRepository.GetGroupChatsForUser(userId);

                Console.WriteLine($"Group Chats for User {userId}:");
                foreach (var groupChat in groupChats)
                {
                    Console.WriteLine($"Group Chat Name: {groupChat.Name}");
                }
            }
        }


        public static void WriteGroupsForUser(int userId, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var groupRepository = new GroupRepository(dbContext);

                var userGroups = dbContext.UserGroups.Where(ug => ug.UserId == userId).Select(ug => ug.GroupChatId).ToList();
                var groupsNotJoined = dbContext.GroupChats.Where(gc => !userGroups.Contains(gc.GroupChatId)).ToList();

                Console.WriteLine($"Groups not joined by User {userId}:");
                foreach (var groupChat in groupsNotJoined)
                {
                    int participantsCount = dbContext.UserGroups.Count(ug => ug.GroupChatId == groupChat.GroupChatId);
                    Console.WriteLine($"Group Chat Name: {groupChat.Name}, Participants: {participantsCount}");
                }
            }
        }

        public static void WriteChannelsNotJoinedByUser(string userEmail, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                Console.Clear();
                var userRepository = new UsersRepository(dbContext);
                var groupRepository = new GroupRepository(dbContext);

                var currentUser = userRepository.GetUserByEmail(userEmail);


                var userGroups = dbContext.UserGroups.Where(ug => ug.UserId == currentUser.Id).Select(ug => ug.GroupChatId).ToList();
                var groupsNotJoined = dbContext.GroupChats.Where(gc => !userGroups.Contains(gc.GroupChatId)).ToList();

                Console.WriteLine("Niste sudionici sljedećih grupa:");
                foreach (var groupChat in groupsNotJoined)
                {
                    int participantsCount = dbContext.UserGroups.Count(ug => ug.GroupChatId == groupChat.GroupChatId);

                    Console.WriteLine($"Ime grupe: {groupChat.Name}, Broj sudionika: {participantsCount}");
                }
            }
        }


        public static void WriteUserChannelsByEmail(string userEmail, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);

                var currentUser = userRepository.GetUserByEmail(userEmail);


                var userChannels = dbContext.UserGroups
                    .Where(ug => ug.UserId == currentUser.Id)
                    .Select(ug => ug.GroupChat)
                    .ToList();

                Console.WriteLine($"Sudionici ste sljedećih grupa:");

                foreach (var userChannel in userChannels)
                {
                    Console.WriteLine($"{userChannel.Name}");
                }
                
            }
            
        }


        public static void CreateAndJoinNewChannel(string creatorEmail, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                Console.CursorVisible = true;
                Console.Clear();
                string channelName;
                Console.WriteLine("Unesite ime kanala");
                channelName = Console.ReadLine();
                var userRepository = new UsersRepository(dbContext);
                var groupRepository = new GroupRepository(dbContext);

                var creatorUser = userRepository.GetUserByEmail(creatorEmail);

                var newChannel = new GroupChat(channelName);

                var userGroup = new UserGroup
                {
                    UserId = creatorUser.Id,
                    GroupChatId = newChannel.GroupChatId
                };

                dbContext.GroupChats.Add(newChannel);
                dbContext.UserGroups.Add(userGroup);
                dbContext.SaveChanges();

                Console.WriteLine($"Kreirali ste kanal imena {channelName}.");
            }
        }

        public static void WriteUserChannels(string userEmail, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);
                var groupRepository = new GroupRepository(dbContext);

                var currentUser = userRepository.GetUserByEmail(userEmail);

                if (currentUser == null)
                {
                    Console.WriteLine($"Korisnik s emailom {userEmail} nije pronađen.");
                    return;
                }

                var userGroups = dbContext.UserGroups
                    .Where(ug => ug.UserId == currentUser.Id)
                    .Select(ug => ug.GroupChat)
                    .ToList();

                Console.WriteLine($"Kanali u kojima se korisnik {currentUser.Name} nalazi:");

                foreach (var userGroup in userGroups)
                {
                    Console.WriteLine($"{userGroup.GroupChatId}. {userGroup.Name}");
                }
            }
        }

        public static void PrintChannelMessage(string userEmail, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);
                var currentUser = userRepository.GetUserByEmail(userEmail);

                var allGroups = dbContext.UserGroups
                .Where(ug => ug.UserId == currentUser.Id)
                .Select(ug => ug.GroupChat)
                .ToList();

           


                int currentOption = 0;
                while (true)
                {
                    Console.Clear();
                    currentOption = Navigation.ChannelNavigation(allGroups);

                    Console.Clear();
                    GroupMessageHelper.PrintChannelMessages(currentOption+1,options);

                    if (currentOption == -1)
                        break;


                    var selectedContact = allGroups[currentOption];
                    var selectedGroup = allGroups[currentOption];

                    Console.ReadKey();
                    int action =Navigation.GroupSendMessageNavigation();
                    if (action == 0)
                    {
                        Console.Clear();
                        break;
                    }

                    else if (action == 1)
                    {
                        Console.Write("Napišite poruku: ");
                        string messageContent = Console.ReadLine();

                        
                        var newMessage = new GroupMessage(currentUser.Id, selectedGroup.GroupChatId, messageContent);

                        dbContext.GroupMessages.Add(newMessage);
                        dbContext.SaveChanges();
                    }
                }
            }
        }


    }
}
