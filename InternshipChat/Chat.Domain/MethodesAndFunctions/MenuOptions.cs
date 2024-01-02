namespace Chat.Domain.MethodesAndFunctions
{
    public class MenuOptions
    {
        public static Dictionary<int, string> SignInMenuOptions = new()
        {
            { 0, "Zatvori aplikaciju"},
            { 1, "Logiraj se" },
            { 2, "Registriraj se" },
        };
        public static Dictionary<int, string> MainMenuOptions = new()
        {
            { 1, "Grupni kanali" },
            { 2, "Privatne poruke" },
            { 3, "User management" },
            { 4, "Postavke profila" },
            { 0, "Odjava iz profila" },
        };
        public static Dictionary<int, string> GroupChatMenuOptions = new()
        {
            { 1, "Kreiranje novog kanala" },
            { 2, "Ulazak u kanal" },
            { 3, "Ispis svih kanala u koje je korisnik ušao" },
            { 0, "Vrati se nazad" },
        };
        public static Dictionary<int, string> PrivateChatMenuOptions = new()
        {
            { 1, "Nova poruka" },
            { 2, "Ispis svih korisnika" },
            { 0, "Vrati se nazad" },
        };
        public static Dictionary<int, string> UserManagmentMenuOptions = new()
        {
            { 1, "Brisanje profila" },
            { 0, "Vrati se nazad" },
        };
        public static Dictionary<int, string> ProfileSettingsMenuOptions = new()
        {
            { 1, "Promjeni email" },
            { 2, "Promjeni lozinku" },
            { 0, "Vrati se nazad" },
        };
    }
}
