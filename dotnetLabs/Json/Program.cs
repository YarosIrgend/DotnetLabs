namespace dotnetLabs.Json;

internal static class Program
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        string taskChoice;
        do
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1 - (Де)серіалізація");
            Console.WriteLine("2 - Використання DOM");
            Console.ResetColor();
            switch (taskChoice = Console.ReadLine())
            {
                case "1":
                    JsonSerialization.Run();
                    break;
                case "2":
                    JsonDomMethods.Run();
                    break;
            }
        } while (taskChoice is "1" or "2");
    }
}