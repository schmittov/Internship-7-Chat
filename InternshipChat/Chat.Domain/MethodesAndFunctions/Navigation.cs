namespace Chat.Domain.MethodesAndFunctions
{
    public class Navigation
    {
        public static int MainNavigation(Dictionary<int, string> menuOptions)
        {
            int currentOption = 1;
            while (true)
            {
                Navigation.PrintMenuOptions(menuOptions, currentOption);
                ConsoleKeyInfo keyboardKey = Console.ReadKey();
                switch (keyboardKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentOption = Math.Max(1, currentOption - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        currentOption = Math.Min(menuOptions.Count, currentOption + 1);
                        break;
                    case ConsoleKey.Enter:
                        return currentOption;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
        public static void PrintMenuOptions(Dictionary<int, string> menuOptions, int currentOption)
        {
            for (int i = 1; i <= menuOptions.Count; i++)
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
    }

    
}
