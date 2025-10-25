C# LINQ sorguları yazma
📘 *18 Ocak 2025*

Bu makaledeki örneklerin çoğu **LINQ (Language Integrated Query)** sorgu sözdizimi (declarative query syntax) kullanılarak yazılmıştır. C# derleyicisi sorgu sözdizimini **metot çağrılarına** çevirir. Bu metotlar, **standart sorgu işleçlerini (standard query operators)** uygular:
➡️ `Where`, `Select`, `GroupBy`, `Join`, `Max`, `Average` gibi.

İsterseniz sorgu sözdizimi yerine doğrudan **metot sözdizimini (method syntax)** da kullanabilirsiniz.

---

### 🔹 Sorgu sözdizimi ve metot sözdizimi

Bu iki sözdizimi **anlamsal olarak aynıdır**, fakat sorgu sözdizimi genellikle daha okunabilirdir.
Ancak bazı sorgular yalnızca metot sözdizimiyle yazılabilir.
Örneğin:

* Belirli bir koşulu karşılayan elemanların sayısını almak (`Count`)
* En büyük değere sahip elemanı bulmak (`Max`)

---

### 🔹 Standart sorgu işleçleri örneği

```csharp
int[] numbers = [5, 10, 8, 3, 6, 12];

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

🎯 Çıktı her iki sorguda da aynıdır.
Her iki durumda da `IEnumerable<int>` türü döner.

---

### 🔹 Lambda ifadeleri

Metot sözdiziminde `Where(num => num % 2 == 0)` ifadesindeki `num => num % 2 == 0` bir **lambda ifadesidir**.
Bu ifade, `Where` metoduna koşul fonksiyonu olarak gönderilir.

Lambda ifadeleri sayesinde kod daha kısa ve okunabilir olur.

---

### 🔹 Sorguların birleştirilebilirliği

LINQ sorguları **zincirlenebilir (composable)** yapıdadır.
Yani bir sorgunun sonucunu başka bir sorguya kaynak olarak verebilirsiniz:

```csharp
numbers.Where(n => n > 5)
       .OrderBy(n => n)
       .Select(n => n * 2);
```

Her aşama `IEnumerable` döner, böylece sorgu zinciri kurulabilir.

---

## 🧩 Örnekler

### 🔸 1. Sorgu Sözdizimi

```csharp
List<int> numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

// Filtreleme
var filteringQuery =
    from num in numbers
    where num is < 3 or > 7
    select num;

// Sıralama
var orderingQuery =
    from num in numbers
    where num is < 3 or > 7
    orderby num ascending
    select num;

// Gruplama
string[] groupingQuery = ["carrots", "cabbage", "broccoli", "beans", "barley"];
var queryFoodGroups =
    from item in groupingQuery
    group item by item[0];
```

---

### 🔸 2. Metot Sözdizimi

```csharp
List<int> numbers1 = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];
List<int> numbers2 = [15, 14, 11, 13, 19, 18, 16, 17, 12, 10];

// Ortalama
double average = numbers1.Average();

// Dizileri birleştirme
var concatenationQuery = numbers1.Concat(numbers2);

// Filtreleme
var largeNumbersQuery = numbers2.Where(c => c > 15);
```

---

### 🔸 3. Karışık Sözdizimi

Sorgu ifadesini parantez içine alarak metot ekleyebilirsiniz:

```csharp
var numCount = (
    from num in numbers1
    where num is > 3 and < 7
    select num
).Count();
```

Ya da tamamen metot sözdizimiyle:

```csharp
int numCount = numbers1.Count(n => n is > 3 and < 7);
```

---

### 🔸 4. Çalışma Zamanında Filtreleme

```csharp
int[] ids = [111, 114, 112];

var queryNames = from student in students
                 where ids.Contains(student.ID)
                 select new { student.LastName, student.ID };
```

`ids` dizisi değiştirildiğinde sorgunun sonucu da değişir çünkü sorgular **deferred execution** (gecikmeli yürütme) mantığıyla çalışır.

---

### 🔸 5. Null Değerleri Yönetme

```csharp
var query1 = from c in categories
             where c != null
             join p in products on c.ID equals p?.CategoryID
             select new
             {
                 Category = c.Name,
                 Name = p.Name
             };
```

`where c != null` null değerleri filtreler, böylece `NullReferenceException` engellenir.

---

### 🔸 6. Hata Yönetimi

```csharp
try
{
    foreach (var item in exceptionDemoQuery)
    {
        Console.WriteLine($"Processing {item}");
    }
}
catch (InvalidOperationException e)
{
    Console.WriteLine(e.Message);
}
```

Sorgu **foreach** içinde yürütülür, bu yüzden hata yakalama işlemi burada yapılmalıdır.

---

✨ **Özet:**
LINQ sorguları:

* Hem **sorgu** hem de **metot** sözdizimiyle yazılabilir.
* **Lambda ifadeleri** güçlü filtreleme sağlar.
* **Deferred execution** ile sorgular geç yürütülür.
* **Null** ve **exception** yönetimi önemlidir.
* **Zincirleme (composability)** yapısıyla karmaşık sorgular kolayca oluşturulur.
