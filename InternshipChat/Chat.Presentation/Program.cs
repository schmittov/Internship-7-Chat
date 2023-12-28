using Chat.Domain.MethodesAndFunctions;
Console.CursorVisible = false;

Navigation.MainNavigation(MenuOptions.SignInMenuOptions);
Console.Clear();
int secondMenu = Navigation.MainNavigation(MenuOptions.MainMenuOptions);
Console.Clear();
switch (secondMenu)
{
    case 1:
        Navigation.MainNavigation(MenuOptions.GroupChatMenuOptions);
        break;
    case 2:
        Navigation.MainNavigation(MenuOptions.PrivateChatMenuOptions);
        break;
    case 3:
        break;
    case 4:
        break;
    case 5:
        break;
}