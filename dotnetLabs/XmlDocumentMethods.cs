using System.Xml;

namespace dotnetLabs;

public static class XmlDocumentMethods
{
    public static void Run()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("Airport.xml");
        XmlNode root = doc.DocumentElement;
        XmlNodeList nodes = root.ChildNodes;
        foreach (XmlNode node in nodes)
        {
            switch (node.Name)
            {
                case "passengers":
                    PrintPassengers(doc);
                    break;
                case "airlines":
                    PrintAirlines(doc);
                    break;
                case "planes":
                    PrintPlanes(doc);
                    break;
                case "routes":
                    PrintRoutes(doc);
                    break;
                case "flights":
                    PrintFlights(doc);
                    break;
                case "tickets":
                    PrintTickets(doc);
                    break;
                default:
                    continue;
            }
        }
    }

    private static void PrintPassengers(XmlDocument doc)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tPassengers");
        Console.ResetColor();
        XmlNodeList passengers = doc.GetElementsByTagName("passenger");
        foreach (XmlNode passenger in passengers)
        {
            Console.WriteLine($"Name: {passenger["Name"].InnerText}");
            Console.WriteLine($"Surname: {passenger["Surname"].InnerText}");
            Console.WriteLine($"Age: {passenger["Age"].InnerText}");
            Console.WriteLine();
        }
    }

    private static void PrintAirlines(XmlDocument doc)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tAirlines");
        Console.ResetColor();
        XmlNodeList airlines = doc.GetElementsByTagName("airline");
        foreach (XmlNode airline in airlines)
        {
            Console.WriteLine($"Name: {airline["Name"].InnerText}");
            Console.WriteLine($"Country: {airline["Country"].InnerText}");
            Console.WriteLine();
        }
    }

    private static void PrintPlanes(XmlDocument doc)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tPlanes");
        Console.ResetColor();
        XmlNodeList planes = doc.GetElementsByTagName("plane");
        foreach (XmlNode plane in planes)
        {
            Console.WriteLine($"Model: {plane["Model"].InnerText}");
            Console.WriteLine($"RegNumber: {plane["RegNumber"].InnerText}");
            Console.WriteLine($"Capacity: {plane["Capacity"].InnerText}");
            Console.WriteLine();
        }
    }

    private static void PrintRoutes(XmlDocument doc)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tRoutes");
        Console.ResetColor();
        XmlNodeList routes = doc.GetElementsByTagName("route");
        foreach (XmlNode route in routes)
        {
            Console.WriteLine($"Origin: {route["Origin"].InnerText}");
            Console.WriteLine($"OriginCountry: {route["OriginCountry"].InnerText}");
            Console.WriteLine($"Destination: {route["Destination"].InnerText}");
            Console.WriteLine($"DestinationCountry: {route["DestinationCountry"].InnerText}");
            Console.WriteLine();
        }
    }

    private static void PrintFlights(XmlDocument doc)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tFlights");
        Console.ResetColor();
        XmlNodeList flights = doc.GetElementsByTagName("flight");
        foreach (XmlNode flight in flights)
        {
            // отримання даних про маршрут
            XmlNode routePlane =
                doc.DocumentElement.SelectSingleNode(
                    $"routePlanes/routePlane[Id='{flight["RoutePlaneId"].InnerText}']");
            string routeId = routePlane["RouteId"].InnerText;
            string flightOrigin = doc.DocumentElement.SelectSingleNode($"routes/route[Id='{routeId}']/Origin").InnerText;
            string flightDestination = doc.DocumentElement.SelectSingleNode($"routes/route[Id='{routeId}']/Destination").InnerText;
            
            Console.WriteLine($"{flightOrigin} - {flightDestination}");
            Console.WriteLine($"Departure time: {flight["DepartureDateTime"].InnerText}");
            Console.WriteLine($"RealDepartureTime: {flight["RealDepartureDateTime"].InnerText}");
            Console.WriteLine();
        }
    }

    private static void PrintTickets(XmlDocument doc)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tTickets");
        Console.ResetColor();
        
        XmlNodeList tickets = doc.GetElementsByTagName("ticket");
        foreach (XmlNode ticket in tickets)
        {
            // отримання даних про пасажира
            XmlNode passenger = doc.DocumentElement.SelectSingleNode($"passengers/passenger[Id='{ticket["PassengerId"].InnerText}']");
            string passengerSurname = passenger["Surname"].InnerText;
            // отримання даних про рейс
            XmlNode flight = doc.DocumentElement.SelectSingleNode($"flights/flight[Id='{ticket["FlightId"].InnerText}']");
            XmlNode routePlane =
                doc.DocumentElement.SelectSingleNode(
                    $"routePlanes/routePlane[Id='{flight["RoutePlaneId"].InnerText}']");
            string routeId = routePlane["RouteId"].InnerText;
            string flightOrigin = doc.DocumentElement.SelectSingleNode($"routes/route[Id='{routeId}']/Origin").InnerText;
            string flightDestination = doc.DocumentElement.SelectSingleNode($"routes/route[Id='{routeId}']/Destination").InnerText;
            
            Console.WriteLine($"{flightOrigin} - {flightDestination}");
            Console.WriteLine($"SeatClass: {ticket["SeatClass"].InnerText}");
            Console.WriteLine($"Passenger surname: {passengerSurname}");
            Console.WriteLine();
        }
    }
}