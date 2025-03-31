using System.Xml.Serialization;

namespace dotnetLabs;

public static class XmlSerializerMethods
{
    private static AirportSystem airportSystem;

    public static void Run()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(AirportSystem));
        using (TextReader reader = File.OpenText("Airport.xml"))
        {
            airportSystem = (AirportSystem)serializer.Deserialize(reader);
            PrintPassengers();
            PrintAirlines();
            PrintPlanes();
            PrintRoutes();
            PrintFlights();
            PrintTickets();
        }
    }

    private static void PrintPassengers()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tPassengers");
        Console.ResetColor();
        foreach (Passenger passenger in airportSystem.Passengers)
        {
            Console.WriteLine($"Name: {passenger.Name}");
            Console.WriteLine($"Surname: {passenger.Surname}");
            Console.WriteLine($"Age: {passenger.Age}");
            Console.WriteLine();
        }
    }

    private static void PrintAirlines()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tAirlines");
        Console.ResetColor();
        foreach (var airline in airportSystem.Airlines)
        {
            Console.WriteLine($"Name: {airline.Name}");
            Console.WriteLine($"Country: {airline.Country}");
            Console.WriteLine();
        }
    }

    private static void PrintPlanes()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tPlanes");
        Console.ResetColor();
        foreach (var plane in airportSystem.Planes)
        {
            Console.WriteLine($"Model: {plane.Model}");
            Console.WriteLine($"RegNumber: {plane.RegNumber}");
            Console.WriteLine($"Capacity: {plane.Capacity}");
            Console.WriteLine();
        }
    }

    private static void PrintRoutes()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tRoutes");
        Console.ResetColor();

        foreach (var route in airportSystem.Routes)
        {
            Console.WriteLine($"Origin: {route.Origin}");
            Console.WriteLine($"OriginCountry: {route.OriginCountry}");
            Console.WriteLine($"Destination: {route.Destination}");
            Console.WriteLine($"DestinationCountry: {route.DestinationCountry}");
            Console.WriteLine();
        }
    }

    private static void PrintFlights()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tFlights");
        Console.ResetColor();

        foreach (var flight in airportSystem.Flights)
        {
            // вибираємо маршрут конкретного рейса
            var route = (from r in airportSystem.Routes
                join rp in airportSystem.RoutePlanes on r.Id equals rp.RouteId
                join f in airportSystem.Flights on rp.Id equals f.RoutePlaneId
                where f.Id == flight.Id
                select new { r.Origin, r.Destination }).FirstOrDefault();

            Console.WriteLine($"{route.Origin} - {route.Destination}");
            Console.WriteLine($"Departure time: {flight.DepartureDateTime}");
            Console.WriteLine($"Real departure time: {flight.RealDepartureDateTime}");
            Console.WriteLine();
        }
    }

    private static void PrintTickets()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\tTickets");
        Console.ResetColor();

        foreach (var ticket in airportSystem.Tickets)
        {
            // маршрут
            var route = (from r in airportSystem.Routes
                join rp in airportSystem.RoutePlanes on r.Id equals rp.RouteId
                join f in airportSystem.Flights on rp.Id equals f.RoutePlaneId
                join t in airportSystem.Tickets on f.Id equals t.FlightId
                where f.Id == ticket.FlightId
                select new { r.Origin, r.Destination }).FirstOrDefault();
            // пасажир
            var passengerSurname = (from p in airportSystem.Passengers
                join t in airportSystem.Tickets on p.Id equals ticket.PassengerId
                select p.Surname).FirstOrDefault();

            Console.WriteLine($"{route.Origin} - {route.Destination}");
            Console.WriteLine($"SeatClass: {ticket.SeatClass}");
            Console.WriteLine($"Surname: {passengerSurname}");
            Console.WriteLine();
        }
    }
}