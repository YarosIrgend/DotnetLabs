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
    [XmlElement] public int Id { get; set; }
    [XmlElement] public DateTime DepartureDateTime { get; set; }
    [XmlElement] public DateTime RealDepartureDateTime { get; set; }
    [XmlElement] public int routePlaneId { get; set; }

    public Flight()
    {
    }
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