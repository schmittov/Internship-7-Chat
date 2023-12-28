namespace Chat.Domain.MethodesAndFunctions
{
    public class MenuOptions
    {
        public static Dictionary<int, string> SignInMenuOptions = new()
        {
            { 1, "Logiraj se" },
            { 2, "Registriraj se" },
        };
        public static Dictionary<int, string> MainMenuOptions = new()
        {
            { 1, "Grupni kanali" },
            { 2, "Privatne poruke" },
            { 3, "User management" },
            { 4, "Postavke profila" },
            { 5, "Odjava iz profila" },
        };
        public static Dictionary<int, string> GroupChatMenuOptions = new()
        {
            { 1, "Kreiranje novog kanala" },
            { 2, "Ulazak u kanal" },
            { 3, "Ispis svih kanala u koje je korisnik ušao" },
            { 4, "Vrati se nazad" },
        };
        public static Dictionary<int, string> PrivateChatMenuOptions = new()
        {
            { 1, "Nova poruka" },
            { 2, "Ispis svih korisnika" },
            { 3, "Vrati se nazad" },
        };
    }
}
