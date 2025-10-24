using System;
using System.Collections.Generic;
using D1_RecordTypesNamespace;

namespace DotnetPlayground;

internal static class Program
{
    private static readonly IReadOnlyList<(string Key, string Title, Action Run)> Topics =
        new List<(string Key, string Title, Action Run)>
        {
            ("1", "Record Types", RecordTypesTopic.Run)
        };

    private static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            ExecuteTopic(args[0]);
            return;
        }

        ShowMenu();
        var selection = Console.ReadLine()?.Trim() ?? string.Empty;
        if (string.Equals(selection, "q", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        ExecuteTopic(selection);
    }

    private static void ShowMenu()
    {
        Console.WriteLine("=== .NET Konu Demoları ===");
        foreach (var (key, title, _) in Topics)
        {
            Console.WriteLine($"{key}. {title}");
        }

        Console.WriteLine();
        Console.Write("Çalıştırmak istediğiniz konunun numarasını girin (çıkmak için Q): ");
    }

    private static void ExecuteTopic(string key)
    {
        foreach (var (topicKey, title, run) in Topics)
        {
            if (!string.Equals(topicKey, key, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            Console.WriteLine();
            Console.WriteLine($"--- {topicKey}. {title} ---");
            run();
            return;
        }

        Console.WriteLine("Geçersiz seçim. Menüden bir numara seçin.");
    }
}
