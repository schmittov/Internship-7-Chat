using Chat.Domain.MethodesAndFunctions;
Console.CursorVisible = false;
int secondMenu=0, thirdMenu=0;

while (true)
{
    Navigation.MainNavigation(MenuOptions.SignInMenuOptions);
    //check login or registration
    Console.Clear();
    while (true)
    {
        secondMenu = Navigation.MainNavigation(MenuOptions.MainMenuOptions);
        
        Console.Clear();
        if (secondMenu == 0)
            break;

        switch (secondMenu)
        {
            case 1:
                thirdMenu = Navigation.MainNavigation(MenuOptions.GroupChatMenuOptions);
                break;
            case 2:
                thirdMenu = Navigation.MainNavigation(MenuOptions.PrivateChatMenuOptions);
                break;
            case 3:
                thirdMenu = Navigation.MainNavigation(MenuOptions.UserManagmentMenuOptions);
                break;
            case 4:
                thirdMenu = Navigation.MainNavigation(MenuOptions.ProfileSettingsMenuOptions);
                break;
        }
        Console.Clear();
        Environment.Exit(0); //do action
    }
}    
