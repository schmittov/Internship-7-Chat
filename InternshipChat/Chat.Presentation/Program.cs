using Chat.Data.Entities;
using Chat.Domain.MethodesAndFunctions;
using Microsoft.EntityFrameworkCore;
using Chat.Domain.Helpers;
Console.CursorVisible = false;
string loggedEmail=".";

int firstMenu,secondMenu, thirdMenu=0;

var options = new DbContextOptionsBuilder<InternshipChatDbContext>()
            .UseNpgsql("Server=localhost;Port=5432;Database=InternshipChatDB;User Id=postgres;Password=5283;")
            .Options;

while (true)
{
    switch (Navigation.MainNavigation(MenuOptions.SignInMenuOptions))
    {
        case 0:
            Environment.Exit(0);
            break;
        case 1:
            Console.CursorVisible = true;
            Console.Clear();
            loggedEmail=MethodesAndFunctions.LogIn(options);
            break;
        case 2:
            Console.CursorVisible = true;
            Console.Clear();
            loggedEmail = MethodesAndFunctions.Registration(options);
            break;
    }
    Console.CursorVisible = false;

    Console.Clear();
    while (true)
    {
        Console.Clear();
        secondMenu = Navigation.MainNavigation(MenuOptions.MainMenuOptions);
        
        Console.Clear();
        if (secondMenu == 0)
        {
            loggedEmail= null;
            break;
        }
        if(secondMenu==4 && !UserHelper.IsAdmin(loggedEmail,options)) 
        {
            Console.WriteLine("Niste admin ne možete pristupiti");
            Console.ReadKey();
            break;
        }
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
        while (true)
        {
            if (thirdMenu == 0)
                break;

            if(secondMenu == 1)
            {
                switch (thirdMenu)
                {
                    case 1:
                        GroupChatHelper.CreateAndJoinNewChannel(loggedEmail, options);
                        Console.ReadKey();
                        Console.Clear();
                        Console.CursorVisible = false;
                        break;
                    case 2:
                        GroupChatHelper.WriteChannelsNotJoinedByUser(loggedEmail, options);
                        Console.ReadKey();
                        break;
                    case 3:
                        GroupChatHelper.WriteUserChannelsByEmail(loggedEmail, options);
                        GroupChatHelper.PrintChannelMessage(loggedEmail, options);

                        break;
                }
                break;
            }
            else if (secondMenu == 2)
            {
                switch (thirdMenu)
                {
                    case 1:
                        PrivateMessageHelper.WriteNewMessage(loggedEmail, options);
                        break;
                    case 2:
                        PrivateMessageHelper.PrintUsersByMessageHistory(loggedEmail, options);
                        Console.ReadKey();
                        break;
                }
                break;
            }
            else if (secondMenu == 3)
            {
                switch (thirdMenu)
                {
                    case 1:
                        UserHelper.DeleteUser(options);
                        break;
                }
                break;
            }
            else if (secondMenu == 4)
            {
                switch (thirdMenu)
                {
                    case 1:
                        UserHelper.ChangeEmail(loggedEmail, options);
                        break;
                    case 2:
                        UserHelper.ChangePassword(loggedEmail, options);
                        break;
                }
                break;

            }
        }
    }
}

