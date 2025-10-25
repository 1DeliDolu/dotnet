using System;
using System.Collections.Generic;
using System.Linq;

namespace WalkthroughWritingLinqQueries
{
    // 🧩 Öğrenci kayıt tipi
    public record Student(string First, string Last, int ID, int[] Scores);

    class Program
    {
        static void Main()
        {
            // 📚 1. Veri kaynağı oluştur
            IEnumerable<Student> students =
            [
                new Student("Svetlana", "Omelchenko", 111, [97, 92, 81, 60]),
                new Student("Claire", "O'Donnell", 112, [75, 84, 91, 39]),
                new Student("Sven", "Mortensen", 113, [88, 94, 65, 91]),
                new Student("Cesar", "Garcia", 114, [97, 89, 85, 82]),
                new Student("Debra", "Garcia", 115, [35, 72, 91, 70]),
                new Student("Fadi", "Fakhouri", 116, [99, 86, 90, 94]),
                new Student("Hanying", "Feng", 117, [93, 92, 80, 87]),
                new Student("Hugo", "Garcia", 118, [92, 90, 83, 78]),
                new Student("Lance", "Tucker", 119, [68, 79, 88, 92]),
                new Student("Terry", "Adams", 120, [99, 82, 81, 79]),
                new Student("Eugene", "Zabokritski", 121, [96, 85, 91, 60]),
                new Student("Michael", "Tucker", 122, [94, 92, 91, 91])
            ];

            // 🔍 2. İlk sınavı 90'dan yüksek olan öğrenciler
            var highScoreQuery =
                from student in students
                where student.Scores[0] > 90
                orderby student.Last
                select student;

            Console.WriteLine("🎯 İlk sınavı 90'dan yüksek olan öğrenciler:");
            foreach (var s in highScoreQuery)
                Console.WriteLine($"{s.Last}, {s.First} - İlk Sınav: {s.Scores[0]}");
            Console.WriteLine();

            // 🧱 3. Soyadın ilk harfine göre gruplama
            var groupQuery =
                from student in students
                group student by student.Last[0] into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            Console.WriteLine("📁 Soyadın ilk harfine göre gruplama:");
            foreach (var group in groupQuery)
            {
                Console.WriteLine($"Harf: {group.Key}");
                foreach (var s in group)
                    Console.WriteLine($"   {s.Last}, {s.First}");
            }
            Console.WriteLine();

            // 🧮 4. Her öğrencinin toplam notu
            var totalScores =
                from student in students
                let total = student.Scores.Sum()
                select total;

            double averageScore = totalScores.Average();
            Console.WriteLine($"📊 Sınıfın ortalama toplam puanı: {averageScore:F2}");
            Console.WriteLine();

            // 🎯 5. Ortalama üstü öğrenciler (Anonim Tip)
            var aboveAverageQuery =
                from student in students
                let total = student.Scores.Sum()
                where total > averageScore
                select new { student.ID, Total = total };

            Console.WriteLine("🏅 Ortalama üstü öğrenciler:");
            foreach (var s in aboveAverageQuery)
                Console.WriteLine($"ID: {s.ID}, Toplam Puan: {s.Total}");
            Console.WriteLine();

            // 🔠 6. 'Garcia' soyadlı öğrencilerin isimleri
            var garcias =
                from student in students
                where student.Last == "Garcia"
                select student.First;

            Console.WriteLine("👨‍🎓 'Garcia' soyadlı öğrenciler:");
            foreach (var name in garcias)
                Console.WriteLine(name);
            Console.WriteLine();

            // 🧠 7. İlk sınavı ortalamasından yüksek olanlar
            var betterFirstScore =
                from student in students
                let average = student.Scores.Average()
                where student.Scores[0] > average
                select $"{student.Last}, {student.First}";

            Console.WriteLine("🧮 İlk sınavı kendi ortalamasından yüksek olan öğrenciler:");
            foreach (var s in betterFirstScore)
                Console.WriteLine(s);
        }
    }
}
