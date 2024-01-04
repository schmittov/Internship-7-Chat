using Chat.Data.Entities.Models;

namespace Chat.Domain.MethodesAndFunctions
{
    public class Navigation
    {
        public static int MainNavigation(Dictionary<int, string> menuOptions)
        {
            int currentOption = 0;
            while (true)
            {
                Navigation.PrintMenuOptions(menuOptions, currentOption);
                ConsoleKeyInfo keyboardKey = Console.ReadKey();
                switch (keyboardKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentOption = Math.Max(0, currentOption - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        currentOption = Math.Min(menuOptions.Count-1, currentOption + 1);
                        break;
                    case ConsoleKey.Enter:
                        return currentOption;
                }
                Console.Clear();
            }
        }
        public static void PrintMenuOptions(Dictionary<int, string> menuOptions, int currentOption)
        {
            for (int i = 0; i <= menuOptions.Count-1; i++)
            {
                if (i == currentOption)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(menuOptions[i]);
                Console.ResetColor();
            }
        }



        public static void PrintUserOptions(List<User> userOptions, int currentOption)
        {

            Console.Clear();

            Console.WriteLine("Odustani");

            for (int i = 0; i < userOptions.Count; i++)
            {
                
                if (i == currentOption)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
               
                Console.WriteLine($"{userOptions[i].Name} {userOptions[i].Surname} ({userOptions[i].Email})");
                Console.ResetColor();
            } 

        }

        public static int UserNavigation(List<User> userOptions)
        {
            int currentOption = 0;
            while (true)
            {
                Console.Clear();
                
                PrintUserOptions(userOptions, currentOption);
                ConsoleKeyInfo keyboardKey = Console.ReadKey();

                switch (keyboardKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentOption = Math.Max(-1, currentOption - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        currentOption = Math.Min(userOptions.Count - 1, currentOption + 1);
                        break;
                    case ConsoleKey.Enter:
                        return currentOption;
                }
            }
        }



        public static void PrintChannelOptions(List<GroupChat> channelOptions, int currentOption)
        {
            Console.Clear();
            Console.WriteLine("Kanali čiji ste sudionik.");

            for (int i = 0; i < channelOptions.Count; i++)
            {
                if (i == currentOption)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{channelOptions[i].Name}");
                Console.ResetColor();
            }
        }

        public static int ChannelNavigation(List<GroupChat> channelOptions)
        {
            int currentOption = 0;
            while (true)
            {
                Console.Clear();

                PrintChannelOptions(channelOptions, currentOption);
                ConsoleKeyInfo keyboardKey = Console.ReadKey();

                switch (keyboardKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentOption = Math.Max(0, currentOption - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        currentOption = Math.Min(channelOptions.Count - 1, currentOption + 1);
                        break;
                    case ConsoleKey.Enter:
                        return currentOption;
                }
            }
        }


        public static int GroupSendMessageNavigation()
        {
            int currentOption = 0;
            string[] options = { "Izađi", "Pošalji poruku" };

            while (true)
            {
                Console.Clear();
                SendGroupMessageOptions(options, currentOption);

                ConsoleKeyInfo keyboardKey = Console.ReadKey();

                switch (keyboardKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentOption = Math.Max(0, currentOption - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        currentOption = Math.Min(options.Length - 1, currentOption + 1);
                        break;
                    case ConsoleKey.Enter:
                        return currentOption;
                }
            }
        }
        public static void SendGroupMessageOptions(string[] options, int currentOption)
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (i == currentOption)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }

        public static void PrintManagementUserOptions(List<User> userOptions, int currentOption)
        {
            Console.Clear();

            Console.WriteLine("Odustani");

            for (int i = 0; i < userOptions.Count; i++)
            {
                if (i == currentOption)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{userOptions[i].Name} {userOptions[i].Surname} ({userOptions[i].Email})");
                Console.ResetColor();
            }
        }


        public static int YesNoNavigation()
        {
            int currentOption = 0;
            string[] options = { "Da", "Ne" };

            while (true)
            {
                Console.Clear();
                
                PrintYesNoOptions(options, currentOption);

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentOption = Math.Max(0, currentOption - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        currentOption = Math.Min(options.Length - 1, currentOption + 1);
                        break;
                    case ConsoleKey.Enter:
                        return currentOption;
                }
            }
        }

        public static void PrintYesNoOptions(string[] options, int currentOption)
        {
            Console.Clear();
            Console.WriteLine("Jeste li sigurni da želite izbrisati korisnika?");
            for (int i = 0; i < options.Length; i++)
            {
                if (i == currentOption)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }
    }
}
