using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFilteringExample
{
    // 1️⃣ Student sınıfımızı tanımlıyoruz
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // 2️⃣ Veri kaynağı oluşturuluyor
            List<Student> students = new List<Student>
            {
                new Student { Name = "Alice", Age = 20, GPA = 3.5 },
                new Student { Name = "Bob", Age = 17, GPA = 2.8 },
                new Student { Name = "Charlie", Age = 22, GPA = 3.9 },
                new Student { Name = "Diana", Age = 19, GPA = 2.5 },
                new Student { Name = "Eve", Age = 21, GPA = 3.1 }
            };

            // 🔹 3️⃣ LINQ Query Syntax kullanarak filtreleme
            var querySyntax =
                from s in students
                where s.Age > 18 && s.GPA > 3.0       // koşullar
                orderby s.Name                         // alfabetik sırala
                select s.Name;                         // sadece isimleri seç

            Console.WriteLine("🔹 Query Syntax Sonucu:");
            foreach (var name in querySyntax)
            {
                Console.WriteLine($"Öğrenci: {name}");
            }

            Console.WriteLine("\n-------------------------\n");

            // 🔸 4️⃣ LINQ Method Syntax kullanarak aynı işlemi
            var methodSyntax = students
                .Where(s => s.Age > 18 && s.GPA > 3.0)  // filtreleme
                .OrderBy(s => s.Name)                   // sıralama
                .Select(s => s.Name);                   // sadece isim seç

            Console.WriteLine("🔸 Method Syntax Sonucu:");
            foreach (var name in methodSyntax)
            {
                Console.WriteLine($"Öğrenci: {name}");
            }

            // 💡 5️⃣ Ek: Filtrelenmiş verileri detaylı göstermek istersek:
            Console.WriteLine("\n📊 Detaylı Sonuçlar:");
            var detailed = students
                .Where(s => s.Age > 18 && s.GPA > 3.0)
                .OrderByDescending(s => s.GPA)           // not ortalamasına göre azalan sırala
                .Select(s => new { s.Name, s.Age, s.GPA });

            foreach (var item in detailed)
            {
                Console.WriteLine($"Ad: {item.Name}, Yaş: {item.Age}, Not Ort.: {item.GPA}");
            }
        }
    }
}
