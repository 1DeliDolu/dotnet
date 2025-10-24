# SCHRITT 10 – ISBN- und Bildunterstützung ergänzt

In diesem Schritt wurde das Buchmodell erweitert und die Oberfläche um eine Bildanzeige ergänzt.

Umsetzungen:
- `Buch` besitzt nun die Eigenschaften `ISBN` und `BildPfad`.
- `BuchSteuerung.BuchHinzufuegen(...)` akzeptiert ISBN sowie den Pfad zum ausgewählten Bild.
- Das Hauptfenster bietet zusätzliche Eingabefelder, einen Button zum Auswählen einer Bilddatei und eine PictureBox, die das Cover darstellt.
- Beim Markieren eines Eintrags in der DataGridView wird das gespeicherte Bild geladen, sofern der Pfad gültig ist.

Damit lassen sich Bücher inklusive ISBN erfassen und optisch ansprechend darstellen.
