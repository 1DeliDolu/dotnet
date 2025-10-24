namespace LibraryApp.Modelle;

/// <summary>
/// Modellklasse für ein Buch in der Bibliothek.
/// Erbt von Basismodell.
/// </summary>
public class Buch : Basismodell
{
    private string _titel = string.Empty;

    public string Titel
    {
        get => _titel;
        set => _titel = value?.Trim() ?? string.Empty;
    }

    public string Autor { get; set; } = string.Empty;
    public int Erscheinungsjahr { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string BildPfad { get; set; } = string.Empty;
}
