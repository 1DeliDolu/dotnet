## 🔷 C# LINQ Küme İşlemleri (Set Operations)

Küme işlemleri, LINQ’ta **koleksiyonlar arasında fark (Except), kesişim (Intersect), birleşim (Union)** veya **tekrarlı elemanların kaldırılması (Distinct)** gibi işlemleri yapmanı sağlar.
Bu işlemler, SQL’deki `DISTINCT`, `EXCEPT`, `INTERSECT` ve `UNION` ifadelerine karşılık gelir.

---

### 🟩 1. Distinct / DistinctBy — Tekrarlanan Değerleri Kaldırmak

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = { "the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog" };

        // 🔹 Tekrarlı kelimeleri kaldırır
        var distinctWords = words.Distinct();

        Console.WriteLine("Distinct:");
        foreach (var word in distinctWords)
            Console.WriteLine(word);

        // 🔹 Kelime uzunluklarına göre ayırır, aynı uzunluktakilerden sadece birini alır
        var distinctByLength = words.DistinctBy(w => w.Length);

        Console.WriteLine("\nDistinctBy (Length):");
        foreach (var word in distinctByLength)
            Console.WriteLine(word);
    }
}
```

📤 **Çıktı:**

```
Distinct:
the
quick
brown
fox
jumped
over
lazy
dog

DistinctBy (Length):
the
quick
jumped
over
```

---

### 🟨 2. Except / ExceptBy — Bir Koleksiyonda Olan, Diğerinde Olmayanlar

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words1 = { "the", "quick", "brown", "fox" };
        string[] words2 = { "jumped", "over", "the", "lazy", "dog" };

        // 🔹 words1'de olup words2'de olmayanlar
        var exceptWords = words1.Except(words2);

        Console.WriteLine("Except:");
        foreach (var word in exceptWords)
            Console.WriteLine(word);
    }
}
```

📤 **Çıktı:**

```
quick
brown
fox
```

---

### 🟦 3. Intersect / IntersectBy — Ortak Elemanları Bulmak

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words1 = { "the", "quick", "brown", "fox" };
        string[] words2 = { "jumped", "over", "the", "lazy", "dog" };

        // 🔹 İki dizide de bulunan kelimeleri döndürür
        var intersectWords = words1.Intersect(words2);

        Console.WriteLine("Intersect:");
        foreach (var word in intersectWords)
            Console.WriteLine(word);
    }
}
```

📤 **Çıktı:**

```
the
```

---

### 🟥 4. Union / UnionBy — Benzersiz Elemanları Birleştirmek

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words1 = { "the", "quick", "brown", "fox" };
        string[] words2 = { "jumped", "over", "the", "lazy", "dog" };

        // 🔹 Her iki dizinin benzersiz birleşimini döndürür
        var unionWords = words1.Union(words2);

        Console.WriteLine("Union:");
        foreach (var word in unionWords)
            Console.WriteLine(word);
    }
}
```

📤 **Çıktı:**

```
the
quick
brown
fox
jumped
over
lazy
dog
```

---

### 💡 Özet Tablo

| Metot         | Açıklama                                                   | Alternatif              |
| ------------- | ---------------------------------------------------------- | ----------------------- |
| `Distinct()`  | Yinelenen öğeleri kaldırır                                 | `DistinctBy(selector)`  |
| `Except()`    | İlk kümede olup ikincisinde olmayan öğeleri döndürür       | `ExceptBy(selector)`    |
| `Intersect()` | Her iki kümede de olan öğeleri döndürür                    | `IntersectBy(selector)` |
| `Union()`     | Her iki kümenin birleşimini döndürür (benzersiz elemanlar) | `UnionBy(selector)`     |

---

### 🧩 Geniş Örnek: Öğrenci ve Öğretmen Üzerinden UnionBy

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}

public class Teacher
{
    public string First { get; init; }
    public string Last { get; init; }
}

class Program
{
    static void Main()
    {
        var students = new List<Student>
        {
            new() { FirstName = "Ali", LastName = "Kaya" },
            new() { FirstName = "Ayşe", LastName = "Demir" },
            new() { FirstName = "Fatma", LastName = "Yılmaz" }
        };

        var teachers = new List<Teacher>
        {
            new() { First = "Ali", Last = "Kaya" },
            new() { First = "Mehmet", Last = "Çelik" }
        };

        // 🔹 Öğrenci ve öğretmenleri isim-soyisim bazında birleştirir
        var unionPeople = students
            .Select(s => (FirstName: s.FirstName, LastName: s.LastName))
            .UnionBy(
                teachers.Select(t => (t.First, t.Last)),
                p => (p.FirstName, p.LastName));

        Console.WriteLine("UnionBy Sonucu:");
        foreach (var person in unionPeople)
            Console.WriteLine($"{person.FirstName} {person.LastName}");
    }
}
```

📤 **Çıktı:**

```
Ali Kaya
Ayşe Demir
Fatma Yılmaz
Mehmet Çelik
```

---

✨ **Özetle:**
LINQ Set Operations, koleksiyonları SQL benzeri mantıkla karşılaştırmak, filtrelemek ve birleştirmek için güçlü bir araçtır.
Bu işlemler **`Distinct`**, **`Except`**, **`Intersect`** ve **`Union`** metotlarıyla yapılır; “By” versiyonları (`DistinctBy`, `ExceptBy`, `UnionBy`, `IntersectBy`) ise **özelleştirilmiş kıyaslama anahtarı (keySelector)** kullanmana imkân tanır.
