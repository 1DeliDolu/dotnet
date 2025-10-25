using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string Department { get; set; } = "";
}

class Program
{
    static void Main()
    {
        List<Student> students = new()
        {
            new Student { ID = 1, Name = "Ali", Age = 21, Department = "Bilgisayar" },
            new Student { ID = 2, Name = "Ayşe", Age = 19, Department = "Elektrik" },
            new Student { ID = 3, Name = "Can", Age = 22, Department = "Bilgisayar" },
            new Student { ID = 4, Name = "Deniz", Age = 20, Department = "Makine" },
            new Student { ID = 5, Name = "Elif", Age = 23, Department = "Bilgisayar" }
        };

        // 1️⃣ Filtreleme
        var result = from s in students
                     where s.Age > 20
                     select s;
        Console.WriteLine("20 yaşından büyük öğrenciler:");
        foreach (var student in result)
            Console.WriteLine($"{student.Name} - {student.Age}");

        // 2️⃣ Sıralama
        var sorted = from s in students
                     orderby s.Age ascending
                     select s;
        Console.WriteLine("\nYaşa göre sıralama:");
        foreach (var s in sorted)
            Console.WriteLine($"{s.Name} - {s.Age}");

        // 3️⃣ Seçim
        var names = from s in students
                    select new { s.Name, s.Department };
        Console.WriteLine("\nAd ve Bölüm:");
        foreach (var n in names)
            Console.WriteLine($"{n.Name} ({n.Department})");

        // 4️⃣ Gruplama
        var groups = from s in students
                     group s by s.Department into deptGroup
                     select new
                     {
                         Department = deptGroup.Key,
                         Count = deptGroup.Count(),
                         Students = deptGroup
                     };
        Console.WriteLine("\nBölümlere göre gruplama:");
        foreach (var g in groups)
        {
            Console.WriteLine($"📘 {g.Department} Bölümü - {g.Count} Öğrenci");
            foreach (var stu in g.Students)
                Console.WriteLine($"  {stu.Name}");
        }
    }
}
