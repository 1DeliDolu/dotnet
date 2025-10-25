using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 🔹 Veri kaynağımız: bir sayı listesi
        List<int> numbers = new() { 5, 10, 8, 3, 6, 12, 1, 7, 2, 9 };

        // 🔸 1. Sorgu sözdizimiyle (Query Syntax)
        var evenNumbersQuery =
            from n in numbers
            where n % 2 == 0          // sadece çift sayılar
            orderby n ascending       // küçükten büyüğe sırala
            select n;

        Console.WriteLine("Sorgu Sözdizimi ile Çift Sayılar:");
        foreach (var num in evenNumbersQuery)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine("\n");

        // 🔸 2. Metot sözdizimiyle (Method Syntax)
        var evenNumbersMethod = numbers
            .Where(n => n % 2 == 0)
            .OrderBy(n => n)
            .Select(n => n);

        Console.WriteLine("Metot Sözdizimi ile Çift Sayılar:");
        foreach (var num in evenNumbersMethod)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine("\n");

        // 🔸 3. LINQ metodlarıyla ortalama hesaplama
        double average = numbers.Average();
        Console.WriteLine($"Tüm sayıların ortalaması: {average}");

        // 🔸 4. Şartlı sayım (Count)
        int greaterThanFive = numbers.Count(n => n > 5);
        Console.WriteLine($">5 olan sayı adedi: {greaterThanFive}");
    }
}
