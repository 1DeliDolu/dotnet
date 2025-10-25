using System;
using System.Globalization;

namespace D3_NumericTypesNamespace;

public static class NumericTypesTopic
{
    public static void Run()
    {
        ShowIntegerMath();
        ShowOrderOfOperations();
        ShowRemainderAndLimits();
        ShowDoubleMath();
        ShowDecimalPrecision();
        ShowMathHelpers();
        ShowCheckedOverflow();
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

    private static void ShowDecimalPrecision()
    {
        Console.WriteLine("double vs decimal hassasiyeti:");

        var doubleSum = 0.1 + 0.2;
        var decimalSum = 0.1m + 0.2m;
        Console.WriteLine($"double 0.1 + 0.2 = {doubleSum:R}");
        Console.WriteLine($"decimal 0.1 + 0.2 = {decimalSum}");

        const decimal price = 199.99m;
        const decimal taxRate = 0.18m;
        var decimalTotal = price + price * taxRate;
        var doubleTotal = (double)price + (double)price * 0.18;
        var culture = CultureInfo.GetCultureInfo("tr-TR");
        Console.WriteLine($"decimal toplam: {decimalTotal.ToString("C2", culture)}");
        Console.WriteLine($"double toplam : {doubleTotal.ToString("C2", culture)}");

        Console.WriteLine();
    }

    private static void ShowMathHelpers()
    {
        Console.WriteLine("Math yardımcıları:");

        const double radius = 4.5;
        var area = Math.PI * Math.Pow(radius, 2);
        var circumference = 2 * Math.PI * radius;
        Console.WriteLine($"Yarıçap {radius} → Alan: {area:F2}, Çevre: {circumference:F2}");

        var diagonal = Math.Sqrt(Math.Pow(16, 2) + Math.Pow(9, 2));
        Console.WriteLine($"16x9 dikdörtgenin köşegen uzunluğu ≈ {diagonal:F2}");

        var angleDegrees = 30d;
        var angleRadians = angleDegrees * Math.PI / 180d;
        Console.WriteLine($"sin({angleDegrees}°) = {Math.Sin(angleRadians):F3}");
        Console.WriteLine($"cos({angleDegrees}°) = {Math.Cos(angleRadians):F3}");

        var rounded = Math.Round(2.3456, 2, MidpointRounding.AwayFromZero);
        Console.WriteLine($"2.3456 → iki ondalık basamak: {rounded}");

        Console.WriteLine();
    }

    private static void ShowCheckedOverflow()
    {
        Console.WriteLine("Taşmayı yönetme (checked/unchecked):");

        var max = int.MaxValue;
        try
        {
            var overflow = checked(max + 1);
            Console.WriteLine($"checked sonucu: {overflow}");
        }
        catch (OverflowException)
        {
            Console.WriteLine("checked bloğu OverflowException fırlattı.");
        }

        unchecked
        {
            var wrap = max + 1;
            Console.WriteLine($"unchecked sonucu (wrap): {wrap}");
        }

        Console.WriteLine();
    }
}
