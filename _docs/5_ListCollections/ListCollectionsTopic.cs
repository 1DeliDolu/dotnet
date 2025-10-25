using System;
using System.Collections.Generic;

namespace D5_ListCollectionsNamespace;

public static class ListCollectionsTopic
{
    public static void Run()
    {
        var names = new List<string> { "Deniz", "Ana", "Felipe" };

        ShowBasicList(names);
        ShowModifyList(names);
        ShowIndexAndCount(names);
        ShowSearchAndSort(names);
        ShowFibonacciSequence();
    }

    private static void ShowBasicList(List<string> names)
    {
        Console.WriteLine("List<T> ile temel örnek:");
        foreach (var name in names)
        {
            Console.WriteLine($"Hello {name.ToUpper()}!");
        }

        Console.WriteLine();
    }

    private static void ShowModifyList(List<string> names)
    {
        Console.WriteLine("Listeyi büyütüp küçültme:");

        Console.WriteLine("Başlangıç durumu:");
        PrintNames(names);

        names.Add("Maria");
        names.Add("Bill");
        names.Remove("Ana");

        Console.WriteLine("\nGüncel liste:");
        PrintNames(names);
        Console.WriteLine();
    }

    private static void ShowIndexAndCount(List<string> names)
    {
        Console.WriteLine("Indeks ve Count kullanımı:");
        Console.WriteLine($"Benim adım {names[0]}.");
        Console.WriteLine($"Listeye {names[2]} ve {names[3]} eklendi.");
        Console.WriteLine($"Toplam kişi sayısı: {names.Count}");
        Console.WriteLine();
    }

    private static void ShowSearchAndSort(List<string> names)
    {
        Console.WriteLine("IndexOf ve Sort örnekleri:");

        var index = names.IndexOf("Felipe");
        if (index == -1)
        {
            Console.WriteLine("Felipe bulunamadı.");
        }
        else
        {
            Console.WriteLine($"{names[index]} indeksi {index}.");
        }

        index = names.IndexOf("Not Found");
        if (index == -1)
        {
            Console.WriteLine($"Aranan öğe yoksa IndexOf {index} döner.");
        }

        names.Sort();
        Console.WriteLine("Sıralanmış liste:");
        PrintNames(names);
        Console.WriteLine();
    }

    private static void ShowFibonacciSequence()
    {
        Console.WriteLine("Fibonacci sayıları:");
        var fibonacciNumbers = new List<int> { 1, 1 };

        while (fibonacciNumbers.Count < 20)
        {
            var count = fibonacciNumbers.Count;
            var next = fibonacciNumbers[count - 1] + fibonacciNumbers[count - 2];
            fibonacciNumbers.Add(next);
        }

        Console.WriteLine(string.Join(", ", fibonacciNumbers));
        Console.WriteLine($"20. sayı: {fibonacciNumbers[19]}");
        Console.WriteLine();
    }

    private static void PrintNames(IEnumerable<string> names)
    {
        foreach (var name in names)
        {
            Console.WriteLine($"Hello {name.ToUpper()}!");
        }
    }
}
