using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqTypeConversionDemo
{
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

    class Program
    {
        static void Main()
        {
            // 🎓 Öğrenci listesi
            List<Student> students = new()
            {
                new Student { FirstName = "Ali", LastName = "Yılmaz", ID = 1, Year = GradeLevel.FirstYear, Scores = new() { 75, 80, 90 }, DepartmentID = 1 },
                new Student { FirstName = "Ayşe", LastName = "Demir", ID = 2, Year = GradeLevel.SecondYear, Scores = new() { 65, 70, 60 }, DepartmentID = 2 },
                new Student { FirstName = "Can", LastName = "Kaya", ID = 3, Year = GradeLevel.ThirdYear, Scores = new() { 95, 92, 88 }, DepartmentID = 1 },
                new Student { FirstName = "Elif", LastName = "Öztürk", ID = 4, Year = GradeLevel.FourthYear, Scores = new() { 55, 60, 58 }, DepartmentID = 3 }
            };

            // 🔹 1. AsEnumerable – Koleksiyonu IEnumerable olarak döndürür
            var enumerableStudents = students.AsEnumerable();
            Console.WriteLine("AsEnumerable:");
            foreach (var s in enumerableStudents)
                Console.WriteLine($"- {s.FirstName} ({s.Year})");
            Console.WriteLine();

            // 🔹 2. Cast – Koleksiyonu belirli bir tipe dönüştürür
            IEnumerable people = students;
            var casted = people.Cast<Student>().Where(s => s.Year == GradeLevel.ThirdYear);
            Console.WriteLine("Cast<Student> (3. sınıf öğrencileri):");
            foreach (var s in casted)
                Console.WriteLine($"- {s.FirstName}");
            Console.WriteLine();

            // 🔹 3. OfType – Belirli türe dönüştürülebilenleri seçer
            ArrayList mixedList = new() { 1, "merhaba", 3.14, "dünya", 42 };
            var strings = mixedList.OfType<string>();
            Console.WriteLine("OfType<string> sonucu:");
            foreach (var str in strings)
                Console.WriteLine($"- {str}");
            Console.WriteLine();

            // 🔹 4. ToList – Sorguyu hemen yürütür ve listeye dönüştürür
            var listResult = students
                .Where(s => s.Scores.Average() > 70)
                .ToList();
            Console.WriteLine("ToList() – Ortalaması 70'ten büyük öğrenciler:");
            foreach (var s in listResult)
                Console.WriteLine($"- {s.FirstName} ({s.Scores.Average():F1})");
            Console.WriteLine();

            // 🔹 5. ToArray – Sorguyu yürütür ve diziye dönüştürür
            var arrayResult = students
                .Select(s => s.FirstName)
                .ToArray();
            Console.WriteLine("ToArray() sonucu:");
            foreach (var name in arrayResult)
                Console.WriteLine($"- {name}");
            Console.WriteLine();

            // 🔹 6. ToDictionary – Anahtar-Değer koleksiyonu oluşturur
            var dict = students.ToDictionary(s => s.ID, s => s.FirstName);
            Console.WriteLine("ToDictionary() sonucu:");
            foreach (var kvp in dict)
                Console.WriteLine($"ID: {kvp.Key}, İsim: {kvp.Value}");
            Console.WriteLine();

            // 🔹 7. ToLookup – Anahtar başına birden fazla değer eşlemesi
            var lookup = students.ToLookup(s => s.DepartmentID, s => s.FirstName);
            Console.WriteLine("ToLookup() sonucu:");
            foreach (var group in lookup)
            {
                Console.WriteLine($"Bölüm {group.Key}:");
                foreach (var name in group)
                    Console.WriteLine($"  - {name}");
            }
            Console.WriteLine();

            // 🔹 8. AsQueryable – Koleksiyonu IQueryable'a dönüştürür
            var queryable = students.AsQueryable().Where(s => s.Year == GradeLevel.SecondYear);
            Console.WriteLine("AsQueryable() (2. sınıf öğrencileri):");
            foreach (var s in queryable)
                Console.WriteLine($"- {s.FirstName}");
        }
    }
}
