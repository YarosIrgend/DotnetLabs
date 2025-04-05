namespace dotnetLabs.Json;

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

    public Airline()
    {
    }
}

public class Flight
{
    public int Id { get; set; }

    public DateTime DepartureDateTime { get; set; }

    public DateTime RealDepartureDateTime { get; set; }

    public int RoutePlaneId { get; set; }

    public Flight()
    {
    }
}

public class Passenger
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public Passenger()
    {
    }
}

public class Plane
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string RegNumber { get; set; }
    public int Capacity { get; set; }
    public int AirlineId { get; set; }

    public Plane()
    {
    }
}

public class Route
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string OriginCountry { get; set; }
    public string Destination { get; set; }
    public string DestinationCountry { get; set; }

    public Route()
    {
    }
}

public class RoutePlane
{
    public int Id { get; set; }
    public int PlaneId { get; set; }
    public int RouteId { get; set; }

    public RoutePlane()
    {
    }
}

public class Ticket
{
    public int Id { get; set; }
    public SeatClass SeatClass { get; set; }
    public int PassengerId { get; set; }
    public int FlightId { get; set; }

    public Ticket()
    {
    }
}

public class AirportSystem
{
    public List<Passenger> Passengers { get; set; } = new();

    public List<Airline> Airlines { get; set; } = new();

    public List<Flight> Flights { get; set; } = new();

    public List<Plane> Planes { get; set; } = new();

    public List<Route> Routes { get; set; } = new();

    public List<Ticket> Tickets { get; set; } = new();

    public List<RoutePlane> RoutePlanes { get; set; } = new();
}