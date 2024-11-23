namespace FolderCreator.Services
{
    public interface ICommunicationManager
    {
        void ShowMassageToTheUser(string message);
        void ShowErrorMassageToTheUser(string message);
        void ShowSuccessMassageToTheUser(string message);
        void ShowOptionMassageToTheUser(string message);
        string GetStringFromUser();
        int GetIntFromUser();
        string[] GetMultiLineStringAsArrayFromUser();
        string? GetAnyKey();
    }
}
