using System.Xml.Linq;
using System.Linq;
using System.Xml.XPath;

namespace dotnetLabs;

public static class XmlQueries
{
    private static XDocument doc = XDocument.Load("Airport.xml");
    
    public static void Run()
    {
        Query1();
    }

    private static void Query1()
    {
        var planes = doc.Elements("plane").Select(p => p.Elements("Capacity"));
        Console.WriteLine(planes);
    }
}