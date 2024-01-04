using Chat.Data.Entities;
using Chat.Data.Entities.Models;
using Chat.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
namespace Chat.Domain.MethodesAndFunctions
{

    public class MethodesAndFunctions
    {
        static Random random = new Random();
        public static string LogIn(DbContextOptions<InternshipChatDbContext> options)
        {
            string password,email;

            do
            {
                Console.WriteLine("Unesite email adresu.");
                email = Console.ReadLine().Trim();
            } while (!UserHelper.FindIfEmailExists(email, options));
            
            do
            {
                Console.WriteLine("Unesite lozinku.");
                password = Console.ReadLine().Trim();
                if(!UserHelper.FindUserByEmailPassword(email, password, options))
                    TimeOut();
            } while (!UserHelper.FindUserByEmailPassword(email, password, options));
                return email;
            
        }

        public static string Registration(DbContextOptions<InternshipChatDbContext> options)
        {
            string newEmail, newPassword, newPasswordCheck, name, surname;
            do
            {
                Console.WriteLine("Unesite ime");
                name = Console.ReadLine();
                Console.WriteLine("Unesite prezime");
                surname = Console.ReadLine();


                do
                {
                    Console.Write("Unesite email: ");
                    newEmail = Console.ReadLine().Trim();
                }
                while (!CheckIsEmailValid(newEmail));
                
            } while (UserHelper.FindIfEmailExists(newEmail, options));
            
            do
            {
                Console.Write("Unesite lozinku: ");
                newPassword = Console.ReadLine().Trim();

                Console.Write("Unesite ponovno lozinku: ");
                newPasswordCheck = Console.ReadLine().Trim();
            } while (newPassword!=newPasswordCheck);
            

            string randomString = GenerateChapta();
            Console.WriteLine($"Kopirajte sljedeći random string: {randomString}");

            string confirmation = CheckIfEmptyString();

            if (CheckChapta(randomString,confirmation))
                Console.WriteLine("Uspješno ste se registrirali");
            else
                Console.WriteLine("Pokušajte ponovno");

            var newUser = new User(name, surname,newEmail,false,newPassword);

            UserHelper.AddNewUser(newUser,options);
            return newEmail;
        }

        public static string GenerateChapta()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";

            char randomChar = chars[random.Next(chars.Length)];
            char randomNumber = numbers[random.Next(numbers.Length)];

            string randomString = $"{randomChar}{randomNumber}";

            return randomString;
        }

        public static bool CheckChapta(string generatedString, string enteredString)
        {
            return generatedString.Equals(enteredString, StringComparison.OrdinalIgnoreCase);
        }

        static bool CheckIsEmailValid(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
        static string CheckIfEmptyString()
        {
            string enteredString;
            do
            {
                enteredString = Console.ReadLine();

                if (string.IsNullOrEmpty(enteredString))
                {
                    Console.WriteLine("Unos nije dopušten. Pokušajte ponovno.");
                }
            } while (string.IsNullOrEmpty(enteredString));

            return enteredString;
        }

        static void TimeOut()
        {
            Console.WriteLine("Pogrešna lozinka. Pauza od 10 sekundi...");
            Thread.Sleep(1000);
            Console.WriteLine("Nastavak izvođenja programa nakon pauze.");
        }
    }
}

