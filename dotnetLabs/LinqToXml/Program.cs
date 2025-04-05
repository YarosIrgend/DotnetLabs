namespace dotnetLabs.LinqToXml;

internal static class Program
{
    public static void Run()
    {
        // запис лістів (у Data) у xml
        XmlWriterMethods.WriteXmlFile();

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string taskChoice;
        do
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1 - Створення xml-файлу xmlwriter'ом");
            Console.WriteLine("2 - Завантаження існуючого файлу");
            Console.WriteLine("3 - XML-запити");
            Console.ResetColor();
            switch (taskChoice = Console.ReadLine())
            {
                case "1":
                    XmlWriterMethods.CreateXmlWriter();
                    break;
                case "2":
                    Console.WriteLine("1 - Завантаження через XmlDocument");
                    Console.WriteLine("2 - Завантаження через XmlSerializer");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            XmlDocumentMethods.Run();
                            break;
                        case "2":
                            XmlSerializerMethods.Run();
                            break;
                        default:
                            Console.Clear();
                            continue;
                    }

                    break;
                case "3":
                    XmlQueries.Run();
                    break;
            }
        } while (taskChoice is "1" or "2" or "3");
    }
}