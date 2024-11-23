namespace FolderCreator.Providers
{
    public static class MessageProvider
    {
        public static string Greetings => "Witaj w kreatorze folderów!";
        public static string GetBasePath => "Podaj ścieżkę bazową:";
        public static string GetFolders => "Podaj nazwy folderów:";
        public static string NoFoldersProvided => "Nie wczytano nazw folderów.";
        public static string BasePathDoesntExists => "Podana ścieżka nie istnieje, lub nie ma do niej dostępu.";
        public static string NoExistingFolders => "Brak istniejących folderów.";
        public static string BasePathSet(string name) => $"Ustawiono nową śceżkę bazową na {name}.";
        public static string DirectoryAlreadyExists(string name) => $"Folder {name} już istnieje.";
        public static string DirectoryCreated(string name) => $"Folder {name} stworzony poprawnie.";
        public static string DirectoryCreationFailed(string name) => $"Nie udało się stworzyć folderu {name}.";
        public static string DirectoryCreationError(string ex) => $"Wystąpił błąd podczas próby stworzenia folderu. Komunikat błędu: {ex}";
        public static string CreatedXofYDirectories(int x, int y) => $"Stworzono {x} z {y} folderów.";
        public static string Option_ShowActualPath => "Pokaż aktualną ścieżkę.";
        public static string Option_ChangeActualPath => "Zmień aktualną ścieżkę.";
        public static string Option_CreateFolders => "Twórz foldery.";
        public static string Option_ListFolders => "Pokaż istniejące foldery.";
        public static string Option_Exit => "Wyjście.";
        public static string Option_Invalid => "Nie rozpoznano opcji.";
        public static string Goodbye => "Dziękujemy za skorzystanie z aplikacji.\r\nNaciśnij dowolny klawisz by wyjść.";
        public static string Menu => "Co chcesz zrobić?";
    }
}
