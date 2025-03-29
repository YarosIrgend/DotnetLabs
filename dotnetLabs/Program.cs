using dotnetLabs;

// запис лістів (у Data) у xml
XmlWriterMethods.WriteXmlFile();

Console.OutputEncoding = System.Text.Encoding.UTF8;

switch (Console.ReadLine())
{
    case "1":
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Створення xml-файлу xmlwriter'ом");
        Console.ResetColor();
        XmlWriterMethods.CreateXmlWriter();     
        break;
}

