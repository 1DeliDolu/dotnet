using System;
using System.Collections.Generic;
using System.Linq;

class Customer
{
    public string Name { get; set; }
    public string City { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        // 🧱 Veri kaynağı
        List<Customer> customers = new List<Customer>
        {
            new Customer { Name = "Ali", City = "Ankara", Age = 30 },
            new Customer { Name = "Ayşe", City = "İstanbul", Age = 25 },
            new Customer { Name = "Mehmet", City = "Ankara", Age = 35 },
            new Customer { Name = "Elif", City = "İzmir", Age = 28 }
        };

        Console.WriteLine("=== 1️⃣ Veri Dönüştürmeyen Sorgu (Customer -> Customer) ===");
        IEnumerable<Customer> query1 =
            from c in customers
            where c.City == "Ankara"
            select c;

        foreach (Customer c in query1)
        {
            Console.WriteLine($"{c.Name} ({c.City}) - {c.Age} yaşında");
        }

        Console.WriteLine("\n=== 2️⃣ Veriyi Dönüştüren Sorgu (Customer -> string) ===");
        IEnumerable<string> query2 =
            from c in customers
            where c.City == "Ankara"
            select c.Name;

        foreach (string name in query2)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\n=== 3️⃣ Anonim Tip Kullanan Sorgu (Customer -> Anonymous Type) ===");
        var query3 =
            from c in customers
            where c.Age > 27
            select new { c.Name, c.City };

        foreach (var item in query3)
        {
            Console.WriteLine($"{item.Name} - {item.City}");
        }

        Console.WriteLine("\n=== 4️⃣ var ile Tür Çıkarımı (Implicit Typing) ===");
        var query4 =
            from c in customers
            where c.City.StartsWith("İ")
            select c;

        foreach (var c in query4)
        {
            Console.WriteLine($"{c.Name} ({c.City})");
        }

        Console.WriteLine("\n=== 5️⃣ LINQ ile Sayısal Liste Örneği (Ekstra) ===");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        var evenNumbers = from n in numbers
                          where n % 2 == 0
                          select n;

        foreach (var n in evenNumbers)
        {
            Console.WriteLine($"Çift sayı: {n}");
        }
    }
}
