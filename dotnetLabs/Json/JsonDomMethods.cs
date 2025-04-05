using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace dotnetLabs.Json;

public static class JsonDomMethods
{
    private static JsonDocument doc;
    private static JsonElement root;

    private static JsonDocumentOptions docOptions = new();


    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1 - JsonDocument");
        Console.WriteLine("2 - JsonNode");
        Console.ResetColor();
        switch (Console.ReadLine())
        {
            case "1":
                JsonDocumentRun();
                break;
            case "2":
                JsonNodeRun();
                break;
        }

        Console.ReadLine();
        Console.Clear();
    }

    private static void JsonDocumentRun()
    {
        string json = File.ReadAllText("Airport.json");
        doc = JsonDocument.Parse(json, docOptions);
        root = doc.RootElement;
        Console.WriteLine("Покажем пасажирів, використовуючи методи та типи JsonDocument");
        foreach (var passenger in root.GetProperty("Passengers").EnumerateArray())
        {
            Console.WriteLine($"Passenger: {passenger.GetProperty("Surname")} {passenger.GetProperty("Name")}, {
                passenger.GetProperty("Age")}");
        }
    }

    private static void JsonNodeRun()
    {
        Console.WriteLine("Покажем авіалінії, використовуючи методи та типи JsonNode");
        string json = File.ReadAllText("Airport.json");
        JsonNode node = JsonNode.Parse(json);
        foreach (var airline in node["Airlines"].AsArray())
        {
            Console.WriteLine($"{airline["Name"]} - {airline["Country"]}");
        }
    }
}