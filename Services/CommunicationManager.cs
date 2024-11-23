namespace FolderCreator.Services
{
    public class CommunicationManager : ICommunicationManager
    {
        public void ShowMassageToTheUser(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowErrorMassageToTheUser(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ShowSuccessMassageToTheUser(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ShowOptionMassageToTheUser(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public string GetStringFromUser()
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            return GetStringFromUser();
        }

        public int GetIntFromUser()
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }

            return GetIntFromUser();
        }

        public string[] GetMultiLineStringAsArrayFromUser()
        {
            var lines = new List<string>();
            string? input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine())) { 
                lines.Add(input);
            }

            return lines.ToArray();
        }

        public string? GetAnyKey() {
            return Console.ReadLine();
        }
    }
}
