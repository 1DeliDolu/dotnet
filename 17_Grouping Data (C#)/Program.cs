using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQGroupingExample
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
            // 🔹 Öğrenci veri kaynağı
            List<Student> students = new()
            {
                new Student { FirstName = "Ali", LastName = "Demir", ID = 1, Year = GradeLevel.FirstYear,  Scores = new() { 90, 80, 70 }, DepartmentID = 1 },
                new Student { FirstName = "Ayşe", LastName = "Yılmaz", ID = 2, Year = GradeLevel.SecondYear, Scores = new() { 60, 75, 80 }, DepartmentID = 1 },
                new Student { FirstName = "Mehmet", LastName = "Kaya", ID = 3, Year = GradeLevel.ThirdYear, Scores = new() { 95, 85, 88 }, DepartmentID = 2 },
                new Student { FirstName = "Zeynep", LastName = "Koç", ID = 4, Year = GradeLevel.FourthYear, Scores = new() { 40, 50, 55 }, DepartmentID = 3 },
                new Student { FirstName = "Can", LastName = "Demir", ID = 5, Year = GradeLevel.FirstYear, Scores = new() { 70, 65, 60 }, DepartmentID = 2 },
                new Student { FirstName = "Elif", LastName = "Kaya", ID = 6, Year = GradeLevel.SecondYear, Scores = new() { 85, 90, 95 }, DepartmentID = 3 },
            };

            // 🔸 1. Tek Özelliğe Göre Gruplama (Year)
            var groupByYear = from s in students
                              group s by s.Year into g
                              orderby g.Key
                              select g;

            Console.WriteLine("📘 1️⃣ Yıla Göre Gruplama:");
            foreach (var group in groupByYear)
            {
                Console.WriteLine($"\nYıl: {group.Key}");
                foreach (var s in group)
                    Console.WriteLine($"  {s.FirstName} {s.LastName}");
            }

            // 🔸 2. Soyadın İlk Harfine Göre Gruplama
            var groupByFirstLetter = students.GroupBy(s => s.LastName[0]);
            Console.WriteLine("\n📗 2️⃣ Soyadın İlk Harfine Göre Gruplama:");
            foreach (var group in groupByFirstLetter)
            {
                Console.WriteLine($"\nHarf: {group.Key}");
                foreach (var s in group)
                    Console.WriteLine($"  {s.LastName}, {s.FirstName}");
            }

            // 🔸 3. Ortalama Not Aralığına Göre Gruplama
            var groupByScoreRange = from s in students
                                    let avg = s.Scores.Average()
                                    let range = (int)avg / 10
                                    group new { s.FirstName, s.LastName, Avg = avg } by range into g
                                    orderby g.Key
                                    select g;

            Console.WriteLine("\n📙 3️⃣ Not Aralığına Göre Gruplama (Yüzdelik):");
            foreach (var g in groupByScoreRange)
            {
                Console.WriteLine($"\nAralık: {g.Key * 10}-{(g.Key + 1) * 10}");
                foreach (var s in g)
                    Console.WriteLine($"  {s.FirstName} {s.LastName} → Ortalama: {s.Avg:F1}");
            }

            // 🔸 4. 75 Üstü Ortalama Olanlara Göre Gruplama
            var groupByHighAverage = students
                .GroupBy(s => s.Scores.Average() > 75);

            Console.WriteLine("\n📒 4️⃣ Ortalama 75 Üstü Olanlar:");
            foreach (var group in groupByHighAverage)
            {
                Console.WriteLine($"\nGrup: {(group.Key ? "75 Üstü" : "75 Altı")}");
                foreach (var s in group)
                    Console.WriteLine($"  {s.FirstName} {s.LastName} (Ort: {s.Scores.Average():F1})");
            }

            // 🔸 5. Bileşik Anahtar (Soyadın İlk Harfi + İlk Not > 85)
            var groupByCompoundKey = students.GroupBy(s => new
            {
                FirstLetter = s.LastName[0],
                IsScoreOver85 = s.Scores[0] > 85
            });

            Console.WriteLine("\n📔 5️⃣ Bileşik Anahtara Göre Gruplama:");
            foreach (var g in groupByCompoundKey)
            {
                var durum = g.Key.IsScoreOver85 ? "85 Üstü" : "85 Altı";
                Console.WriteLine($"\nSoyadı {g.Key.FirstLetter} ile başlayan ve ilk notu {durum} olanlar:");
                foreach (var s in g)
                    Console.WriteLine($"  {s.FirstName} {s.LastName}");
            }

            // 🔸 6. İç İçe Gruplama (Yıla göre ve ardından soyadına göre)
            var nestedGroups = from s in students
                               group s by s.Year into yearGroup
                               from innerGroup in
                                   from s2 in yearGroup
                                   group s2 by s2.LastName
                               group innerGroup by yearGroup.Key;

            Console.WriteLine("\n📕 6️⃣ İç İçe Gruplama (Yıl → Soyadı):");
            foreach (var outer in nestedGroups)
            {
                Console.WriteLine($"\nYıl: {outer.Key}");
                foreach (var inner in outer)
                {
                    Console.WriteLine($"  Soyadı: {inner.Key}");
                    foreach (var s in inner)
                        Console.WriteLine($"    {s.FirstName} {s.LastName}");
                }
            }

            // 🔸 7. Her Yılın En Yüksek Ortalama Notu
            var queryGroupMax = students
                .GroupBy(s => s.Year)
                .Select(g => new
                {
                    Level = g.Key,
                    HighestScore = g.Max(s => s.Scores.Average())
                });

            Console.WriteLine("\n📚 7️⃣ Her Yılın En Yüksek Ortalama Notu:");
            foreach (var item in queryGroupMax)
                Console.WriteLine($"  {item.Level}: {item.HighestScore:F1}");
        }
    }
}
