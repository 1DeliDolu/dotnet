using System.Collections.Generic;
using LibraryApp.Daten;
using LibraryApp.Modelle;

namespace LibraryApp.Steuerung;

/// <summary>
/// Steuerungsklasse, die zwischen der Benutzeroberfläche (View)
/// und dem Datenspeicher (Repository) vermittelt.
/// </summary>
public class BuchSteuerung
{
    private readonly BuchSpeicher speicher = new();

    public List<Buch> BuecherListe() => speicher.AlleBuecher();

    public List<Buch> Suche(string suchwort)
    {
        string kriterium = suchwort?.Trim().ToLower() ?? string.Empty;

        if (string.IsNullOrEmpty(kriterium))
        {
            return new List<Buch>(BuecherListe());
        }

        return BuecherListe().FindAll(b =>
            b.Titel.ToLower().Contains(kriterium) ||
            b.Autor.ToLower().Contains(kriterium));
    }

    public void BuchHinzufuegen(string titel, string autor, int jahr, string isbn, string bildPfad)
    {
        Buch neuesBuch = new()
        {
            Id = BuecherListe().Count + 1,
            Titel = titel,
            Autor = autor,
            Erscheinungsjahr = jahr,
            ISBN = isbn,
            BildPfad = bildPfad
        };

        speicher.Hinzufuegen(neuesBuch);
    }

    public void BuchEntfernen(Buch buch) => speicher.Entfernen(buch);
}
