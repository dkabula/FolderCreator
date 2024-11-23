namespace FolderCreator
{
    using FolderCreator.Providers;
    using FolderCreator.Services;
    public class Manager
    {
        private const int ExitOption = 0;
        private const int ShowPathOption = 1;
        private const int ChangePathOption = 2;
        private const int CreateFoldersOption = 3;
        private const int ListFoldersOption = 4;

        private ICreator _creator;
        private ICommunicationManager _communicationManager;

        public Manager()
        {
            _communicationManager = new CommunicationManager();
            _creator = new Creator(_communicationManager, Directory.GetCurrentDirectory());
        }

        public void Run()
        {
            var running = true;
            _communicationManager.ShowSuccessMassageToTheUser(MessageProvider.Greetings);
            while (running)
            {
                var option = GetMenuOption();
                switch(option)
                {
                    case ExitOption:
                        running = false; 
                        break;
                    case ShowPathOption:
                        _communicationManager.ShowMassageToTheUser(_creator.GetLocation());
                        break;
                    case ChangePathOption:
                        ChangePath();
                        break;
                    case CreateFoldersOption:
                        CreateFolders();
                        break;
                    case ListFoldersOption:
                        ListDirectories();
                        break;
                    default:
                        _communicationManager.ShowMassageToTheUser(MessageProvider.Option_Invalid);
                        break;
                }
            }
            Stop();
        }

        private int GetMenuOption()
        {
            _communicationManager.ShowOptionMassageToTheUser(MessageProvider.Menu);
            _communicationManager.ShowOptionMassageToTheUser($"[{ShowPathOption}] {MessageProvider.Option_ShowActualPath}");
            _communicationManager.ShowOptionMassageToTheUser($"[{ChangePathOption}] {MessageProvider.Option_ChangeActualPath}");
            _communicationManager.ShowOptionMassageToTheUser($"[{CreateFoldersOption}] {MessageProvider.Option_CreateFolders}");
            _communicationManager.ShowOptionMassageToTheUser($"[{ListFoldersOption}] {MessageProvider.Option_ListFolders}");
            _communicationManager.ShowOptionMassageToTheUser($"[{ExitOption}] {MessageProvider.Option_Exit}");

            return _communicationManager.GetIntFromUser();
        }

        private void ChangePath()
        {
            _communicationManager.ShowOptionMassageToTheUser(MessageProvider.GetBasePath);
            _creator.SetBaseLocation(_communicationManager.GetStringFromUser());
        }

        private void CreateFolders()
        {
            _communicationManager.ShowOptionMassageToTheUser(MessageProvider.GetFolders);
            var names = _communicationManager.GetMultiLineStringAsArrayFromUser();
            if (names == null || names.Length == 0)
            {
                _communicationManager.ShowErrorMassageToTheUser(MessageProvider.NoFoldersProvided);
            }
            else
            {
                var count = 0;
                foreach (var name in names)
                {
                    if (_creator.CreateFolder(name)) count++;
                }
                _communicationManager.ShowMassageToTheUser(MessageProvider.CreatedXofYDirectories(count, names.Length));
            }
        }

        private void ListDirectories()
        {
            var existingDirectories = _creator.GetExistingFolders();
            if (existingDirectories == null || existingDirectories.Length == 0)
            {
                _communicationManager.ShowMassageToTheUser(MessageProvider.NoExistingFolders);
            }
            else
            {
                foreach (var directory in existingDirectories)
                {
                    _communicationManager.ShowSuccessMassageToTheUser(directory);
                }
            }
        }

        private void Stop()
        {
            _communicationManager.ShowSuccessMassageToTheUser(MessageProvider.Goodbye);
            _communicationManager.GetAnyKey();
        }
    }
}
