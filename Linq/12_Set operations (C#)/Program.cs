using System;
using System.Collections.Generic;
using System.Linq;

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
        // 🔹 Örnek veri kaynakları
        string[] words1 = { "the", "quick", "brown", "fox" };
        string[] words2 = { "jumped", "over", "the", "lazy", "dog" };

        var teachers = new List<Teacher>
        {
            new() { First = "Ali", Last = "Kaya", ID = 901, City = "Ankara" },
            new() { First = "Ayşe", Last = "Demir", ID = 965, City = "İzmir" },
            new() { First = "Fatma", Last = "Yılmaz", ID = 932, City = "İstanbul" },
            new() { First = "Mehmet", Last = "Çelik", ID = 945, City = "Bursa" },
            new() { First = "Ahmet", Last = "Koç", ID = 987, City = "Antalya" }
        };

        var students = new List<Student>
        {
            new() { FirstName = "Ali", LastName = "Kaya", ID = 1, Year = GradeLevel.FirstYear, Scores = new List<int>{ 90 }, DepartmentID = 1 },
            new() { FirstName = "Ayşe", LastName = "Demir", ID = 2, Year = GradeLevel.SecondYear, Scores = new List<int>{ 80 }, DepartmentID = 2 },
            new() { FirstName = "Elif", LastName = "Koç", ID = 3, Year = GradeLevel.ThirdYear, Scores = new List<int>{ 85 }, DepartmentID = 3 },
            new() { FirstName = "Fatma", LastName = "Yılmaz", ID = 4, Year = GradeLevel.FourthYear, Scores = new List<int>{ 70 }, DepartmentID = 1 }
        };

        Console.WriteLine("=== 🔹 Distinct ===");
        foreach (var word in words1.Concat(words2).Distinct())
            Console.WriteLine(word);

        Console.WriteLine("\n=== 🔹 DistinctBy (Kelime uzunluğuna göre) ===");
        foreach (var word in words2.DistinctBy(w => w.Length))
            Console.WriteLine(word);

        Console.WriteLine("\n=== 🔹 Except ===");
        foreach (var word in words1.Except(words2))
            Console.WriteLine(word);

        Console.WriteLine("\n=== 🔹 Intersect ===");
        foreach (var word in words1.Intersect(words2))
            Console.WriteLine(word);

        Console.WriteLine("\n=== 🔹 Union ===");
        foreach (var word in words1.Union(words2))
            Console.WriteLine(word);

        Console.WriteLine("\n=== 🔹 ExceptBy (Öğretmen ID hariç tutma) ===");
        int[] teachersToExclude = { 901, 965, 932, 945, 987 }; // hariç tutulacak öğretmenler
        foreach (var teacher in teachers.ExceptBy(teachersToExclude, t => t.ID))
            Console.WriteLine($"{teacher.First} {teacher.Last}");

        Console.WriteLine("\n=== 🔹 IntersectBy (Öğrenci & Öğretmen isim eşleşmesi) ===");
        foreach (var student in students.IntersectBy(
            teachers.Select(t => (t.First, t.Last)),
            s => (s.FirstName, s.LastName)))
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }

        Console.WriteLine("\n=== 🔹 UnionBy (Öğrenci + Öğretmen isim birleştirme) ===");
        var allPeople = students
            .Select(s => (FirstName: s.FirstName, LastName: s.LastName))
            .UnionBy(
                teachers.Select(t => (FirstName: t.First, LastName: t.Last)),
                p => (p.FirstName, p.LastName));

        foreach (var person in allPeople)
            Console.WriteLine($"{person.FirstName} {person.LastName}");
    }
}
