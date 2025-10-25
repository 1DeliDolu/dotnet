# 1. Record-Typen in C#

Dieses Kapitel legt den Grundstein für unsere einfache .NET-Anwendung und zeigt, wie Record-Typen funktionieren. Records sind unveränderliche Referenztypen, die standardmäßig Wertgleichheit, Dekonstruktion und das `with`-Ausdrucksfeature unterstützen.

## Warum Records?
- Kürzere, ausdrucksstarke Syntax für Datenobjekte
- Automatische Implementierung von `Equals`, `GetHashCode` und `ToString`
- Mit dem `with`-Ausdruck lassen sich Varianten eines Objekts erstellen, ohne das Original zu verändern

## Beispielcode
Der Ordner enthält eine kleine Konsolenanwendung (`RecordTypes.csproj` und `Program.cs`). Sie definiert die Records `Person` und `Address` und demonstriert:
- Positional Records (`Person`)
- Zusätzliche Eigenschaften mit Standardwert (`Address.Country`)
- Kopieren und Modifizieren mittels `with`
- Wertvergleich (`==`) gegenüber Referenzvergleich

```bash
dotnet run --project Readme/1_RecordTypes/RecordTypes.csproj
```

### Erwartete Ausgabe (gekürzt)
```text
Original: Person { FirstName = Anna, LastName = Müller }
Kopie mit "with": Person { FirstName = Anna, LastName = Schmidt }

Wertbasierter Vergleich:
person == updatedPerson -> False
person == person with { } -> True

Adresse mit Standardwert: Address { Street = Hauptstraße 5, City = Berlin, Country = Deutschland }
```

> Tipp: Passen Sie die Records an (z. B. weitere Eigenschaften oder Methoden), um die Vorteile unveränderlicher Objekte weiter zu erkunden.
