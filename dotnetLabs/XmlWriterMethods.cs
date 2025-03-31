using System.Xml;
namespace dotnetLabs;

public static class XmlWriterMethods
{
    // завдання 2
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

    // запис наявних даних в xml
    public static void WriteXmlFile()
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "    ";

        using (XmlWriter writer = XmlWriter.Create("Airport.xml", settings))
        {
            writer.WriteStartElement("AirportSystem");
            WritePassengers(writer, Data.passengers);
            WriteAirlines(writer, Data.airlines);
            WritePlanes(writer, Data.planes);
            WriteRoutes(writer, Data.routes);
            WriteRoutePlanes(writer, Data.routePlanes);
            WriteFlights(writer, Data.flights);
            WriteTickets(writer, Data.tickets);
            writer.WriteEndElement();
        }
    }

    // методи для завдання 2
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

    // методи для запису наявних даних в xml
    private static void WritePassengers(XmlWriter writer, List<Passenger> passengers)
    {
        writer.WriteStartElement("passengers");
        foreach (var passenger in passengers)
        {
            writer.WriteStartElement("passenger");
            writer.WriteElementString("Id", passenger.Id.ToString());
            writer.WriteElementString("Name", passenger.Name);
            writer.WriteElementString("Surname", passenger.Surname);
            writer.WriteElementString("Age", passenger.Age.ToString());
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
    }

    private static void WriteAirlines(XmlWriter writer, List<Airline> airlines)
    {
        writer.WriteStartElement("airlines");
        foreach (var airline in airlines)
        {
            writer.WriteStartElement("airline");
            writer.WriteElementString("Id", airline.Id.ToString());
            writer.WriteElementString("Name", airline.Name);
            writer.WriteElementString("Country", airline.Country);
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
    }

    private static void WritePlanes(XmlWriter writer, List<Plane> planes)
    {
        writer.WriteStartElement("planes");
        foreach (var plane in planes)
        {
            writer.WriteStartElement("plane");
            writer.WriteElementString("Id", plane.Id.ToString());
            writer.WriteElementString("Model", plane.Model);
            writer.WriteElementString("RegNumber", plane.RegNumber);
            writer.WriteElementString("Capacity", plane.Capacity.ToString());
            writer.WriteElementString("AirlineId", plane.AirlineId.ToString());
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
    }

    private static void WriteRoutes(XmlWriter writer, List<Route> routes)
    {
        writer.WriteStartElement("routes");
        foreach (var route in routes)
        {
            writer.WriteStartElement("route");
            writer.WriteElementString("Id", route.Id.ToString());
            writer.WriteElementString("Origin", route.Origin);
            writer.WriteElementString("OriginCountry", route.OriginCountry);
            writer.WriteElementString("Destination", route.Destination);
            writer.WriteElementString("DestinationCountry", route.DestinationCountry);
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
    }

    private static void WriteRoutePlanes(XmlWriter writer, List<RoutePlane> routePlanes)
    {
        writer.WriteStartElement("routePlanes");
        foreach (var routePlane in routePlanes)
        {
            writer.WriteStartElement("routePlane");
            writer.WriteElementString("Id", routePlane.Id.ToString());
            writer.WriteElementString("PlaneId", routePlane.PlaneId.ToString());
            writer.WriteElementString("RouteId", routePlane.RouteId.ToString());
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
    }

    private static void WriteFlights(XmlWriter writer, List<Flight> flights)
    {
        writer.WriteStartElement("flights");
        foreach (var flight in flights)
        {
            writer.WriteStartElement("flight");
            writer.WriteElementString("Id", flight.Id.ToString());
            writer.WriteElementString("DepartureDateTime", flight.DepartureDateTime.ToString("yyyy-MM-dd HH:mm"));
            writer.WriteElementString("RealDepartureDateTime", flight.RealDepartureDateTime.ToString("yyyy-MM-dd HH:mm"));
            writer.WriteElementString("RoutePlaneId", flight.RoutePlaneId.ToString());
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
    }

    private static void WriteTickets(XmlWriter writer, List<Ticket> tickets)
    {
        writer.WriteStartElement("tickets");
        foreach (var ticket in tickets)
        {
            writer.WriteStartElement("ticket");
            writer.WriteElementString("Id", ticket.Id.ToString());
            writer.WriteElementString("SeatClass", ticket.SeatClass.ToString());
            writer.WriteElementString("PassengerId", ticket.PassengerId.ToString());
            writer.WriteElementString("FlightId", ticket.FlightId.ToString());
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
    }
}