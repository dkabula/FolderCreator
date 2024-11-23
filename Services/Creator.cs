using FolderCreator.Providers;

namespace FolderCreator.Services
{
    public class Creator : ICreator
    {
        private string _location;
        private readonly ICommunicationManager _communicationManager;

        public Creator(ICommunicationManager communicationManager, string path)
        {
            _location = path;
            _communicationManager = communicationManager;
        }

        public void SetBaseLocation(string location) {
            location = location.Replace("\"", "");
            if (Directory.Exists(location))
            {
                _communicationManager.ShowSuccessMassageToTheUser(MessageProvider.BasePathSet(location));
                _location = location;
            }
            else
            {
                _communicationManager.ShowErrorMassageToTheUser(MessageProvider.BasePathDoesntExists);
            }
        }

        public string GetLocation() { 
            return _location;
        }

        public bool CreateFolder(string name)
        {
            var path = $@"{_location}\{name}";

            try
            {
                if (Directory.Exists(path)) {
                    _communicationManager.ShowMassageToTheUser(MessageProvider.DirectoryAlreadyExists(name));
                    return false;
                }
                var directory = Directory.CreateDirectory(path);
                if (directory != null)
                {
                    _communicationManager.ShowSuccessMassageToTheUser(MessageProvider.DirectoryCreated(name));
                    return true;
                }

                _communicationManager.ShowErrorMassageToTheUser(MessageProvider.DirectoryCreationFailed(name));
                return false;
            }
            catch (Exception ex)
            {
                _communicationManager.ShowErrorMassageToTheUser(MessageProvider.DirectoryCreationError(ex.Message));
                return false;
            }
        }

        public string[] GetExistingFolders()
        {
            return Directory.GetDirectories(_location)
                .Select(x => new DirectoryInfo(x))
                .Select(x => x.Name)
                .ToArray();
        }
    }
}
