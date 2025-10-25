## 🔹 C# LINQ'de Gruplama (Grouping Data)

**Gruplama (Grouping)**, veri koleksiyonundaki elemanları belirli bir **ortak özelliğe göre** gruplandırma işlemidir.
Her grubun bir **anahtarı (key)** olur, ve bu anahtarı paylaşan elemanlar aynı gruba ait olur. 🎯

---

### 🧩 Temel Mantık

LINQ'de gruplama işlemi genellikle şu iki yöntemle yapılır:

* **Sorgu sözdizimi (query syntax)** → `group … by … into …`
* **Metot sözdizimi (method syntax)** → `.GroupBy()`

---

### 📘 Basit Örnek – Tek Özelliğe Göre Gruplama

```csharp
List<int> numbers = [35, 44, 200, 84, 3987, 4, 199, 329, 446, 208];

IEnumerable<IGrouping<int, int>> query =
    from number in numbers
    group number by number % 2;

foreach (var group in query)
{
    Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");
    foreach (int i in group)
    {
        Console.WriteLine(i);
    }
}
```

### 🧠 Metot Sözdizimi Eşdeğeri

```csharp
List<int> numbers = [35, 44, 200, 84, 3987, 4, 199, 329, 446, 208];

IEnumerable<IGrouping<int, int>> query = numbers
    .GroupBy(number => number % 2);

foreach (var group in query)
{
    Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");
    foreach (int i in group)
    {
        Console.WriteLine(i);
    }
}
```

📊 **Sonuç:**

```
Odd numbers:
35
3987
199
329

Even numbers:
44
200
84
4
446
208
```

---

### 🧮 1️⃣ Özelliğe Göre Gruplama (Öğrenci Yılı)

```csharp
var groupByYearQuery =
    from student in students
    group student by student.Year into newGroup
    orderby newGroup.Key
    select newGroup;

foreach (var yearGroup in groupByYearQuery)
{
    Console.WriteLine($"Year: {yearGroup.Key}");
    foreach (var student in yearGroup)
    {
        Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
    }
}
```

---

### 🔤 Soyadın İlk Harfine Göre Gruplama

```csharp
var groupByFirstLetterQuery =
    from student in students
    let firstLetter = student.LastName[0]
    group student by firstLetter;

foreach (var studentGroup in groupByFirstLetterQuery)
{
    Console.WriteLine($"Key: {studentGroup.Key}");
    foreach (var student in studentGroup)
    {
        Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
    }
}
```

---

### 🧾 Aralık (Range) Değerine Göre Gruplama

```csharp
static int GetPercentile(Student s)
{
    double avg = s.Scores.Average();
    return avg > 0 ? (int)avg / 10 : 0;
}

var groupByPercentileQuery =
    from student in students
    let percentile = GetPercentile(student)
    group new
    {
        student.FirstName,
        student.LastName
    } by percentile into percentGroup
    orderby percentGroup.Key
    select percentGroup;

foreach (var studentGroup in groupByPercentileQuery)
{
    Console.WriteLine($"Key: {studentGroup.Key * 10}");
    foreach (var item in studentGroup)
    {
        Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
    }
}
```

---

### ✅ Mantıksal Karşılaştırmaya Göre Gruplama (Boolean Key)

```csharp
var groupByHighAverageQuery =
    from student in students
    group new
    {
        student.FirstName,
        student.LastName
    } by student.Scores.Average() > 75 into studentGroup
    select studentGroup;

foreach (var studentGroup in groupByHighAverageQuery)
{
    Console.WriteLine($"Key: {studentGroup.Key}");
    foreach (var student in studentGroup)
    {
        Console.WriteLine($"\t{student.FirstName} {student.LastName}");
    }
}
```

🧩 Bu örnekte `true` veya `false` olan iki grup oluşur:

> Ortalama 75’in üzerinde olanlar (`true`) ve olmayanlar (`false`).

---

### 🧱 Bileşik Anahtar (Compound Key) ile Gruplama

```csharp
var groupByCompoundKey =
    from student in students
    group student by new
    {
        FirstLetterOfLastName = student.LastName[0],
        IsScoreOver85 = student.Scores[0] > 85
    } into studentGroup
    orderby studentGroup.Key.FirstLetterOfLastName
    select studentGroup;

foreach (var scoreGroup in groupByCompoundKey)
{
    var s = scoreGroup.Key.IsScoreOver85 ? "more than 85" : "less than 85";
    Console.WriteLine($"Name starts with {scoreGroup.Key.FirstLetterOfLastName} who scored {s}");
    foreach (var item in scoreGroup)
    {
        Console.WriteLine($"\t{item.FirstName} {item.LastName}");
    }
}
```

---

### 🪜 İç İçe (Nested) Gruplama

```csharp
var nestedGroupsQuery =
    from student in students
    group student by student.Year into newGroup1
    from newGroup2 in
        from student in newGroup1
        group student by student.LastName
    group newGroup2 by newGroup1.Key;

foreach (var outerGroup in nestedGroupsQuery)
{
    Console.WriteLine($"Student Level = {outerGroup.Key}");
    foreach (var innerGroup in outerGroup)
    {
        Console.WriteLine($"\tNames starting with: {innerGroup.Key}");
        foreach (var innerGroupElement in innerGroup)
        {
            Console.WriteLine($"\t\t{innerGroupElement.LastName} {innerGroupElement.FirstName}");
        }
    }
}
```

---

### 📈 Gruplama Üzerinde Alt Sorgu (Subquery)

```csharp
var queryGroupMax =
    from student in students
    group student by student.Year into studentGroup
    select new
    {
        Level = studentGroup.Key,
        HighestScore = (
            from student2 in studentGroup
            select student2.Scores.Average()
        ).Max()
    };

foreach (var item in queryGroupMax)
{
    Console.WriteLine($"  {item.Level} Highest Score={item.HighestScore}");
}
```

---

### 💡 Özet

| Senaryo           | Kullanılan Yöntem                                     | Anahtar Türü   |
| ----------------- | ----------------------------------------------------- | -------------- |
| Tek özellik       | `student.Year`                                        | Enum           |
| Soyadın ilk harfi | `student.LastName[0]`                                 | Char           |
| Aralık (Range)    | `GetPercentile(student)`                              | Int            |
| Karşılaştırma     | `student.Scores.Average() > 75`                       | Bool           |
| Bileşik anahtar   | `new { student.LastName[0], student.Scores[0] > 85 }` | Anonymous Type |
| İç içe grup       | `group … by …` içinde `group … by …`                  | Nested         |

---

💬 **Kısaca:**
LINQ’de `group` ve `.GroupBy()` kullanarak veriyi anahtar değerlerine göre gruplandırabilir, bu gruplar üzerinde hesaplama veya alt sorgular çalıştırabilirsin.
Bu, özellikle **istatistiksel analiz**, **raporlama**, ve **filtreleme** işlemlerinde çok güçlüdür. 🚀
