using dotnetLabs;

// запис лістів (у Data) у xml
XmlWriterMethods.WriteXmlFile();

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("1 - Створення xml-файлу xmlwriter'ом");

Console.ResetColor();
switch (Console.ReadLine())
{
    case "1":
        XmlWriterMethods.CreateXmlWriter();     
        break;
}

