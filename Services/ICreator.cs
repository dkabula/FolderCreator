namespace FolderCreator.Services
{
    public interface ICreator
    {
        bool CreateFolder(string name);
        string GetLocation();
        void SetBaseLocation(string location);
        string[] GetExistingFolders();
    }
}
