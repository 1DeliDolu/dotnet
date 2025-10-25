### 📘 **Standart Sorgu Operatörlerine Genel Bakış (Standard Query Operators Overview)**

---

LINQ desenini oluşturan **standart sorgu operatörleri**, C# dilinde veri sorgulamak için kullanılan **anahtar sözcükler ve metotlardır**.
Bu operatörler **System.Linq** ad alanında (namespace) tanımlanmıştır ve genellikle iki farklı şekilde kullanılabilir:

* **Sorgu ifadesi sözdizimiyle (Query Expression Syntax)**
* **Metot temelli sözdizimiyle (Method Syntax)**

İki biçim de **aynı anlama sahiptir** — derleyici, sorgu sözdizimini uygun metot çağrılarına dönüştürür.

---

### ⚙️ **LINQ Operatörlerinin Çalışma Mantığı**

* `IEnumerable<T>` üzerinde çalıştıklarında, sorgular **ertelemeli (deferred)** çalışır — yani sorgu yalnızca **veri gerçekten istendiğinde** yürütülür.
* `IQueryable<T>` kaynaklarında ise sorgular **ifade ağacına (expression tree)** dönüştürülür ve örneğin Entity Framework gibi kütüphaneler bunu **SQL sorgusuna çevirir**.

---

### 🧠 **Temel LINQ Operatörleri**

| **Metot**           | **C# Sorgu Sözdizimi**      | **Açıklama**                          |
| ------------------- | --------------------------- | ------------------------------------- |
| `Where`             | `where`                     | Filtreleme yapar.                     |
| `Select`            | `select`                    | Veriyi projelendirir veya dönüştürür. |
| `GroupBy`           | `group … by …`              | Gruplama yapar.                       |
| `Join`              | `join … in … on … equals …` | İki veri kaynağını birleştirir.       |
| `OrderBy`           | `orderby`                   | Veriyi sıralar.                       |
| `ThenBy`            | `orderby …, …`              | Ek sıralama ölçütü ekler.             |
| `OrderByDescending` | `orderby … descending`      | Azalan sıralama yapar.                |
| `SelectMany`        | `from` (çoklu kullanım)     | İç içe dizileri düzleştirir.          |

---

### 📚 **Örnek 1 — Kelimeleri Uzunluğa Göre Gruplama**

```csharp
string sentence = "the quick brown fox jumps over the lazy dog";
string[] words = sentence.Split(' ');

// Sorgu ifadesi sözdizimi
var query = from word in words
            group word.ToUpper() by word.Length into gr
            orderby gr.Key
            select new { Length = gr.Key, Words = gr };

// Metot temelli sözdizimi
var query2 = words
    .GroupBy(w => w.Length, w => w.ToUpper())
    .Select(g => new { Length = g.Key, Words = g })
    .OrderBy(o => o.Length);

foreach (var obj in query)
{
    Console.WriteLine($"Words of length {obj.Length}:");
    foreach (string word in obj.Words)
        Console.WriteLine(word);
}
```

🎯 **Çıktı:**

```
Words of length 3:
THE
FOX
THE
DOG
Words of length 4:
OVER
LAZY
Words of length 5:
QUICK
BROWN
JUMPS
```

---

### 🧩 **Örnek 2 — Veri Sınıfları (Modelleme)**

```csharp
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
```

---

### 🧮 **Örnek 3 — Öğrencileri XML’e Dönüştürme**

```csharp
var studentsToXML = new XElement("Root",
    from student in students
    let scores = string.Join(",", student.Scores)
    select new XElement("student",
        new XElement("First", student.FirstName),
        new XElement("Last", student.LastName),
        new XElement("Scores", scores)
    )
);

Console.WriteLine(studentsToXML);
```

📤 **Çıktı (XML Formatında):**

```xml
<Root>
  <student>
    <First>Svetlana</First>
    <Last>Omelchenko</Last>
    <Scores>97,90,73,54</Scores>
  </student>
  <student>
    <First>Claire</First>
    <Last>O'Donnell</Last>
    <Scores>56,78,95,95</Scores>
  </student>
  ...
</Root>
```

---

### 🔗 **Örnek 4 — Bölüme Göre Öğrencileri Gruplama ve Sıralama**

```csharp
var orderedQuery = from department in departments
                   join student in students on department.ID equals student.DepartmentID into studentGroup
                   orderby department.Name
                   select new
                   {
                       DepartmentName = department.Name,
                       Students = from student in studentGroup
                                  orderby student.LastName
                                  select student
                   };

foreach (var departmentList in orderedQuery)
{
    Console.WriteLine(departmentList.DepartmentName);
    foreach (var student in departmentList.Students)
    {
        Console.WriteLine($"  {student.LastName,-10} {student.FirstName,-10}");
    }
}
```

---

💡 **Kısacası:**
LINQ’in standart sorgu operatörleri, **filtreleme (Where)**, **sıralama (OrderBy)**, **gruplama (GroupBy)**, **projeksiyon (Select)** ve **birleştirme (Join)** gibi güçlü işlemleri **C# diliyle doğal olarak** gerçekleştirmeni sağlar.

---

İstersen bu örneklerin hepsini tek bir tam çalışan **C# projesi** hâline getirip sana verebilirim — ister **Console App (.NET 8)** formatında, ister **LINQ öğretici demo projesi** olarak.
👉 Hangisini istersin?
