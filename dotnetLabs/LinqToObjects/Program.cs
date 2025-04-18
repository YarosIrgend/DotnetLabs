﻿namespace dotnetLabs.LinqToObjects;

internal static class Program
{
    public static void Run()
    {
        List<Passenger> passengers = Data.passengers;
        List<Airline> airlines = Data.airlines;
        List<Plane> planes = Data.planes;
        List<Flight> flights = Data.flights;
        List<Route> routes = Data.routes;
        List<RoutePlane> routePlanes = Data.routePlanes;
        List<Ticket> tickets = Data.tickets;

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // фільтрація 
// відбір літаків Боїнг 777 з місткістю не менше 300
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Фільтрація");
        Console.ResetColor();
        var collection1 = from plane in planes
            where plane.Model == "Boeing 777" && plane.Capacity >= 300
            select plane;
        foreach (var plane in collection1)
        {
            Console.WriteLine($"{plane.RegNumber} - {plane.Capacity}");
        }

        Console.WriteLine();

// з'єднання
// декартовий добуток літаків та авіакомпаній
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("З'єднання");
        Console.ResetColor();
        var collection2 = from plane in planes
            from airline in airlines
            select new { regNumber = plane.RegNumber, airline = airline.Name };
        foreach (var item in collection2)
        {
            Console.WriteLine($"{item.regNumber} - {item.airline}");
        }

        Console.WriteLine();


// групування
// групування літаків за їхніми авіакомпаніями
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Групування");
        Console.ResetColor();
        var collection3 = from plane in planes
            join airline in airlines
                on plane.AirlineId equals airline.Id
            group plane by airline.Name;

        foreach (var plane in collection3)
        {
            Console.WriteLine($"{plane.Key} - {plane.Count()}");
        }

        Console.WriteLine();

// групування з фільтрацією
// групування пасажирів з квитками бізнес-класу за віковими категоріями 
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Групування з фільтрацією");
        Console.ResetColor();
        var collection4 = passengers
            .Where(p => tickets.Any(t => t.PassengerId == p.Id && t.SeatClass == SeatClass.Business))
            .GroupBy(p =>
            {
                return p.Age switch
                {
                    <= 27 => "Молодші",
                    <= 32 => "Середні",
                    >= 33 => "Старші",
                };
            })
            .Select(group => new
            {
                AgeGroup = group.Key,
                Passengers = group.ToList()
            })
            .ToList();

        foreach (var group in collection4)
        {
            foreach (var passenger in group.Passengers)
            {
                Console.WriteLine($"{passenger.Surname} - {group.AgeGroup}");
            }
        }

        Console.WriteLine();

// агрегування
// Вивід пасажирів, чий вік дорівнює середньому
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Агрегування");
        Console.ResetColor();
        var collection5 = passengers.Where(p => p.Age == Math.Floor(passengers.Average(p => p.Age)));
        foreach (var passenger in collection5)
        {
            Console.Write($"{passenger.Surname} {passenger.Name}, ");
        }

        Console.WriteLine('\n');

// групування з агрегуванням
// групування пасажирів за віковими категоріями з додатковими даними 
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Групування з агрегуванням");
        Console.ResetColor();
        var collection6 = passengers
            .GroupBy(p =>
            {
                return p.Age switch
                {
                    <= 27 => "Молодші",
                    <= 32 => "Середні",
                    >= 33 => "Старші",
                };
            })
            .Select(group => new
            {
                AgeRange = group.Key,
                Count = group.Count(),
                AverageAge = group.Average(p => p.Age),
                Passengers = group.ToList()
            });
        foreach (var group in collection6)
        {
            Console.WriteLine($"{group.AgeRange}, Average age: {group.AverageAge}");
            Console.Write('\t');
            foreach (var p in group.Passengers)
            {
                Console.Write($"{p.Surname} {p.Name}, ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();

// сортування з фільтрацією
// пасажири віку від 20 до 30 у спадному порядку
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Сортування з фільтрацією");
        Console.ResetColor();
        var collection7 = from passenger in passengers
            where passenger.Age is >= 20 and <= 30
            orderby passenger.Age descending
            select passenger;
        foreach (var passenger in collection7)
        {
            Console.WriteLine($"{passenger.Surname} - {passenger.Age}");
        }

        Console.WriteLine();

// об'єднання результатів декількох запитів в один
// об'єднання літаків Boeing 777 та літаків авіакомпаній Британії
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Об'єднання результатів");
        Console.ResetColor();
        var boeings = planes.Join(airlines, p => p.AirlineId, a => a.Id,
                (plane, airline) => new { Plane = plane, Airline = airline })
            .Where(plane => plane.Plane.Model == "Boeing 777");
        var uk_planes = planes.Join(airlines, p => p.AirlineId, a => a.Id,
            (plane, airline) => new { Plane = plane, Airline = airline }).Where(p => p.Airline.Country == "UK");
        var collection8 = boeings.Union(uk_planes).Distinct();

        foreach (var plane in collection8)
        {
            Console.WriteLine($"{plane.Plane.Model}, {plane.Plane.RegNumber} - {plane.Airline.Country}");
        }

        Console.WriteLine();

// перетворення в інші структури
// перетворення у словник маршрути. Ключ - id, значення - рейс
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Перетворення у словник");
        Console.ResetColor();
        var collection9 = routes.ToDictionary(route => route.Id);
        foreach (var route in collection9)
        {
            Console.WriteLine($"ID: {route.Key}, Value: {route.Value.Origin}-{route.Value.Destination}");
        }

        Console.WriteLine();

// використання проміжних змінних
// групування рейсів по країнах вильоту з використанням проміжної route_group
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Використання проміжних змінних");
        Console.ResetColor();
        var collection10 = from route in routes
            group route by route.OriginCountry
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
                Console.WriteLine($"\t{item.Origin} - {item.Destination}");
            }
        }

        Console.WriteLine();

// запит до варіанту 1
// маршрути, де середня затримка рейсів перевищує 30 хвилин за останні 6 місяців
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Запит до варіанту 1");
        Console.ResetColor();

        DateTime sixMonthsAgo = DateTime.Now.AddMonths(-6);
        var delayedRoutes = from f in flights
            where f.DepartureDateTime >= sixMonthsAgo
            group f by f.RoutePlaneId
            into g
            let avgDelay = Math.Floor(g.Average(f => (f.RealDepartureDateTime - f.DepartureDateTime).TotalMinutes))
            where avgDelay > 30
            join r in routes on g.Key equals r.Id
            select new { r.Origin, r.Destination, AverageDelay = avgDelay };

        foreach (var route in delayedRoutes)
        {
            Console.WriteLine($"Маршрут: {route.Origin}-{route.Destination}, Затримка: {route.AverageDelay} хв");
        }

        Console.WriteLine();

// запит до варіанту 2
// пасажири, які літали з більш ніж 5 авіакомпаніями протягом року
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Запит до варіанту 2");
        Console.ResetColor();

        DateTime yearAgo = DateTime.Now.AddYears(-1);
        var frequentPassengers =
            from ticket in tickets
            join flight in flights on ticket.FlightId equals flight.Id
            where flight.DepartureDateTime >= yearAgo
            join routePlane in routePlanes on flight.RoutePlaneId equals routePlane.Id
            join plane in planes on routePlane.PlaneId equals plane.Id
            join airline in airlines on plane.AirlineId equals airline.Id
            group airline by ticket.PassengerId
            into passengerAirlines
            where passengerAirlines.Select(a => a.Id).Distinct().Count() > 5
            join passenger in passengers on passengerAirlines.Key equals passenger.Id
            select passenger;

        foreach (var passenger in frequentPassengers)
        {
            Console.WriteLine($"{passenger.Surname} {passenger.Name}");
        }

        Console.WriteLine();

// запит до варіанту 3
// маршрути, на яких середня кількість пасажирів у бізнес-класі перевищує 60% місткості літака. 
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Запит до варіанту 3");
        Console.ResetColor();

        var routesWithHighBusinessClassLoad =
            from flight in flights
            join routePlane in routePlanes on flight.RoutePlaneId equals routePlane.Id
            join route in routes on routePlane.RouteId equals route.Id
            join plane in planes on routePlane.PlaneId equals plane.Id
            join ticket in tickets on flight.Id equals ticket.FlightId
            where ticket.SeatClass == SeatClass.Business
            group ticket by new { route.Id, route.Origin, route.Destination, plane.Capacity }
            into grouped
            let averageBusinessPassengers = grouped.Count() / (double)grouped.Select(t => t.FlightId).Distinct().Count()
            where averageBusinessPassengers > 0.6 * grouped.Key.Capacity
            select new
            {
                RouteId = grouped.Key.Id,
                Origin = grouped.Key.Origin,
                Destination = grouped.Key.Destination,
                AverageBusinessPassengers = averageBusinessPassengers,
            };

        foreach (var route in routesWithHighBusinessClassLoad)
        {
            Console.WriteLine($"{route.Origin}-{route.Destination}");
        }


        Console.WriteLine();

// запит до варіанту 4
// авіакомпанії, у яких відсоток рейсів із запізненням понад 30 
// хвилин зріс більш ніж на 20% за останній рік
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Запит до варіанту 4");
        Console.ResetColor();
        var delayedAirlines =
            from f in flights
            join rp in routePlanes on f.RoutePlaneId equals rp.RouteId
            join p in planes on rp.PlaneId equals p.Id
            join a in airlines on p.AirlineId equals a.Id
            let delayMinutes = (f.RealDepartureDateTime - f.DepartureDateTime).TotalMinutes
            let oneYearAgo = DateTime.UtcNow.AddYears(-1)
            group new { f, delayMinutes } by new { a.Id, a.Name }
            into g
            let pastDelays = g.Count(x => x.f.DepartureDateTime <= sixMonthsAgo && x.delayMinutes > 30)
            let recentDelays = g.Count(x => x.f.DepartureDateTime > sixMonthsAgo && x.delayMinutes > 30)
            let pastTotal = g.Count(x => x.f.DepartureDateTime <= sixMonthsAgo)
            let recentTotal = g.Count(x => x.f.DepartureDateTime > sixMonthsAgo)
            let pastRate = pastTotal == 0 ? 0 : (double)pastDelays / pastTotal
            let recentRate = recentTotal == 0 ? 0 : (double)recentDelays / recentTotal
            where recentRate - pastRate > 0.2
            select new { g.Key.Name, IncreasePercentage = (recentRate - pastRate) * 100 };

        foreach (var airline in delayedAirlines)
        {
            Console.WriteLine($"{airline.Name}, {airline.IncreasePercentage}");
        }
    }
}