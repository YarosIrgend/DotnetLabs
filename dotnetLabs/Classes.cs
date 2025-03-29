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
    [XmlAttribute]
    public int Id { get; set; }
    [XmlElement]
    public string Name { get; set; }
    [XmlElement]
    public string Country { get; set; }
}

public class Flight
{
    public int Id { get; set; }
    [XmlElement]
    public DateTime DepartureDateTime { get; set; }
    [XmlElement]
    public DateTime RealDepartureDateTime { get; set; }
    [XmlElement]
    public int routePlaneId { get; set; }
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
    public int Id { get; set; }
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