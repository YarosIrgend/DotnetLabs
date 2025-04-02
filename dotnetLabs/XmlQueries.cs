using System.Xml.Linq;

namespace dotnetLabs;

public static class XmlQueries
{
    private static XDocument doc = XDocument.Load("Airport.xml");
    private static XElement root = doc.Root;

    private static IEnumerable<XElement> passengers = root.Descendants("passenger");
    private static IEnumerable<XElement> tickets = root.Descendants("ticket");
    private static IEnumerable<XElement> flights = root.Descendants("flight");
    private static IEnumerable<XElement> routePlanes = root.Descendants("routePlane");
    private static IEnumerable<XElement> routes = root.Descendants("route");
    private static IEnumerable<XElement> planes = root.Descendants("plane");
    private static IEnumerable<XElement> airlines = root.Descendants("airline");

    public static void Run()
    {
        Query1();
        Query2();
        Query3();
        Query4();
        Query5();
        Query6();
        Query7();
        Query8();
        Query9();
        Query10();
        Query11();
    }

    private static void Query1()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("відбір літаків Боїнг 777 з місткістю не менше 300");
        Console.ResetColor();

        var collection1 = root.Element("planes")
            .Elements("plane")
            .Where(p => int.Parse(p.Element("Capacity").Value) >= 300 &&
                        p.Element("Model").Value == "Boeing 777");
        foreach (var plane in collection1)
        {
            Console.WriteLine($"{plane.Element("RegNumber").Value} - {plane.Element("Capacity").Value}");
        }

        Console.WriteLine();
    }

    private static void Query2()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("групування пасажирів з квитками бізнес-класу за віковими категоріями ");
        Console.ResetColor();

        var collection2 = from plane in root.Element("planes").Elements("plane")
            from airline in root.Element("airlines").Elements("airline")
            select new { RegNumber = plane.Element("RegNumber").Value, Airline = airline.Element("Name").Value };

        foreach (var item in collection2)
        {
            Console.WriteLine($"{item.RegNumber} - {item.Airline}");
        }

        Console.WriteLine();
    }

    private static void Query3()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("групування літаків за їхніми авіакомпаніями");
        Console.ResetColor();

        var collection3 = from plane in root.Element("planes").Elements("plane")
            join airline in root.Element("airlines").Elements("airline")
                on plane.Element("AirlineId").Value equals airline.Element("Id").Value
            group plane by airline.Element("Name").Value;

        foreach (var item in collection3)
        {
            Console.WriteLine($"{item.Key} - {item.Count()}");
        }

        Console.WriteLine();
    }

    private static void Query4()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("групування пасажирів з квитками бізнес-класу за віковими категоріями");
        Console.ResetColor();

        var collection4 = passengers
            .Where(p => tickets.Any(t =>
                t.Element("PassengerId").Value == p.Element("Id").Value &&
                t.Element("SeatClass").Value == SeatClass.Business.ToString()))
            .GroupBy(p =>
            {
                return int.Parse(p.Element("Age").Value) switch
                {
                    <= 27 => "Молодші",
                    <= 32 => "Середні",
                    >= 33 => "Старші",
                };
            }).Select(group => new
            {
                AgeGroup = group.Key,
                Passengers = group.ToList()
            });

        foreach (var group in collection4)
        {
            foreach (var passenger in group.Passengers)
            {
                Console.WriteLine($"{passenger.Element("Surname").Value} - {group.AgeGroup}");
            }
        }

        Console.WriteLine();
    }

    private static void Query5()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Вивід пасажирів, чий вік дорівнює середньому");
        Console.ResetColor();

        var collection5 =
            passengers.Where(p =>
                int.Parse(p.Element("Age").Value) ==
                Math.Floor(passengers.Average(p => int.Parse(p.Element("Age").Value))));
        foreach (var passenger in collection5)
        {
            Console.Write($"{passenger.Element("Surname").Value} {passenger.Element("Name").Value}, ");
        }

        Console.WriteLine('\n');
    }

    private static void Query6()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("групування пасажирів за віковими категоріями з додатковими даними");
        Console.ResetColor();

        var collection6 = passengers
            .Where(p => tickets.Any(t =>
                t.Element("PassengerId").Value == p.Element("Id").Value &&
                t.Element("SeatClass").Value == SeatClass.Business.ToString()))
            .GroupBy(p =>
            {
                return int.Parse(p.Element("Age").Value) switch
                {
                    <= 27 => "Молодші",
                    <= 32 => "Середні",
                    >= 33 => "Старші",
                };
            }).Select(group => new
            {
                AgeRange = group.Key,
                Count = group.Count(),
                AverageAge = group.Average(p => int.Parse(p.Element("Age").Value)),
                Passengers = group.ToList()
            });

        foreach (var group in collection6)
        {
            Console.WriteLine($"{group.AgeRange}, Average age: {group.AverageAge}");
            Console.Write('\t');
            foreach (var passenger in group.Passengers)
            {
                Console.WriteLine($"{passenger.Element("Surname").Value} {passenger.Element("Name").Value}, ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static void Query7()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("пасажири віку від 20 до 30 у спадному порядку");
        Console.ResetColor();

        var collection7 = passengers.Where(p =>
                int.Parse(p.Element("Age").Value) >= 20 && int.Parse(p.Element("Age").Value) <= 30)
            .OrderByDescending(p => int.Parse(p.Element("Age").Value));

        foreach (var passenger in collection7)
        {
            Console.WriteLine($"{passenger.Element("Surname").Value} - {passenger.Element("Age").Value}");
        }
    }

    private static void Query8()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Об'єднання літаків Boeing 777 та літаків авіакомпаній Британії");
        Console.ResetColor();

        var boeings = planes.Join(airlines, p => p.Element("AirlineId").Value, a => a.Element("Id").Value,
                (plane, airline) => new
                    { Model = plane.Element("Model").Value, AirlineCountry = airline.Element("Country").Value })
            .Where(p => p.Model == "Boeing 777");
        var uk_planes = planes.Join(airlines, p => p.Element("AirlineId").Value, a => a.Element("Id").Value,
                (plane, airline) => new
                    { Model = plane.Element("Model").Value, AirlineCountry = airline.Element("Country").Value })
            .Where(p => p.AirlineCountry == "UK");
        var collection8 = boeings.Union(uk_planes).Distinct();
        foreach (var plane in collection8)
        {
            Console.WriteLine($"{plane.Model} - {plane.AirlineCountry}");
        }

        Console.WriteLine();
    }

    private static void Query9()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("перетворення у словник маршрути. Ключ - id, значення (рейс та час)");
        Console.ResetColor();

        var collection9 = routes.ToDictionary(route => route.Element("Id").Value,
            route => (Origin: route.Element("Origin").Value, Destination: route.Element("Destination").Value));
        foreach (var route in collection9)
        {
            Console.WriteLine(
                $"ID: {route.Key}, Value: {route.Value.Origin}-{route.Value.Destination}");
        }

        Console.WriteLine();
    }

    private static void Query10()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Групування рейсів по країнах вильоту з використанням проміжної route_group");
        Console.ResetColor();

        var collection10 = from route in routes
            group route by route.Element("OriginCountry").Value
            into route_group
            select new
            {
                OriginCountry = route_group.Key,
                Routes = route_group.ToList()
            };
        foreach (var group in collection10)
        {
            Console.WriteLine($"{group.OriginCountry}");
            foreach (var item in group.Routes)
            {
                Console.WriteLine($"\t{item.Element("Origin").Value} - {item.Element("Destination").Value}");
            }
        }

        Console.WriteLine();
    }

    private static void Query11()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Пасажири, які забронювали найбільше квитків на рейси в межах однієї авіакомпанії");
        Console.ResetColor();

        // квитки по пасажирах та авіакомпаніях
        var ticketsAirlines = from ticket in tickets
            join flight in flights on ticket.Element("FlightId").Value equals flight.Element("Id").Value
            join passenger in passengers on ticket.Element("PassengerId").Value equals passenger.Element("Id").Value
            join routePlane in routePlanes on flight.Element("RoutePlaneId").Value equals routePlane.Element("Id").Value
            join plane in planes on routePlane.Element("PlaneId").Value equals plane.Element("Id").Value
            join airline in airlines on plane.Element("AirlineId").Value equals airline.Element("Id").Value
            group tickets by new
            {
                PassengerSurname = passenger.Element("Surname").Value,
                AirlineName = airline.Element("Name").Value
            }
            into airline_tickets
            select new
            {
                Passenger = airline_tickets.Key.PassengerSurname, 
                Airline = airline_tickets.Key.AirlineName,
                TicketCount = airline_tickets.ToList().Count
            };
        
        var maxTicketsPerAirline = ticketsAirlines
            .GroupBy(t => t.Airline)
            .Select(g => new
            {
                Airline = g.Key,
                MaxCount = g.Max(t => t.TicketCount) 
            });
        
        var topPassengers = from ticket in ticketsAirlines
            join maxTicket in maxTicketsPerAirline on ticket.Airline equals maxTicket.Airline
            where ticket.TicketCount == maxTicket.MaxCount 
            orderby ticket.Airline
            select ticket;

        foreach (var passenger in topPassengers)
        {
            Console.WriteLine($"{passenger.Passenger} - {passenger.Airline} ({passenger.TicketCount})");
        }
    }
}