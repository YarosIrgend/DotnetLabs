using System.Xml;
namespace dotnetLabs;

public static class XmlWriterMethods
{
    public static void CreateXmlWriter()
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "    ";
        
        using (XmlWriter writer = XmlWriter.Create("airportXmlWriter.xml", settings))
        {
            writer.WriteStartElement("airportSystem");
            WritePassenger(writer);
            WriteAirline(writer);
            WritePlane(writer);
            WriteRoute(writer);
            WriteRoutePlane(writer);
            WriteFlight(writer);
            WriteTicket(writer);
            writer.WriteEndElement();
        }
    }

    public static void WriteXmlFile()
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "    ";

        using (XmlWriter writer = XmlWriter.Create("Airport.xml", settings))
        {
            writer.WriteStartElement("AirportSystem");
            WritePassengers(writer, Data.passengers);
            writer.WriteEndElement();
        }
    }

    private static void WritePassenger(XmlWriter writer)
    {
        Console.WriteLine("Створимо пасажира");
        writer.WriteStartElement("passenger");
        writer.WriteElementString("Id", "1");
        Console.Write("Введіть ім'я: ");
        string name = Console.ReadLine();
        writer.WriteElementString("Name", name);
        Console.Write("Введіть прізвище: ");
        string surname = Console.ReadLine();
        writer.WriteElementString("Surname", surname);
        Console.Write("Введіть вік: ");
        string age = Console.ReadLine();
        writer.WriteElementString("Age", age);
        writer.WriteEndElement();
    }

    private static void WriteAirline(XmlWriter writer)
    {
        Console.WriteLine("\nСтворимо авіакомпанію");
        writer.WriteStartElement("airline");
        writer.WriteElementString("Id", "1");
        Console.Write("Введіть ім'я: ");
        string name = Console.ReadLine();
        writer.WriteElementString("Name", name);
        Console.Write("Введіть країну: ");
        string country = Console.ReadLine();
        writer.WriteElementString("Country", country);
        writer.WriteEndElement();
    }

    private static void WritePlane(XmlWriter writer)
    {
        Console.WriteLine("\nСтворимо літак");
        writer.WriteStartElement("plane");
        writer.WriteElementString("Id", "1");
        Console.Write("Введіть модель: ");
        string model = Console.ReadLine();
        writer.WriteElementString("Model", model);
        Console.Write("Введіть реєстраційний номер: ");
        string regnumber = Console.ReadLine();
        writer.WriteElementString("RegNumber", regnumber);
        Console.Write("Введіть місткість: ");
        string capacity = Console.ReadLine();
        writer.WriteElementString("Capacity", capacity);
        writer.WriteElementString("AirlineId", "1");
        writer.WriteEndElement();
    }

    private static void WriteRoute(XmlWriter writer)
    {
        Console.WriteLine("\nСтворимо маршрут");
        writer.WriteStartElement("route");
        writer.WriteElementString("Id", "1");
        Console.Write("Введіть місце зльоту: ");
        string origin = Console.ReadLine();
        writer.WriteElementString("Origin", origin);
        Console.Write("Введіть країну зльоту: ");
        string originCountry = Console.ReadLine();
        writer.WriteElementString("OriginCountry", originCountry);
        Console.Write("Введіть місце посадки: ");
        string destination = Console.ReadLine();
        writer.WriteElementString("Destination", destination);
        Console.Write("Введіть країну посадки: ");
        string destinationCountry = Console.ReadLine();
        writer.WriteElementString("DestinationCountry", destinationCountry);
        writer.WriteEndElement();
    }

    private static void WriteRoutePlane(XmlWriter writer)
    {
        Console.WriteLine("\nВносимо літак до рейса...");
        writer.WriteStartElement("routePlane");
        writer.WriteElementString("Id", "1");
        writer.WriteElementString("PlaneId", "1");
        writer.WriteElementString("RouteId", "1");
        writer.WriteEndElement();
    }

    private static void WriteFlight(XmlWriter writer)
    {
        Console.WriteLine("\nВносимо рейс...");
        writer.WriteStartElement("flight");
        writer.WriteElementString("Id", "1");
        writer.WriteElementString("DepartureDateTime", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm"));
        writer.WriteElementString("RealDepartureDateTime", DateTime.UtcNow.AddMinutes(5).ToString("yyyy-MM-dd HH:mm"));
        writer.WriteElementString("RoutePlaneId", "1");
        writer.WriteEndElement();
    }

    private static void WriteTicket(XmlWriter writer)
    {
        Console.WriteLine("\nСтворимо квиток");
        writer.WriteStartElement("ticket");
        writer.WriteElementString("Id", "1");
        Console.Write("Введіть клас: ");
        string seatClass = Console.ReadLine() switch
        {
            "1" => "Economy",
            "2" => "Business",
            "3" => "First"
        };
        writer.WriteElementString("SeatClass", seatClass);
        writer.WriteElementString("PassengerId", "1");
        writer.WriteElementString("FlightId", "1");
        writer.WriteEndElement();
    }

    private static void WritePassengers(XmlWriter writer, List<Passenger> passengers)
    {
        writer.WriteStartElement("passengers");
        foreach (var passenger in passengers)
        {
            writer.WriteElementString("Id", passenger.Id.ToString());
        }
        writer.WriteEndElement();
    }
}