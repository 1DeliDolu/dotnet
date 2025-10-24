using System;

namespace D3_NumericTypesNamespace;

public static class NumericTypesTopic
{
    public static void Run()
    {
        ShowIntegerMath();
        ShowOrderOfOperations();
        ShowRemainderAndLimits();
        ShowDoubleMath();
    }

    private static void ShowIntegerMath()
    {
        const int a = 18;
        const int b = 6;

        Console.WriteLine("Tam sayılarla temel işlemler:");
        Console.WriteLine($"{a} + {b} = {a + b}");
        Console.WriteLine($"{a} - {b} = {a - b}");
        Console.WriteLine($"{a} * {b} = {a * b}");
        Console.WriteLine($"{a} / {b} = {a / b}");
        Console.WriteLine();
    }

    private static void ShowOrderOfOperations()
    {
        const int a = 5;
        const int b = 4;
        const int c = 2;

        var d = a + b * c;
        Console.WriteLine("İşlem önceliği:");
        Console.WriteLine($"a + b * c = {d}");

        d = (a + b) * c;
        Console.WriteLine($"(a + b) * c = {d}");

        d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
        Console.WriteLine($"Karma örnek: {d}");
        Console.WriteLine();
    }

    private static void ShowRemainderAndLimits()
    {
        const int a = 7;
        const int b = 4;
        const int c = 3;

        var quotient = (a + b) / c;
        var remainder = (a + b) % c;

        Console.WriteLine("Bölme sonuçları:");
        Console.WriteLine($"Bölüm: {quotient}");
        Console.WriteLine($"Kalan: {remainder}");

        var max = int.MaxValue;
        var min = int.MinValue;
        Console.WriteLine($"int aralığı {min} ile {max}");

        var overflow = max + 3;
        Console.WriteLine($"Taşma örneği (max + 3): {overflow}");
        Console.WriteLine();
    }

    private static void ShowDoubleMath()
    {
        const double a = 19;
        const double b = 23;
        const double c = 8;

        var result = (a + b) / c;
        Console.WriteLine("double ile çalışma:");
        Console.WriteLine($"(19 + 23) / 8 = {result}");

        var rangeMin = double.MinValue;
        var rangeMax = double.MaxValue;
        Console.WriteLine($"double aralığı {rangeMin} ile {rangeMax}");

        var third = 1.0 / 3.0;
        Console.WriteLine($"1/3 ≈ {third}");
        Console.WriteLine();
    }
}
