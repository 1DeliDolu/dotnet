🇹🇷 **C# LINQ Kullanarak Sorgular Yazma Eğitimi (Türkçe Çeviri)**

Bu öğreticide, bir veri kaynağı oluşturup birkaç **LINQ sorgusu** yazacağız. Sorgu ifadeleriyle denemeler yaparak sonuçlardaki farkları görebilirsin. Bu örnek, LINQ sorgu ifadeleri yazmak için kullanılan **C# dil özelliklerini** gösterir.

💡 **Ön koşul:** En son .NET SDK sürümünün yüklü olduğundan emin ol. Eğer yüklü değilse, [.NET Downloads](https://dotnet.microsoft.com/download) sayfasından indir.

---

### 🚀 1. Uygulamayı Oluştur

Konsolda aşağıdaki komutu çalıştır:

```bash
dotnet new console -o WalkthroughWritingLinqQueries
```

Veya **Visual Studio** kullanıyorsan,
**WalkthroughWritingLinqQueries** adlı bir konsol uygulaması oluştur.

---

### 🧩 2. Bellekte Veri Kaynağı Oluştur

Yeni bir `students.cs` dosyası oluştur ve aşağıdaki kodu ekle:

```csharp
namespace WalkthroughWritingLinqQueries;

public record Student(string First, string Last, int ID, int[] Scores);
```

Bu `record` türü:

* Otomatik özelliklere sahiptir.
* Her öğrenci birincil kurucu ile başlatılır.
* `Scores` dizisi test notlarını içerir.

---

### 🧮 3. Öğrenci Listesini Tanımla

`Program.cs` içeriğini aşağıdaki kodla değiştir:

```csharp
using WalkthroughWritingLinqQueries;

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
```

---

### 🔍 4. İlk LINQ Sorgusunu Yaz

```csharp
IEnumerable<Student> studentQuery =
    from student in students
    where student.Scores[0] > 90
    select student;

foreach (Student student in studentQuery)
{
    Console.WriteLine($"{student.Last}, {student.First}");
}
```

**Çıktı:**

```
Omelchenko, Svetlana
Garcia, Cesar
Fakhouri, Fadi
Feng, Hanying
Garcia, Hugo
Adams, Terry
Zabokritski, Eugene
Tucker, Michael
```

---

### ⚙️ 5. Koşulları Geliştir

Birden fazla koşulu birleştirebilirsin:

```csharp
where student.Scores[0] > 90 && student.Scores[3] < 80
```

---

### 📚 6. Sonuçları Sırala

Soyadlara göre **alfabetik** sıralama:

```csharp
orderby student.Last ascending
```

Veya birinci test puanına göre **azalan** sıralama:

```csharp
orderby student.Scores[0] descending
```

Ekrana puanı da yazdır:

```csharp
Console.WriteLine($"{student.Last}, {student.First} {student.Scores[0]}");
```

---

### 🧱 7. Sonuçları Grupla

```csharp
IEnumerable<IGrouping<char, Student>> studentQuery =
    from student in students
    group student by student.Last[0];

foreach (var studentGroup in studentQuery)
{
    Console.WriteLine(studentGroup.Key);
    foreach (var student in studentGroup)
    {
        Console.WriteLine($"   {student.Last}, {student.First}");
    }
}
```

---

### 🔠 8. Grupları Sırala

```csharp
var studentQuery4 =
    from student in students
    group student by student.Last[0] into studentGroup
    orderby studentGroup.Key
    select studentGroup;

foreach (var groupOfStudents in studentQuery4)
{
    Console.WriteLine(groupOfStudents.Key);
    foreach (var student in groupOfStudents)
    {
        Console.WriteLine($"   {student.Last}, {student.First}");
    }
}
```

---

### 🧮 9. `let` Anahtar Sözcüğü

```csharp
var studentQuery5 =
    from student in students
    let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
    where totalScore / 4 < student.Scores[0]
    select $"{student.Last}, {student.First}";

foreach (string s in studentQuery5)
{
    Console.WriteLine(s);
}
```

---

### 🧠 10. Metot Sözdizimi Kullanımı

```csharp
var studentQuery =
    from student in students
    let totalScore = student.Scores.Sum()
    select totalScore;

double averageScore = studentQuery.Average();
Console.WriteLine($"Class average score = {averageScore}");
```

---

### 🎯 11. Farklı Tipte Sonuç Döndürme

```csharp
IEnumerable<string> studentQuery =
    from student in students
    where student.Last == "Garcia"
    select student.First;

Console.WriteLine("The Garcias in the class are:");
foreach (string s in studentQuery)
{
    Console.WriteLine(s);
}
```

---

### 🧾 12. Ortalama Üzerinde Puan Alanlar (Anonim Tip)

```csharp
var aboveAverageQuery =
    from student in students
    let total = student.Scores.Sum()
    where total > averageScore
    select new { id = student.ID, score = total };

foreach (var item in aboveAverageQuery)
{
    Console.WriteLine($"Student ID: {item.id}, Score: {item.score}");
}
```

---

✅ **Özetle:**
Bu eğitimde LINQ kullanarak:

* Veri kaynaklarını sorgulamayı,
* Filtrelemeyi,
* Sıralamayı,
* Gruplamayı,
* Anonim tiplerle projelemeyi
  öğrendik.

💡 LINQ sorguları, **SQL benzeri** bir yapıyı C# içinde doğal olarak kullanmanı sağlar.
