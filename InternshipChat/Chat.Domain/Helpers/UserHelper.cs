using Chat.Data.Entities.Models;
using Chat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Chat.Domain.Repositories;
using Chat.Domain.MethodesAndFunctions;

namespace Chat.Domain.Helpers
{
    public static class UserHelper
    {
        public static bool IsAdmin(string userEmail, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);
                var user = userRepository.GetUserByEmail(userEmail);

                if (user != null && user.IsAdmin)
                {
                    return true;
                }

                return false;
            }
        }
        public static bool FindUserByEmailPassword(string email, string password, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);
                var user = userRepository.GetUserByEmailPassword(email, password);

                if (user != null)
                    return true;
                
                else
                    return false;
            }
        }
        public static bool FindIfEmailExists(string email, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);
                var user = userRepository.GetUserByEmail(email);

                if (user != null)
                    return true;
                
                else
                    return false;
                
            }
        }

        public static bool FindIfEmailPasswordCorrect(string email,string password, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);
                var user = userRepository.GetUserByEmail(email);

                if (user != null)
                    return true;

                else
                    return false;

            }
        }

        public static void ChangeEmail(string userEmail, DbContextOptions<InternshipChatDbContext> options)////////
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);

                var user = userRepository.GetUserByEmail(userEmail);

                if (user != null)
                {
                    Console.Write("Enter your new email address: ");
                    string newEmail = Console.ReadLine();

                    // Provjerite je li novi e-mail već registriran
                    var existingUserWithNewEmail = userRepository.GetUserByEmail(newEmail);
                    if (existingUserWithNewEmail == null)
                    {
                        user.Email = newEmail;
                        dbContext.SaveChanges();

                        Console.WriteLine("Uspješno je promjenjena adresa");
                    }
                    else
                    {
                        Console.WriteLine("Email se već koristi");
                    }
                }
            }
        }

        public static void ChangePassword(string userEmail, DbContextOptions<InternshipChatDbContext> options)///////////
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);

                var user = userRepository.GetUserByEmail(userEmail);

                if (user != null)
                {
                    Console.Write("Unesi novu lozinku: ");
                    string newPassword = Console.ReadLine();

                    user.Password = newPassword;
                    dbContext.SaveChanges();

                    Console.WriteLine("Lozinka promjenjena.");
                }
            }
        }

        public static void AddNewUser(User newUser, DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);

                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();
            }
        }


        public static void DeleteUser(DbContextOptions<InternshipChatDbContext> options)
        {
            using (var dbContext = new InternshipChatDbContext(options))
            {
                var userRepository = new UsersRepository(dbContext);

                var allUsers = dbContext.Users.ToList();

                int currentOption = 0;

                while (true)
                {
                    Console.Clear();
                    Navigation.PrintManagementUserOptions(allUsers, currentOption);

                    ConsoleKeyInfo key = Console.ReadKey();

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            currentOption = Math.Max(-1, currentOption - 1);
                            break;
                        case ConsoleKey.DownArrow:
                            currentOption = Math.Min(allUsers.Count - 1, currentOption + 1);
                            break;
                        case ConsoleKey.Enter:
                            if (currentOption == -1)
                                return;

                            var selectedUser = allUsers[currentOption];
                            Console.WriteLine($"Odabrali ste korisnika: {selectedUser.Name} {selectedUser.Surname} ({selectedUser.Email})");

                            
                            string[] choices = { "Da", "Ne" };

                            int confirmationChoice = Navigation.YesNoNavigation();

                            if (confirmationChoice == 0)
                            {
                                selectedUser = allUsers[currentOption];
                                Console.WriteLine($"Odabrali ste izbrisati korisnika: {selectedUser.Email}");

                                dbContext.Users.Remove(selectedUser);
                                dbContext.SaveChanges();
                                Console.WriteLine($"Korisnik {selectedUser.Email} uspješno izbrisan.");
                                Console.ReadKey();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Brisanje korisnika otkazano.");
                                Console.ReadKey();
                                return;
                            }

                            Console.ReadKey();
                            return;
                    }
                }
            }
        }
    }
}
