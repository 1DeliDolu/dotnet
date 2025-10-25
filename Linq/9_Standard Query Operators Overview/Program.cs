using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LinqStandardQueryOperators
{
    public enum GradeLevel
    {
        FirstYear = 1,
        SecondYear,
        ThirdYear,
        FourthYear
    }

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
            // 🔹 Veri Kaynakları
            List<Department> departments = new()
            {
                new Department { ID = 1, Name = "Physics", TeacherID = 1 },
                new Department { ID = 2, Name = "Mathematics", TeacherID = 2 },
                new Department { ID = 3, Name = "Chemistry", TeacherID = 3 },
                new Department { ID = 4, Name = "English", TeacherID = 4 }
            };

            List<Teacher> teachers = new()
            {
                new Teacher { ID = 1, First = "Don", Last = "Richardson", City = "Stockholm" },
                new Teacher { ID = 2, First = "Anna", Last = "Hedlund", City = "Göteborg" },
                new Teacher { ID = 3, First = "Carmen", Last = "Vella", City = "Malmö" },
                new Teacher { ID = 4, First = "Sarah", Last = "Andersson", City = "Uppsala" }
            };

            List<Student> students = new()
            {
                new Student { FirstName = "Svetlana", LastName = "Omelchenko", ID = 1, Year = GradeLevel.FirstYear, Scores = new() {97, 90, 73, 54}, DepartmentID = 4 },
                new Student { FirstName = "Claire", LastName = "O'Donnell", ID = 2, Year = GradeLevel.SecondYear, Scores = new() {56, 78, 95, 95}, DepartmentID = 3 },
                new Student { FirstName = "Max", LastName = "Lindgren", ID = 3, Year = GradeLevel.ThirdYear, Scores = new() {86, 88, 96, 63}, DepartmentID = 2 },
                new Student { FirstName = "Arina", LastName = "Ivanova", ID = 4, Year = GradeLevel.FourthYear, Scores = new() {93, 63, 70, 80}, DepartmentID = 4 },
                new Student { FirstName = "Don", LastName = "Richardson", ID = 5, Year = GradeLevel.FirstYear, Scores = new() {70, 80, 90, 100}, DepartmentID = 1 },
            };

            // 🔹 1. WHERE – Filtreleme
            var highScoreStudents = from s in students
                                    where s.Scores.Average() > 80
                                    select s;

            Console.WriteLine("🧠 Ortalama puanı 80 üzeri öğrenciler:");
            foreach (var s in highScoreStudents)
                Console.WriteLine($" - {s.FirstName} {s.LastName}");

            Console.WriteLine("\n--------------------------------------------");

            // 🔹 2. SELECT – Projeksiyon
            var nameList = from s in students
                           select new { FullName = $"{s.FirstName} {s.LastName}" };

            Console.WriteLine("📋 Öğrenci isim listesi:");
            foreach (var n in nameList)
                Console.WriteLine($" - {n.FullName}");

            Console.WriteLine("\n--------------------------------------------");

            // 🔹 3. ORDERBY – Sıralama
            var orderedStudents = from s in students
                                  orderby s.LastName
                                  select s;

            Console.WriteLine("🔤 Soyada göre sıralanmış öğrenciler:");
            foreach (var s in orderedStudents)
                Console.WriteLine($" - {s.LastName}, {s.FirstName}");

            Console.WriteLine("\n--------------------------------------------");

            // 🔹 4. GROUPBY – Gruplama
            var groupByDepartment = from s in students
                                    group s by s.DepartmentID into g
                                    select new { DepartmentID = g.Key, Count = g.Count() };

            Console.WriteLine("🏫 Bölümlere göre öğrenci sayısı:");
            foreach (var g in groupByDepartment)
                Console.WriteLine($" - Bölüm ID {g.DepartmentID}: {g.Count} öğrenci");

            Console.WriteLine("\n--------------------------------------------");

            // 🔹 5. JOIN – Birleştirme
            var studentDepartment = from s in students
                                    join d in departments on s.DepartmentID equals d.ID
                                    select new { s.FirstName, s.LastName, DepartmentName = d.Name };

            Console.WriteLine("📚 Öğrenciler ve Bölümleri:");
            foreach (var s in studentDepartment)
                Console.WriteLine($" - {s.FirstName} {s.LastName} => {s.DepartmentName}");

            Console.WriteLine("\n--------------------------------------------");

            // 🔹 6. SELECTMANY – Çoklu koleksiyonları düzleştirme
            var allScores = students.SelectMany(s => s.Scores);
            Console.WriteLine($"📊 Tüm notların ortalaması: {allScores.Average():F2}");

            Console.WriteLine("\n--------------------------------------------");

            // 🔹 7. DATA TRANSFORMATION – Veriyi XML'e dönüştürme
            var studentsXml = new XElement("Students",
                from s in students
                select new XElement("Student",
                    new XElement("FirstName", s.FirstName),
                    new XElement("LastName", s.LastName),
                    new XElement("Average", s.Scores.Average())
                ));

            Console.WriteLine("🧾 XML çıktısı:");
            Console.WriteLine(studentsXml);

            Console.WriteLine("\n--------------------------------------------");

            // 🔹 8. COMPLEX JOIN + ORDERBY
            var departmentStudentOrder = from d in departments
                                         join s in students on d.ID equals s.DepartmentID into grp
                                         orderby d.Name
                                         select new
                                         {
                                             Department = d.Name,
                                             Students = grp.OrderBy(s => s.LastName)
                                         };

            Console.WriteLine("🏛️ Bölümlere göre sıralı öğrenci listesi:");
            foreach (var dep in departmentStudentOrder)
            {
                Console.WriteLine($"\n{dep.Department}:");
                foreach (var s in dep.Students)
                    Console.WriteLine($"   {s.LastName}, {s.FirstName}");
            }
        }
    }
}
