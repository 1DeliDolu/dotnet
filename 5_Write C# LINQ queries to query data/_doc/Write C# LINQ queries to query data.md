💡 **C# LINQ ile veri sorgulama (LINQ Queries to Query Data)**

LINQ (Language Integrated Query), C# diline gömülü bir sorgulama yapısıdır.
Verileri **koleksiyonlardan**, **veritabanlarından**, **XML dosyalarından** veya diğer kaynaklardan **sorgulamak**, **filtrelemek**, **sıralamak** ve **gruplamak** için kullanılır.

---

### 🧩 **Temel LINQ Sözdizimleri**

LINQ iki farklı şekilde yazılabilir:

1. **Sorgu (Query) Sözdizimi**
2. **Metot (Method) Sözdizimi**

---

### 📘 **Örnek 1: Basit LINQ Sorgusu**

```csharp
int[] numbers = { 5, 10, 8, 3, 6, 12 };

// Sorgu sözdizimi:
IEnumerable<int> numQuery1 =
    from num in numbers
    where num % 2 == 0
    orderby num
    select num;

// Metot sözdizimi:
IEnumerable<int> numQuery2 = numbers
    .Where(num => num % 2 == 0)
    .OrderBy(n => n);

foreach (int i in numQuery1)
{
    Console.Write(i + " ");
}
Console.WriteLine();
foreach (int i in numQuery2)
{
    Console.Write(i + " ");
}
```

🎯 **Çıktı:**

```
6 8 10 12
6 8 10 12
```

---

### ⚙️ **Örnek 2: Filtreleme, Sıralama ve Gruplama**

```csharp
List<int> numbers = new() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

// 1️⃣ Filtreleme
var filteringQuery =
    from num in numbers
    where num < 3 || num > 7
    select num;

// 2️⃣ Sıralama
var orderingQuery =
    from num in numbers
    where num < 3 || num > 7
    orderby num ascending
    select num;

// 3️⃣ Gruplama
string[] foods = { "carrots", "cabbage", "broccoli", "beans", "barley" };
var groupingQuery =
    from item in foods
    group item by item[0];

foreach (var group in groupingQuery)
{
    Console.WriteLine($"Grup: {group.Key}");
    foreach (var item in group)
        Console.WriteLine($"  {item}");
}
```

---

### 🔢 **Örnek 3: Metot Sözdizimiyle Ortalama, Birleştirme ve Filtreleme**

```csharp
List<int> numbers1 = new() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
List<int> numbers2 = new() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };

// Ortalama
double average = numbers1.Average();
Console.WriteLine($"Ortalama: {average}");

// Birleştirme
var concatenationQuery = numbers1.Concat(numbers2);
Console.WriteLine("Birleşik liste: " + string.Join(", ", concatenationQuery));

// Filtreleme (Lambda ile)
var largeNumbersQuery = numbers2.Where(c => c > 15);
Console.WriteLine("15’ten büyük sayılar: " + string.Join(", ", largeNumbersQuery));
```

---

### 🧮 **Örnek 4: Karışık Sorgu + Metot Kullanımı**

```csharp
var numCount = (
    from num in numbers1
    where num > 3 && num < 7
    select num
).Count();

Console.WriteLine($"3 ile 7 arasında {numCount} sayı var.");
```

---

### 🧠 **Kavramlar:**

| Kavram                             | Açıklama                                 |
| ---------------------------------- | ---------------------------------------- |
| `where`                            | Filtreleme koşulu                        |
| `orderby`                          | Sıralama                                 |
| `select`                           | Sonuç kümesini belirleme                 |
| `group ... by`                     | Gruplama                                 |
| `join`                             | Koleksiyonları birleştirme               |
| `Count(), Sum(), Max(), Average()` | Sayısal işlemler                         |
| `Contains()`                       | Dinamik filtreleme                       |
| `Lambda ifadesi`                   | `x => x > 10` gibi kısa fonksiyon tanımı |

---

### 🚀 **Kısaca:**

LINQ, C# koleksiyonlarıyla SQL benzeri sorgular yazmanı sağlar.
Hem okunabilir hem güçlüdür, ve **`IEnumerable<T>`** üzerinde çalışır.

