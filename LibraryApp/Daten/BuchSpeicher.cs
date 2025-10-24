using System.Collections.Generic;
using LibraryApp.Modelle;

namespace LibraryApp.Daten;

/// <summary>
/// Verantwortlich für das Speichern und Verwalten von Büchern.
/// Arbeitet wie eine kleine Datenbank im Arbeitsspeicher.
/// </summary>
public class BuchSpeicher
{
    private readonly List<Buch> buecher = new();

    public List<Buch> AlleBuecher() => buecher;

    public void Hinzufuegen(Buch buch) => buecher.Add(buch);

    public void Entfernen(Buch buch) => buecher.Remove(buch);
}
