using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    // Simple record type for sample data
    record Book(string Title, string Author, int Year, int Pages);

    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new("C# in Depth", "Jon Skeet", 2019, 900),
                new("Pro LINQ", "Joseph Rattz", 2010, 420),
                new("Effective C#", "Bill Wagner", 2017, 300),
                new("Language Integrated Query", "Fabian Pascal", 2015, 250),
                new("Modern C#", "Jane Doe", 2021, 380),
                new("Old C# Book", "John Smith", 2005, 200)
            };

            // Query syntax: filter and order
            var recentBooks =
                from b in books
                where b.Year >= 2015
                orderby b.Year descending, b.Title
                select b;

            Console.WriteLine("Recent books (query syntax):");
            foreach (var b in recentBooks)
                Console.WriteLine($"{b.Year}: {b.Title} by {b.Author}");

            Console.WriteLine();

            // Method syntax: projection and Distinct
            var authors = books
                .Where(b => b.Pages >= 300)
                .Select(b => b.Author)
                .Distinct()
                .OrderBy(a => a);

            Console.WriteLine("Authors with books >= 300 pages (method syntax):");
            foreach (var a in authors)
                Console.WriteLine(a);

            Console.WriteLine();

            // Grouping and aggregation
            var byAuthor = books
                .GroupBy(b => b.Author)
                .Select(g => new { Author = g.Key, Count = g.Count(), AvgPages = g.Average(b => b.Pages) })
                .OrderByDescending(x => x.Count);

            Console.WriteLine("Books grouped by author:");
            foreach (var g in byAuthor)
                Console.WriteLine($"{g.Author}: {g.Count} book(s), avg pages {g.AvgPages:F0}");

            Console.WriteLine();

            // Example of chaining and deferred execution
            var longTitles = books
                .Select(b => new { b.Title, Length = b.Title.Length })
                .Where(x => x.Length > 10);

            Console.WriteLine("Titles longer than 10 characters:");
            foreach (var t in longTitles)
                Console.WriteLine($"{t.Title} ({t.Length})");
        }
    }
}