## 🔄 C# LINQ – Veri Türü Dönüştürme (Converting Data Types)

Veri türü dönüştürme işlemleri, giriş nesnelerinin tipini değiştirir. LINQ'ta bu tür işlemler veri kaynaklarını uygun tipe çevirmek, sorguları hemen yürütmek veya koleksiyonları farklı yapılara dönüştürmek için kullanılır.

---

### ⚙️ Temel Bilgiler

Bu işlemler **`System.Collections.Generic.IEnumerable<T>`** veri kaynakları üzerinde çalışır.
Eğer **`System.Linq.IQueryProvider`** tabanlı bir kaynak (örneğin EF Core) kullanılıyorsa, ifade ağaçlarının sınırlamalarına dikkat edilmelidir.

---

### 💡 LINQ Dönüştürme Metotları

| Metot Adı        | Açıklama                                                | Açıklama (Türkçe)                                                    |
| ---------------- | ------------------------------------------------------- | -------------------------------------------------------------------- |
| **AsEnumerable** | Returns the input typed as `IEnumerable<T>`.            | Koleksiyonu `IEnumerable<T>` olarak döndürür, yürütme gerçekleşmez.  |
| **AsQueryable**  | Converts an `IEnumerable` to an `IQueryable`.           | Koleksiyonu `IQueryable` haline getirir.                             |
| **Cast**         | Casts elements of a collection to a specified type.     | Koleksiyon elemanlarını belirtilen türe dönüştürür.                  |
| **OfType**       | Filters elements depending on their ability to be cast. | Elemanları belirtilen türe dönüştürülebilme durumuna göre filtreler. |
| **ToArray**      | Converts a collection to an array.                      | Koleksiyonu diziye dönüştürür ve **hemen yürütür**.                  |
| **ToList**       | Converts a collection to a `List<T>`.                   | Koleksiyonu listeye dönüştürür ve **hemen yürütür**.                 |
| **ToDictionary** | Converts to a dictionary using a key selector.          | Koleksiyonu anahtar-değer yapısına çevirir.                          |
| **ToLookup**     | Converts to a lookup (one-to-many dictionary).          | Anahtar–birden fazla değer eşlemesi oluşturur.                       |

---

### 🧱 Ortak Veri Kaynakları

```csharp
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
```

---

### 🧠 LINQ Sorgu Sözdizimi ile Dönüştürme Örneği

```csharp
IEnumerable people = students;

var query = from Student student in people
            where student.Year == GradeLevel.ThirdYear
            select student;

foreach (Student student in query)
{
    Console.WriteLine(student.FirstName);
}
```

🗒️ **Açıklama:**
Burada `people` isimli `IEnumerable` nesnesi aslında `Student` tipindedir.
`from Student student in people` ifadesiyle açık tür dönüşümü yapılır.
Sorgu yalnızca `ThirdYear` öğrencilerini getirir.

---

### 🔍 Metot Sözdizimiyle Eşdeğer Örnek

```csharp
IEnumerable people = students;

var query = people
    .Cast<Student>() // Koleksiyonu Student tipine dönüştürür
    .Where(student => student.Year == GradeLevel.ThirdYear);

foreach (Student student in query)
{
    Console.WriteLine(student.FirstName);
}
```

🧩 **Açıklama:**

* `Cast<Student>()` → `people` koleksiyonundaki tüm öğeleri `Student` tipine dönüştürür.
* `Where(...)` → Sadece 3. sınıf öğrencilerini filtreler.
* Sonuç olarak, sorgu `IEnumerable<Student>` döner.

---

### 🎯 Özet

| Kategori                             | Metot                                                   | Yürütme Durumu        |
| ------------------------------------ | ------------------------------------------------------- | --------------------- |
| **Tip Dönüşümü (Statik)**            | `AsEnumerable()`, `AsQueryable()`                       | ❌ Erteleme (deferred) |
| **Filtreleme / Dönüştürme**          | `Cast<T>()`, `OfType<T>()`                              | ⚙️ Dinamik            |
| **Anında Yürütme (Materialization)** | `ToList()`, `ToArray()`, `ToDictionary()`, `ToLookup()` | ✅ Hemen yürütülür     |

---
