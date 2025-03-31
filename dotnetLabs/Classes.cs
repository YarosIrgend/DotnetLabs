using System.Globalization;
using System.Xml.Serialization;

namespace dotnetLabs;

public enum SeatClass
{
    Economy,
    Business,
    First
}

public class Airline
{
    [XmlElement] public int Id { get; set; }
    [XmlElement] public string Name { get; set; }
    [XmlElement] public string Country { get; set; }

    public Airline()
    {
    }
}

public class Flight
{
    [XmlElement] 
    public int Id { get; set; }

    [XmlIgnore] 
    public DateTime DepartureDateTime { get; set; }

    // для (де)серіалізації
    [XmlElement("DepartureDateTime")]
    public string DepartureDateTimeString
    {
        get => DepartureDateTime.ToString("yyyy-MM-dd HH:mm"); // Серіалізація
        set => DepartureDateTime = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture); // Десеріалізація
    }

    [XmlIgnore] 
    public DateTime RealDepartureDateTime { get; set; }

    // для (де)серіалізації
    [XmlElement("RealDepartureDateTime")]
    public string RealDepartureDateTimeString
    {
        get => RealDepartureDateTime.ToString("yyyy-MM-dd HH:mm");
        set => RealDepartureDateTime = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
    }

    [XmlElement] 
    public int RoutePlaneId { get; set; }

    public Flight() {}
}

public class Passenger
{
    [XmlElement] public int Id { get; set; }
    [XmlElement] public string Name { get; set; }
    [XmlElement] public string Surname { get; set; }
    [XmlElement] public int Age { get; set; }

    public Passenger()
    {
    }
}

public class Plane
{
    [XmlElement] public int Id { get; set; }
    [XmlElement] public string Model { get; set; }
    [XmlElement] public string RegNumber { get; set; }
    [XmlElement] public int Capacity { get; set; }
    [XmlElement] public int AirlineId { get; set; }

    public Plane()
    {
    }
}

public class Route
{
    [XmlElement] public int Id { get; set; }
    [XmlElement] public string Origin { get; set; }
    [XmlElement] public string OriginCountry { get; set; }
    [XmlElement] public string Destination { get; set; }
    [XmlElement] public string DestinationCountry { get; set; }

    public Route()
    {
    }
}

public class RoutePlane
{
    [XmlElement] public int Id { get; set; }
    [XmlElement] public int PlaneId { get; set; }
    [XmlElement] public int RouteId { get; set; }

    public RoutePlane()
    {
    }
}

public class Ticket
{
    [XmlElement] public int Id { get; set; }
    [XmlElement] public SeatClass SeatClass { get; set; }
    [XmlElement] public int PassengerId { get; set; }
    [XmlElement] public int FlightId { get; set; }

    public Ticket()
    {
    }
}

[XmlRoot("AirportSystem")]
public class AirportSystem
{
    [XmlArray("passengers")]
    [XmlArrayItem("passenger")]
    public List<Passenger> Passengers { get; set; } = new();

    [XmlArray("airlines")]
    [XmlArrayItem("airline")]
    public List<Airline> Airlines { get; set; } = new();

    [XmlArray("flights")]
    [XmlArrayItem("flight")]
    public List<Flight> Flights { get; set; } = new();

    [XmlArray("planes")]
    [XmlArrayItem("plane")]
    public List<Plane> Planes { get; set; } = new();

    [XmlArray("routes")]
    [XmlArrayItem("route")]
    public List<Route> Routes { get; set; } = new();

    [XmlArray("tickets")]
    [XmlArrayItem("ticket")]
    public List<Ticket> Tickets { get; set; } = new();

    [XmlArray("routePlanes")]
    [XmlArrayItem("routePlane")]
    public List<RoutePlane> RoutePlanes { get; set; } = new();
}
