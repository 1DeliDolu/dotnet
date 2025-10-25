using System;
using System.Globalization;
using System.Text;

namespace D2_StringVeTextNamespace;

public static class StringVeTextTopic
{
    public static void Run()
    {
        ShowStringInterpolation();
        ShowTextNormalization();
        ShowSearchAndReplace();
        ShowNumberFormatting();
        ShowStringBuilderUsage();
        ShowSpanSlicing();
    }

    private static void ShowStringInterpolation()
    {
        var name = "Ada";
        var visits = 3;
        var greeting = $"Merhaba, {name}! Bugün {visits} kez uğradın.";

        Console.WriteLine("Interpolasyon ve temel işlemler:");
        Console.WriteLine(greeting);
        Console.WriteLine($"Uzunluk: {greeting.Length}");
        Console.WriteLine($"Büyük harf: {greeting.ToUpperInvariant()}");

        var ingredients = new[] { "un", "su", "tuz" };
        var list = string.Join(", ", ingredients);
        Console.WriteLine("Listeleme: " + list);

        Console.WriteLine();
    }

    private static void ShowTextNormalization()
    {
        var sentence = "  .NET   ile  metin  işleri kolay!  ";
        var parts = sentence
            .Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        Console.WriteLine("Normalleştirilmiş kelimeler:");
        foreach (var part in parts)
        {
            Console.WriteLine($"- {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(part)}");
        }

        Console.WriteLine();
    }

    private static void ShowSearchAndReplace()
    {
        const string article = "C# stringleri ile metin işlemek esnektir.";
        const string term = "STRINGLERI";

        Console.WriteLine("Arama ve değiştirme:");
        Console.WriteLine(article);
        Console.WriteLine($"\"{term}\" kelimesi var mı? {article.Contains(term, StringComparison.OrdinalIgnoreCase)}");

        var capitalized = article.ToUpper(CultureInfo.GetCultureInfo("tr-TR"));
        Console.WriteLine($"Büyük harf (tr-TR): {capitalized}");

        var replaced = article.Replace("metin", "text", StringComparison.OrdinalIgnoreCase);
        Console.WriteLine("Değiştirilmiş hali: " + replaced);

        var words = article.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Kelime sayısı: " + words.Length);
        Console.WriteLine();
    }

    private static void ShowNumberFormatting()
    {
        const int a = 18;
        const int b = 6;
        var sum = a + b;
        var quotient = a / b;
        var remainder = a % b;

        Console.WriteLine("Sayısal değerleri yazıya dökme:");
        Console.WriteLine($"{a} + {b} = {sum}");
        Console.WriteLine($"{a} / {b} = {quotient} kalan {remainder}");

        var max = int.MaxValue;
        var overflow = max + 3;
        Console.WriteLine($"int aralığı: {int.MinValue:N0} ile {max:N0}");
        Console.WriteLine($"Taşma örneği: {overflow}");

        var third = 1.0 / 3.0;
        Console.WriteLine($"1/3 ≈ {third:F4} ({third:P1})");

        var price = 129.99m;
        var turkishCulture = CultureInfo.GetCultureInfo("tr-TR");
        Console.WriteLine($"Fiyat (tr-TR): {price.ToString("C2", turkishCulture)}");
        Console.WriteLine();
    }

    private static void ShowStringBuilderUsage()
    {
        var report = new StringBuilder();
        report.AppendLine("Rapor içeriği:");
        report.Append("- Oluşturuldu: ");
        report.AppendLine(DateTime.Now.ToString("u", CultureInfo.InvariantCulture));
        report.AppendLine("- Öğeler:");

        var items = new[] { "Birinci satır", "İkinci satır", "Üçüncü satır" };
        foreach (var item in items)
        {
            report.AppendLine("  * " + item);
        }

        Console.WriteLine("StringBuilder ile birleştirme:");
        Console.WriteLine(report.ToString());
    }

    private static void ShowSpanSlicing()
    {
        var iban = "TR93000670100000000003216";
        ReadOnlySpan<char> country = iban.AsSpan(0, 2);
        ReadOnlySpan<char> controlDigits = iban.AsSpan(2, 2);
        ReadOnlySpan<char> bankCode = iban.AsSpan(4, 4);

        Console.WriteLine("Span ile parçalama:");
        Console.WriteLine($"Ülke: {country.ToString()}");
        Console.WriteLine($"Kontrol: {controlDigits.ToString()}");
        Console.WriteLine($"Banka kodu: {bankCode.ToString()}");
        Console.WriteLine();
    }
}
