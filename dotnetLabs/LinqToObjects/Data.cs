namespace dotnetLabs.LinqToObjects;

public static class Data
{
    public static List<Passenger> passengers = new()
    {
        new Passenger { Id = 1, Name = "John", Surname = "Doe", Age = 30 },
        new Passenger { Id = 2, Name = "Alice", Surname = "Smith", Age = 25 },
        new Passenger { Id = 3, Name = "Bob", Surname = "Johnson", Age = 40 },
        new Passenger { Id = 4, Name = "Emily", Surname = "Davis", Age = 35 },
        new Passenger { Id = 5, Name = "Michael", Surname = "Brown", Age = 28 },
        new Passenger { Id = 6, Name = "Sophia", Surname = "Wilson", Age = 32 },
        new Passenger { Id = 7, Name = "Daniel", Surname = "Martinez", Age = 38 }
    };

    public static List<Airline> airlines = new()
    {
        new Airline { Id = 1, Name = "Airline A", Country = "USA" },
        new Airline { Id = 2, Name = "Airline B", Country = "UK" },
        new Airline { Id = 3, Name = "Airline C", Country = "Germany" },
        new Airline { Id = 4, Name = "Airline D", Country = "France" },
        new Airline { Id = 5, Name = "Airline E", Country = "Japan" },
        new Airline { Id = 6, Name = "Airline F", Country = "France" },
        new Airline { Id = 7, Name = "Airline G", Country = "USA" }
    };

    public static List<Plane> planes = new()
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
        new Plane { Id = 10, Model = "Boeing 737", RegNumber = "MN-890", Capacity = 180, AirlineId = 7 },
        new Plane { Id = 11, Model = "Kleine 001", RegNumber = "RF-931", Capacity = 10, AirlineId = 2 },
    };

    public static List<Route> routes = new()
    {
        new Route
        {
            Id = 1, Origin = "New York", OriginCountry = "USA", Destination = "London",
            DestinationCountry = "Great Britain"
        },
        new Route
        {
            Id = 2, Origin = "Los Angeles", OriginCountry = "USA", Destination = "Tokyo", DestinationCountry = "Japan"
        },
        new Route
        {
            Id = 3, Origin = "Paris", OriginCountry = "France", Destination = "Berlin", DestinationCountry = "Germany"
        },
        new Route
        {
            Id = 4, Origin = "Chicago", OriginCountry = "USA", Destination = "Toronto", DestinationCountry = "Canada"
        },
        new Route
        {
            Id = 5, Origin = "Sydney", OriginCountry = "Australia", Destination = "Singapore",
            DestinationCountry = "Singapore"
        },
        new Route
        {
            Id = 6, Origin = "Dubai", OriginCountry = "UAE", Destination = "New York", DestinationCountry = "USA"
        },
        new Route
        {
            Id = 7, Origin = "London", OriginCountry = "UK", Destination = "Sydney", DestinationCountry = "Australia"
        },
        new Route
        {
            Id = 8, Origin = "London", OriginCountry = "UK", Destination = "Tokyo", DestinationCountry = "Japan"
        }
    };

    public static List<RoutePlane> routePlanes = new()
    {
        new RoutePlane { Id = 1, PlaneId = 1, RouteId = 1 },
        new RoutePlane { Id = 2, PlaneId = 2, RouteId = 2 },
        new RoutePlane { Id = 3, PlaneId = 3, RouteId = 3 },
        new RoutePlane { Id = 4, PlaneId = 4, RouteId = 4 },
        new RoutePlane { Id = 5, PlaneId = 5, RouteId = 5 },
        new RoutePlane { Id = 6, PlaneId = 6, RouteId = 6 },
        new RoutePlane { Id = 7, PlaneId = 7, RouteId = 7 },
        new RoutePlane { Id = 8, PlaneId = 9, RouteId = 1 },
        new RoutePlane { Id = 9, PlaneId = 10, RouteId = 2 },
        new RoutePlane { Id = 10, PlaneId = 11, RouteId = 8 },
    };

    public static List<Flight> flights = new()
    {
        new Flight
        {
            Id = 1, DepartureDateTime = DateTime.UtcNow.AddMonths(-5),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-5).AddMinutes(45), RoutePlaneId = 1
        },
        new Flight
        {
            Id = 2, DepartureDateTime = DateTime.UtcNow.AddMonths(-4),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-4).AddMinutes(20), RoutePlaneId = 1
        },
        new Flight
        {
            Id = 3, DepartureDateTime = DateTime.UtcNow.AddMonths(-3),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-3).AddMinutes(50), RoutePlaneId = 2
        },
        new Flight
        {
            Id = 4, DepartureDateTime = DateTime.UtcNow.AddMonths(-2),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-2).AddMinutes(10), RoutePlaneId = 2
        },
        new Flight
        {
            Id = 5, DepartureDateTime = DateTime.UtcNow.AddMonths(-1),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-1).AddMinutes(60), RoutePlaneId = 3
        },
        new Flight
        {
            Id = 6, DepartureDateTime = DateTime.UtcNow.AddMonths(-7),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-7).AddMinutes(15), RoutePlaneId = 3
        },
        new Flight
        {
            Id = 7, DepartureDateTime = DateTime.UtcNow.AddMonths(-6),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-6).AddMinutes(25), RoutePlaneId = 4
        },
        new Flight
        {
            Id = 8, DepartureDateTime = DateTime.UtcNow.AddMonths(-3),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-3).AddMinutes(40), RoutePlaneId = 5
        },
        new Flight
        {
            Id = 9, DepartureDateTime = DateTime.UtcNow.AddMonths(-1),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-1).AddMinutes(35), RoutePlaneId = 5
        },
        new Flight
        {
            Id = 10, DepartureDateTime = DateTime.UtcNow.AddMonths(-2),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-2).AddMinutes(50), RoutePlaneId = 9
        },
        new Flight
        {
            Id = 11, DepartureDateTime = DateTime.UtcNow.AddMonths(-3),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-3).AddMinutes(20), RoutePlaneId = 9
        },
        new Flight
        {
            Id = 12, DepartureDateTime = DateTime.UtcNow.AddMonths(-3),
            RealDepartureDateTime = DateTime.UtcNow.AddMonths(-3).AddMinutes(20), RoutePlaneId = 10
        },
    };

    public static List<Ticket> tickets = new()
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
        new Ticket { Id = 14, SeatClass = SeatClass.Economy, PassengerId = 6, FlightId = 7 },
        new Ticket { Id = 15, SeatClass = SeatClass.Business, PassengerId = 1, FlightId = 3 },
        new Ticket { Id = 16, SeatClass = SeatClass.Business, PassengerId = 1, FlightId = 5 },
        new Ticket { Id = 17, SeatClass = SeatClass.Business, PassengerId = 1, FlightId = 7 },
        new Ticket { Id = 18, SeatClass = SeatClass.Business, PassengerId = 1, FlightId = 8 },
        new Ticket { Id = 19, SeatClass = SeatClass.Business, PassengerId = 1, FlightId = 10 },
        new Ticket { Id = 20, SeatClass = SeatClass.Business, PassengerId = 2, FlightId = 12 },
        new Ticket { Id = 21, SeatClass = SeatClass.Business, PassengerId = 3, FlightId = 12 },
        new Ticket { Id = 22, SeatClass = SeatClass.Business, PassengerId = 4, FlightId = 12 },
        new Ticket { Id = 23, SeatClass = SeatClass.Business, PassengerId = 5, FlightId = 12 },
        new Ticket { Id = 24, SeatClass = SeatClass.Business, PassengerId = 6, FlightId = 12 },
        new Ticket { Id = 25, SeatClass = SeatClass.Business, PassengerId = 7, FlightId = 12 },
        new Ticket { Id = 26, SeatClass = SeatClass.Business, PassengerId = 1, FlightId = 12 },
    };
}