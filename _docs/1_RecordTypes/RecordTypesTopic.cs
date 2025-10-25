using System;

namespace D1_RecordTypesNamespace;

public record Person(string FirstName, string LastName);

public record Address(string Street, string City)
{
    public string Country { get; init; } = "Deutschland";
}

public static class RecordTypesTopic
{
    public static void Run()
    {
        var person = new Person("Anna", "Müller");
        var updatedPerson = person with { LastName = "Schmidt" };

        Console.WriteLine($"Original: {person}");
        Console.WriteLine($"Kopie mit \"with\": {updatedPerson}");

        Console.WriteLine();
        Console.WriteLine("Wertbasierter Vergleich:");
        Console.WriteLine($"person == updatedPerson -> {person == updatedPerson}");
        var copy = person with { };
        Console.WriteLine($"person == person with {{ }} -> {person == copy}");

        var address = new Address("Hauptstraße 5", "Berlin");
        Console.WriteLine();
        Console.WriteLine($"Adresse mit Standardwert: {address}");
    }
}
