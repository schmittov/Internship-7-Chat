using System.Text.RegularExpressions;

namespace Chat.Domain.MethodesAndFunctions
{
    public class MethodesAndFunctions
    {
        static Random random = new Random();
        public static void LogIn()
        {
            string mail = CheckIfMailExist();
            string password= CheckIfCorrectPassword(mail);
            Console.WriteLine(mail+" "+password);
        }

        public static void Registration()
        {
            Console.Write("Unesite email: ");
            string newEmail = CheckIfEmptyString();

            Console.Write("Unesite lozinku: ");
            string newPassword = CheckIfEmptyString();


            string randomString = GenerateChapta();
            Console.WriteLine($"Kopirajte sljedeći random string: {randomString}");

            string confirmation = CheckIfEmptyString();

            if (CheckChapta(randomString,confirmation))
                Console.WriteLine("Uspijeli ste");
            else
                Console.WriteLine("Niste uspijeli");

            //add new user to the database
        }

        static string GenerateChapta()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";

            char randomChar = chars[random.Next(chars.Length)];
            char randomNumber = numbers[random.Next(numbers.Length)];

            string randomString = $"{randomChar}{randomNumber}";

            return randomString;
        }

        static bool CheckChapta(string generatedString, string enteredString)
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

        static string CheckIfMailExist()
        {
            //if mail exists return true, else false
            string enteredEmail;
            do
            {
                Console.WriteLine("Unesite mail.");
                enteredEmail = CheckIfEmptyString();
            } while (false);
            return enteredEmail;
        }
        static string CheckIfCorrectPassword(string enteredEmail)
        {
            //if email and password matches return true, else false
            string enteredPassword;
           
            do
            {
                Console.WriteLine("Unesite lozinku.");
                enteredPassword = CheckIfEmptyString();
            } while (false);//do while password matches email + 30 sec pause

            return enteredPassword;
        }


    }
}
