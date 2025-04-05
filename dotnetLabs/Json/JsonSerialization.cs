using System.Text.Json;

namespace dotnetLabs.Json;

public static class JsonSerialization
{
    private static AirportSystem airportSystem;

    private static JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };

    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1 - Cеріалізація");
        Console.WriteLine("2 - Десеріалізація");
        Console.ResetColor();
        switch (Console.ReadLine())
        {
            case "1":
                Serialize();
                break;
            case "2":
                Deserialize();        
                break;
        }
        Console.ReadLine();
        Console.Clear();
    }

    private static void Serialize()
    {
        airportSystem = new()
        {
            Passengers = Data.passengers, Airlines = Data.airlines, Flights = Data.flights, Routes = Data.routes,
            RoutePlanes = Data.routePlanes, Planes = Data.planes, Tickets = Data.tickets
        };
        string json = JsonSerializer.Serialize(airportSystem, options);
        Console.WriteLine(json);
        File.WriteAllText("Airport.json", json);
    }

    private static void Deserialize()
    {
        airportSystem = null;
        using (FileStream fs = File.OpenRead("Airport.json"))
        {
            airportSystem = JsonSerializer.Deserialize<AirportSystem>(fs, options);
        }
        PrintPassengers();
        PrintAirlines();
        PrintPlanes();
        PrintRoutes();
        PrintFlights();
        PrintTickets();
        
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