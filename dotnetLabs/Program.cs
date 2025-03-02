List<Passenger> passengers = new()
{
    new Passenger { Id = 1, Name = "John", Surname = "Doe", Age = 30 },
    new Passenger { Id = 2, Name = "Alice", Surname = "Smith", Age = 25 },
    new Passenger { Id = 3, Name = "Bob", Surname = "Johnson", Age = 40 },
    new Passenger { Id = 4, Name = "Emily", Surname = "Davis", Age = 35 },
    new Passenger { Id = 5, Name = "Michael", Surname = "Brown", Age = 28 },
    new Passenger { Id = 6, Name = "Sophia", Surname = "Wilson", Age = 32 },
    new Passenger { Id = 7, Name = "Daniel", Surname = "Martinez", Age = 38 }
};

List<Airline> airlines = new()
{
    new Airline { Id = 1, Name = "Airline A", Country = "USA" },
    new Airline { Id = 2, Name = "Airline B", Country = "UK" },
    new Airline { Id = 3, Name = "Airline C", Country = "Germany" },
    new Airline { Id = 4, Name = "Airline D", Country = "France" },
    new Airline { Id = 5, Name = "Airline E", Country = "Japan" },
    new Airline { Id = 6, Name = "Airline F", Country = "France" },
    new Airline { Id = 7, Name = "Airline G", Country = "USA" }
};

List<Plane> planes = new()
{
    new Plane { Id = 1, Model = "Boeing 737", RegNumber = "AB-123", Capacity = 180, AirlineId = 1 },
    new Plane { Id = 2, Model = "Airbus A320", RegNumber = "CD-456", Capacity = 200, AirlineId = 2 },
    new Plane { Id = 3, Model = "Boeing 777", RegNumber = "EF-789", Capacity = 350, AirlineId = 3 },
    new Plane { Id = 4, Model = "Airbus A350", RegNumber = "GH-012", Capacity = 300, AirlineId = 4 },
    new Plane { Id = 5, Model = "Embraer E190", RegNumber = "IJ-345", Capacity = 120, AirlineId = 5 },
    new Plane { Id = 6, Model = "Boeing 777", RegNumber = "EF-790", Capacity = 300, AirlineId = 3 },
    new Plane { Id = 7, Model = "Boeing 777", RegNumber = "EF-700", Capacity = 250, AirlineId = 3 },
    new Plane { Id = 8, Model = "Airbus A320", RegNumber = "CD-123", Capacity = 150, AirlineId = 2 },
    new Plane { Id = 9, Model = "Boeing 747", RegNumber = "KL-567", Capacity = 400, AirlineId = 6 },
    new Plane { Id = 10, Model = "Boeing 737", RegNumber = "MN-890", Capacity = 180, AirlineId = 7 }
};

List<Route> routes = new()
{
    new Route { Id = 1, Origin = "New York", OriginCountry = "USA", Destination = "London", DestinationCountry = "Great Britain" },
    new Route { Id = 2, Origin = "Los Angeles", OriginCountry = "USA", Destination = "Tokyo", DestinationCountry = "Japan" },
    new Route { Id = 3, Origin = "Paris", OriginCountry = "France", Destination = "Berlin", DestinationCountry = "Germany" },
    new Route { Id = 4, Origin = "Chicago", OriginCountry = "USA", Destination = "Toronto", DestinationCountry = "Canada" },
    new Route { Id = 5, Origin = "Sydney", OriginCountry = "Australia", Destination = "Singapore", DestinationCountry = "Singapore" },
    new Route { Id = 6, Origin = "Dubai", OriginCountry = "UAE", Destination = "New York", DestinationCountry = "USA" },
    new Route { Id = 7, Origin = "London", OriginCountry = "UK", Destination = "Sydney", DestinationCountry = "Australia" }
};

List<RoutePlane> routePlanes = new()
{
    new RoutePlane { PlaneId = 1, RouteId = 1 },
    new RoutePlane { PlaneId = 2, RouteId = 2 },
    new RoutePlane { PlaneId = 3, RouteId = 3 },
    new RoutePlane { PlaneId = 4, RouteId = 4 },
    new RoutePlane { PlaneId = 5, RouteId = 5 },
    new RoutePlane { PlaneId = 6, RouteId = 6 },
    new RoutePlane { PlaneId = 7, RouteId = 7 },
    new RoutePlane { PlaneId = 9, RouteId = 1 },
    new RoutePlane { PlaneId = 10, RouteId = 2 }
};

List<Flight> flights = new()
{
    new Flight { Id = 1, departureDateTime = DateTime.UtcNow.AddMonths(-5), realDepartureDateTime = DateTime.UtcNow.AddMonths(-5).AddMinutes(45), routeId = 1 },
    new Flight { Id = 2, departureDateTime = DateTime.UtcNow.AddMonths(-4), realDepartureDateTime = DateTime.UtcNow.AddMonths(-4).AddMinutes(20), routeId = 1 },
    new Flight { Id = 3, departureDateTime = DateTime.UtcNow.AddMonths(-3), realDepartureDateTime = DateTime.UtcNow.AddMonths(-3).AddMinutes(50), routeId = 2 },
    new Flight { Id = 4, departureDateTime = DateTime.UtcNow.AddMonths(-2), realDepartureDateTime = DateTime.UtcNow.AddMonths(-2).AddMinutes(10), routeId = 2 },
    new Flight { Id = 5, departureDateTime = DateTime.UtcNow.AddMonths(-1), realDepartureDateTime = DateTime.UtcNow.AddMonths(-1).AddMinutes(60), routeId = 3 },
    new Flight { Id = 6, departureDateTime = DateTime.UtcNow.AddMonths(-7), realDepartureDateTime = DateTime.UtcNow.AddMonths(-7).AddMinutes(15), routeId = 3 },
    new Flight { Id = 7, departureDateTime = DateTime.UtcNow.AddMonths(-6), realDepartureDateTime = DateTime.UtcNow.AddMonths(-6).AddMinutes(25), routeId = 6 },
    new Flight { Id = 8, departureDateTime = DateTime.UtcNow.AddMonths(-3), realDepartureDateTime = DateTime.UtcNow.AddMonths(-3).AddMinutes(40), routeId = 7 },
    new Flight { Id = 9, departureDateTime = DateTime.UtcNow.AddMonths(-1), realDepartureDateTime = DateTime.UtcNow.AddMonths(-1).AddMinutes(35), routeId = 6 }
};

List<Ticket> tickets = new()
{
    new Ticket { Id = 1, SeatClass = SeatClass.Business, PassengerId = 1, FlightId = 1 },
    new Ticket { Id = 2, SeatClass = SeatClass.Business, PassengerId = 2, FlightId = 1 },
    new Ticket { Id = 3, SeatClass = SeatClass.Business, PassengerId = 3, FlightId = 1 },
    new Ticket { Id = 4, SeatClass = SeatClass.Business, PassengerId = 4, FlightId = 2 },
    new Ticket { Id = 5, SeatClass = SeatClass.Business, PassengerId = 5, FlightId = 3 },
    new Ticket { Id = 6, SeatClass = SeatClass.Economy, PassengerId = 6, FlightId = 3 },
    new Ticket { Id = 7, SeatClass = SeatClass.Economy, PassengerId = 7, FlightId = 4 },
    new Ticket { Id = 8, SeatClass = SeatClass.Business, PassengerId = 1, FlightId = 5 },
    new Ticket { Id = 9, SeatClass = SeatClass.Business, PassengerId = 2, FlightId = 5 },
    new Ticket { Id = 10, SeatClass = SeatClass.Business, PassengerId = 3, FlightId = 5 },
    new Ticket { Id = 11, SeatClass = SeatClass.First, PassengerId = 4, FlightId = 5 },
    new Ticket { Id = 12, SeatClass = SeatClass.Economy, PassengerId = 2, FlightId = 4 },
    new Ticket { Id = 13, SeatClass = SeatClass.Business, PassengerId = 5, FlightId = 7 },
    new Ticket { Id = 14, SeatClass = SeatClass.Economy, PassengerId = 6, FlightId = 7 }
};



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
// групування літаків за країнами їхніх авіакомпаній
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Групування");
Console.ResetColor();
var collection3 = from plane in planes
    join airline in airlines
        on plane.AirlineId equals airline.Id
    group plane by new { Id = plane.AirlineId, country = airline.Country };

foreach (var plane in collection3)
{
    Console.WriteLine($"{plane.Key.country} - {plane.Count()}");
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
    Console.WriteLine(group.AgeRange);
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
    (plane, airline) => new { Plane = plane, Airline = airline }).Where(plane => plane.Plane.Model == "Boeing 777");
var uk_planes = planes.Join(airlines, p => p.AirlineId, a => a.Id,
    (plane, airline) => new { Plane = plane, Airline = airline }).Where(p => p.Airline.Country == "UK");
var collection8 = boeings.Union(uk_planes).Distinct();

foreach (var plane in collection8)
{
    Console.WriteLine($"{plane.Plane.Model}, {plane.Plane.RegNumber} - {plane.Airline.Country}");
}

Console.WriteLine();

// перетворення в інші структури
// перетворення у словник маршрути. Ключ - id, значення (рейс та час)
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Об'єднання результатів");
Console.ResetColor();
var collection9 = routes.ToDictionary(route => route.Id);
foreach (var route in collection9)
{
    Console.WriteLine($"ID: {route.Key} - {route.Value.Origin}-{route.Value.Destination}");
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
    where f.departureDateTime >= sixMonthsAgo
    group f by f.routeId
    into g
    let avgDelay = Math.Floor(g.Average(f => (f.realDepartureDateTime - f.departureDateTime).TotalMinutes))
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
var passengerFlownWithFiveLines = from f in flights
    where f.departureDateTime >= yearAgo
    join t in tickets on f.Id equals t.FlightId
    join p in passengers on t.PassengerId equals p.Id
    join r in routes on f.routeId equals r.Id
    join rp in routePlanes on r.Id equals rp.RouteId
    join pl in planes on r.Id equals pl.Id
    join a in airlines on r.Id equals a.Id
    group a by t.PassengerId
    into g
    where g.Select(a => a.Id).Distinct().Count() > 5 // Пасажири, що літали з >5 авіакомпаніями
    join passenger in passengers on g.Key equals passenger.Id
    select passenger;
foreach (var passenger in passengerFlownWithFiveLines)
{
    Console.WriteLine($"{passenger.Surname} {passenger.Name}");
}
Console.WriteLine();

// запит до варіанту 3
// маршрути, на яких середня кількість пасажирів у бізнес-класі перевищує 60% місткості літака. 
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Запит до варіанту 3");
Console.ResetColor();

var routesWithHighBusinessClass = 
    from f in flights
    join t in tickets on f.Id equals t.FlightId
    join rp in routePlanes on f.routeId equals rp.RouteId
    join p in planes on rp.PlaneId equals p.Id
    where t.SeatClass == SeatClass.Business
    group new { f, t, p } by f.routeId into g
    let avgBusinessPassengers = g.Count()
    let avgCapacity = g.Average(x => x.p.Capacity)
    where avgBusinessPassengers / avgCapacity > 0.6
    join r in routes on g.Key equals r.Id
    select new { r.Origin, r.Destination, BusinessPassengersPercentage = avgBusinessPassengers / avgCapacity };

foreach (var route in routesWithHighBusinessClass)
{
    Console.WriteLine($"{route.Origin}-{route.Destination}, {route.BusinessPassengersPercentage}");
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
    join rp in routePlanes on f.routeId equals rp.RouteId
    join p in planes on rp.PlaneId equals p.Id
    join a in airlines on p.AirlineId equals a.Id
    let delayMinutes = (f.realDepartureDateTime - f.departureDateTime).TotalMinutes
    let oneYearAgo = DateTime.UtcNow.AddYears(-1)
    group new { f, delayMinutes } by new { a.Id, a.Name } into g
    let pastDelays = g.Count(x => x.f.departureDateTime <= sixMonthsAgo && x.delayMinutes > 30)
    let recentDelays = g.Count(x => x.f.departureDateTime > sixMonthsAgo && x.delayMinutes > 30)
    let pastTotal = g.Count(x => x.f.departureDateTime <= sixMonthsAgo)
    let recentTotal = g.Count(x => x.f.departureDateTime > sixMonthsAgo)
    let pastRate = pastTotal == 0 ? 0 : (double)pastDelays / pastTotal
    let recentRate = recentTotal == 0 ? 0 : (double)recentDelays / recentTotal
    where (recentRate - pastRate) > 0.2
    select new { g.Key.Name, IncreasePercentage = (recentRate - pastRate) * 100 };

foreach (var airline in delayedAirlines)
{
    Console.WriteLine($"{airline.Name}, {airline.IncreasePercentage}");
}


public enum SeatClass
{
    Economy,
    Business,
    First
}

public class Airline
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}

public class Flight
{
    public int Id { get; set; }
    public DateTime departureDateTime { get; set; }
    public DateTime realDepartureDateTime { get; set; }
    public int routeId { get; set; }
}

public class Passenger
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
}

public class Plane
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string RegNumber { get; set; }
    public int Capacity { get; set; }
    public int AirlineId { get; set; }
}

public class Route
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string OriginCountry { get; set; }
    public string Destination { get; set; }
    public string DestinationCountry { get; set; }
}

public class RoutePlane
{
    public int PlaneId { get; set; }
    public int RouteId { get; set; }
}

public class Ticket
{
    public int Id { get; set; }
    public SeatClass SeatClass { get; set; }
    public int PassengerId { get; set; }
    public int FlightId { get; set; }
}