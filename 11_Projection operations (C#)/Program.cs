using System;
using System.Collections.Generic;
using System.Linq;

class Bouquet
{
    public required List<string> Flowers { get; init; }
}

class Program
{
    static void Main()
    {
        // 🔹 1. SELECT – Basit projeksiyon
        List<string> words = ["an", "apple", "a", "day"];
        var selectQuery = words.Select(word => word.Substring(0, 1));

        Console.WriteLine("=== SELECT ===");
        foreach (var s in selectQuery)
            Console.WriteLine(s);

        // 🔹 2. SELECTMANY – Alt dizileri düzleştirme
        List<string> phrases = ["an apple a day", "the quick brown fox"];
        var selectManyQuery = phrases.SelectMany(phrase => phrase.Split(' '));

        Console.WriteLine("\n=== SELECTMANY ===");
        foreach (var s in selectManyQuery)
            Console.WriteLine(s);

        // 🔹 3. ZIP – Koleksiyonları eşleştirme
        IEnumerable<int> numbers = [1, 2, 3, 4, 5, 6, 7];
        IEnumerable<char> letters = ['A', 'B', 'C', 'D', 'E', 'F'];
        IEnumerable<string> emoji = ["🤓", "🔥", "🎉", "👀", "⭐", "💜", "✔", "💯"];

        var zipQuery = numbers.Zip(letters, emoji);

        Console.WriteLine("\n=== ZIP ===");
        foreach (var (number, letter, em) in zipQuery)
            Console.WriteLine($"Number: {number} - Letter: {letter} - Emoji: {em}");

        // 🔹 4. SELECT vs SELECTMANY – Farklı davranış
        List<Bouquet> bouquets =
        [
            new Bouquet { Flowers = ["sunflower", "daisy", "daffodil", "larkspur"] },
            new Bouquet { Flowers = ["tulip", "rose", "orchid"] },
            new Bouquet { Flowers = ["gladiolis", "lily", "snapdragon", "aster", "protea"] },
            new Bouquet { Flowers = ["larkspur", "lilac", "iris", "dahlia"] }
        ];

        var selectFlowers = bouquets.Select(bq => bq.Flowers);
        var selectManyFlowers = bouquets.SelectMany(bq => bq.Flowers);

        Console.WriteLine("\n=== SELECT vs SELECTMANY ===");
        Console.WriteLine("\n-- SELECT (koleksiyon koleksiyon içinde) --");
        foreach (var collection in selectFlowers)
        {
            foreach (var flower in collection)
                Console.WriteLine(flower);
        }

        Console.WriteLine("\n-- SELECTMANY (tekleştirilmiş liste) --");
        foreach (var flower in selectManyFlowers)
            Console.WriteLine(flower);
    }
}
