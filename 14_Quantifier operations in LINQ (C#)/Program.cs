using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<int> Scores { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new()
        {
            new Student { FirstName = "Cesar", LastName = "Garcia", Scores = new List<int>{ 71, 86, 77, 97 } },
            new Student { FirstName = "Nancy", LastName = "Engström", Scores = new List<int>{ 75, 73, 78, 83 } },
            new Student { FirstName = "Claire", LastName = "O'Donnell", Scores = new List<int>{ 56, 78, 95, 95 } },
            new Student { FirstName = "Donald", LastName = "Urquhart", Scores = new List<int>{ 92, 90, 95, 57 } },
            new Student { FirstName = "Ifeanacho", LastName = "Jamuike", Scores = new List<int>{ 98, 92, 88, 79 } }
        };

        Console.WriteLine("🔹 All() örneği: (Tüm notları 70'ten büyük olan öğrenciler)");
        var allAbove70 = from s in students
                         where s.Scores.All(score => score > 70)
                         select $"{s.FirstName} {s.LastName}";
        foreach (var name in allAbove70)
            Console.WriteLine(name);

        Console.WriteLine("\n🔹 Any() örneği: (Herhangi bir notu 95'ten büyük olan öğrenciler)");
        var anyAbove95 = from s in students
                         where s.Scores.Any(score => score > 95)
                         select $"{s.FirstName} {s.LastName}";
        foreach (var name in anyAbove95)
            Console.WriteLine(name);

        Console.WriteLine("\n🔹 Contains() örneği: (Tam olarak 95 alan öğrenciler)");
        var has95 = from s in students
                    where s.Scores.Contains(95)
                    select $"{s.FirstName} {s.LastName}";
        foreach (var name in has95)
            Console.WriteLine(name);
    }
}
