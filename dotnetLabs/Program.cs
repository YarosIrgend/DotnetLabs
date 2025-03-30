using dotnetLabs;

// запис лістів (у Data) у xml
XmlWriterMethods.WriteXmlFile();

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("1 - Створення xml-файлу xmlwriter'ом");
Console.WriteLine("2 - Завантаження існуючого файлу");
Console.ResetColor();
switch (Console.ReadLine())
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
        }
        break;
}

