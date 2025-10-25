using System;
using System.Collections.Generic;
using System.Linq;

// 🔹 Öğrenci, öğretmen ve departman sınıfları
public enum GradeLevel
{
    FirstYear = 1,
    SecondYear,
    ThirdYear,
    FourthYear
};

public class Student
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required int ID { get; init; }
    public required GradeLevel Year { get; init; }
    public required List<int> Scores { get; init; }
    public required int DepartmentID { get; init; }
}

public class Teacher
{
    public required string First { get; init; }
    public required string Last { get; init; }
    public required int ID { get; init; }
    public required string City { get; init; }
}

public class Department
{
    public required string Name { get; init; }
    public int ID { get; init; }
    public required int TeacherID { get; init; }
}

class Program
{
    static void Main()
    {
        // 🔸 Örnek veri kümesi
        var teachers = new List<Teacher>
        {
            new() { First = "Ali", Last = "Kaya", ID = 901, City = "Ankara" },
            new() { First = "Ayşe", Last = "Demir", ID = 965, City = "İzmir" },
            new() { First = "Fatma", Last = "Yılmaz", ID = 932, City = "İstanbul" },
            new() { First = "Mehmet", Last = "Çelik", ID = 945, City = "Bursa" },
            new() { First = "Ahmet", Last = "Koç", ID = 987, City = "Ankara" },
            new() { First = "Zeynep", Last = "Arslan", ID = 910, City = "Bursa" }
        };

        Console.WriteLine("============================================");
        Console.WriteLine("🔹 1. OrderBy — Artan sırada sıralama");
        Console.WriteLine("============================================");

        var ascending = teachers
            .OrderBy(t => t.Last)
            .Select(t => $"{t.First} {t.Last}");

        foreach (var name in ascending)
            Console.WriteLine(name);

        Console.WriteLine("\n============================================");
        Console.WriteLine("🔹 2. OrderByDescending — Azalan sırada sıralama");
        Console.WriteLine("============================================");

        var descending = teachers
            .OrderByDescending(t => t.Last)
            .Select(t => $"{t.First} {t.Last}");

        foreach (var name in descending)
            Console.WriteLine(name);

        Console.WriteLine("\n============================================");
        Console.WriteLine("🔹 3. ThenBy — Birincil ve ikincil artan sıralama");
        Console.WriteLine("============================================");

        var thenBy = teachers
            .OrderBy(t => t.City)        // Birincil: Şehir
            .ThenBy(t => t.Last)         // İkincil: Soyadı
            .Select(t => new { t.City, t.Last, t.First });

        foreach (var item in thenBy)
            Console.WriteLine($"City: {item.City,-10} | Last: {item.Last,-10} | First: {item.First}");

        Console.WriteLine("\n============================================");
        Console.WriteLine("🔹 4. ThenByDescending — İkincil azalan sıralama");
        Console.WriteLine("============================================");

        var thenByDesc = teachers
            .OrderBy(t => t.City)             // Birincil: Şehir (artan)
            .ThenByDescending(t => t.Last)    // İkincil: Soyadı (azalan)
            .Select(t => new { t.City, t.Last, t.First });

        foreach (var item in thenByDesc)
            Console.WriteLine($"City: {item.City,-10} | Last: {item.Last,-10} | First: {item.First}");

        Console.WriteLine("\n============================================");
        Console.WriteLine("🔹 5. Reverse — Sıralamayı tersine çevir");
        Console.WriteLine("============================================");

        var reversed = teachers
            .Select(t => $"{t.First} {t.Last}")
            .Reverse();

        foreach (var name in reversed)
            Console.WriteLine(name);

        Console.WriteLine("\n============================================");
        Console.WriteLine("✅ Tüm sıralama işlemleri başarıyla tamamlandı!");
        Console.WriteLine("============================================");
    }
}
