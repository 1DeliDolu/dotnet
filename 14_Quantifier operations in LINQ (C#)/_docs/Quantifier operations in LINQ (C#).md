## 💡 LINQ'de Nicelik (Quantifier) İşlemleri

**Quantifier (niceliksel) işlemler**, bir dizideki **tüm** veya **bazı** öğelerin belirli bir koşulu karşılayıp karşılamadığını kontrol eder.
Bu işlemler, sonuç olarak **Boolean (true/false)** değer döner.

---

### 🔍 LINQ Nicelik Operatörleri

| Metot        | Açıklama                                              | Sorgu Sözdizimi |
| ------------ | ----------------------------------------------------- | --------------- |
| **All**      | Tüm öğeler koşulu sağlıyorsa `true` döner.            | Yok             |
| **Any**      | Herhangi bir öğe koşulu sağlıyorsa `true` döner.      | Yok             |
| **Contains** | Koleksiyon belirli bir öğeyi içeriyorsa `true` döner. | Yok             |

---

### ✅ `All` Örneği

**Amaç:** Bütün sınav notları 70’ten yüksek olan öğrencileri bulmak.

```csharp
IEnumerable<string> names = from student in students
                            where student.Scores.All(score => score > 70)
                            select $"{student.FirstName} {student.LastName}: {string.Join(", ", student.Scores.Select(s => s.ToString()))}";

foreach (string name in names)
{
    Console.WriteLine(name);
}
```

📤 **Çıktı:**

```
Cesar Garcia: 71, 86, 77, 97
Nancy Engström: 75, 73, 78, 83
Ifunanya Ugomma: 84, 82, 96, 80
```

---

### ⚡ `Any` Örneği

**Amaç:** Herhangi bir sınavda 95’ten yüksek not alan öğrencileri bulmak.

```csharp
IEnumerable<string> names = from student in students
                            where student.Scores.Any(score => score > 95)
                            select $"{student.FirstName} {student.LastName}: {student.Scores.Max()}";

foreach (string name in names)
{
    Console.WriteLine(name);
}
```

📤 **Çıktı:**

```
Svetlana Omelchenko: 97
Cesar Garcia: 97
Debra Garcia: 96
Ifeanacho Jamuike: 98
Ifunanya Ugomma: 96
Michelle Caruana: 97
Nwanneka Ifeoma: 98
Martina Mattsson: 96
Anastasiya Sazonova: 96
Jesper Jakobsson: 98
Max Lindgren: 96
```

---

### 🎯 `Contains` Örneği

**Amaç:** En az bir sınavında **tam 95** alan öğrencileri bulmak.

```csharp
IEnumerable<string> names = from student in students
                            where student.Scores.Contains(95)
                            select $"{student.FirstName} {student.LastName}: {string.Join(", ", student.Scores.Select(s => s.ToString()))}";

foreach (string name in names)
{
    Console.WriteLine(name);
}
```

📤 **Çıktı:**

```
Claire O'Donnell: 56, 78, 95, 95
Donald Urquhart: 92, 90, 95, 57
```

---

### 💬 Özetle

* `All()` → Tüm elemanlar koşulu sağlamalı
* `Any()` → En az bir eleman koşulu sağlamalı
* `Contains()` → Koleksiyonda belirli bir değer bulunmalı

---

🎓 **Tam Kapsayıcı Kod Örneği**

```csharp
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
            new Student { FirstName = "Donald", LastName = "Urquhart", Scores = new List<int>{ 92, 90, 95, 57 } }
        };

        Console.WriteLine("🔹 All() örneği:");
        var allAbove70 = from s in students
                         where s.Scores.All(score => score > 70)
                         select $"{s.FirstName} {s.LastName}";
        foreach (var name in allAbove70)
            Console.WriteLine(name);

        Console.WriteLine("\n🔹 Any() örneği:");
        var anyAbove95 = from s in students
                         where s.Scores.Any(score => score > 95)
                         select $"{s.FirstName} {s.LastName}";
        foreach (var name in anyAbove95)
            Console.WriteLine(name);

        Console.WriteLine("\n🔹 Contains() örneği:");
        var has95 = from s in students
                    where s.Scores.Contains(95)
                    select $"{s.FirstName} {s.LastName}";
        foreach (var name in has95)
            Console.WriteLine(name);
    }
}
```
