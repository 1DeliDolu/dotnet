### 🔍 **Sorgu İfade Temelleri (Query Expression Basics)**

🗓️ **16 Ocak 2025**

---

#### ❓ **Sorgu nedir ve ne işe yarar?**

Bir **sorgu (query)**, belirli bir veri kaynağından hangi verilerin alınacağını ve bu verilerin nasıl biçimlendirileceğini tanımlayan bir **talimatlar kümesidir**.

> Sorgu, ürettiği sonuçlardan **farklıdır**.

Genellikle, kaynak veriler **aynı türden öğelerin bir dizisi (sequence)** olarak düzenlenir:

* 💾 **SQL tablosu** → satırlar dizisi
* 📄 **XML dosyası** → öğeler dizisi
* 💡 **Bellek içi koleksiyon** → nesneler dizisi

Bir uygulama açısından, verinin asıl türü önemli değildir — her zaman veri **`IEnumerable<T>`** veya **`IQueryable<T>`** şeklinde görülür.

---

#### ⚙️ **Sorgular ne yapabilir?**

1. **Filtreleme ve sıralama:**
   Öğeleri değiştirmeden alt küme oluşturur.

   ```csharp
   IEnumerable<int> highScoresQuery =
       from score in scores
       where score > 80
       orderby score descending
       select score;
   ```

2. **Dönüştürme (Projection):**
   Kaynak öğeleri yeni bir tipe dönüştürür.

   ```csharp
   IEnumerable<string> highScoresQuery2 =
       from score in scores
       where score > 80
       orderby score descending
       select $"The score is {score}";
   ```

3. **Tekil değer (Aggregate):**
   Belirli bir koşulu sağlayan öğelerin sayısı, toplamı veya maksimumu gibi tek bir sonuç döndürür.

   ```csharp
   var highScoreCount = (
       from score in scores
       where score > 80
       select score
   ).Count();
   ```

---

#### 📘 **Sorgu İfadesi (Query Expression) nedir?**

Bir sorgunun **C# sorgu sözdizimiyle** ifade edilmiş halidir.
SQL veya XQuery’ye benzer **deklaratif bir yapısı** vardır.

✅ **Bir sorgu ifadesi:**

* Her zaman `from` ile başlar
* `select` veya `group` ile biter
* Arada şu isteğe bağlı bölümleri içerebilir:
  `where`, `orderby`, `join`, `let`, `from`, `into`

---

#### 💡 **Sorgu Değişkeni (Query Variable)**

Bir sorgunun **sonucunu değil**, sorgunun **kendisini** tutan değişkendir.
`IEnumerable<T>` veya `IQueryable<T>` türündedir.

```csharp
IEnumerable<int> scoreQuery =
    from score in scores
    where score > 80
    orderby score descending
    select score;

foreach (var s in scoreQuery)
{
    Console.WriteLine(s);
}
```

> ⚠️ Sorgu değişkeni, veriyi **foreach içinde çalıştırılana kadar** içermez.

---

#### 🧩 **Açık ve örtük tür tanımı**

Sorgu değişkeni açıkça veya `var` anahtar sözcüğüyle tanımlanabilir:

```csharp
var queryCities =
    from city in cities
    where city.Population > 100000
    select city;
```

Her iki durumda da sonuç **`IEnumerable<City>`** türündedir.

---

#### 🚀 **Sorgu ifadesini başlatmak**

Her sorgu **`from`** ile başlar.
`from` ifadesi, veri kaynağını ve bir **aralık değişkenini (range variable)** belirtir:

```csharp
IEnumerable<Country> countryAreaQuery =
    from country in countries
    where country.Area > 20
    select country;
```

Bir öğe içinde başka bir koleksiyon varsa, birden fazla `from` kullanılabilir:

```csharp
IEnumerable<City> cityQuery =
    from country in countries
    from city in country.Cities
    where city.Population > 10000
    select city;
```

---

#### 🏁 **Sorgu ifadesini bitirmek**

Bir sorgu **`select`** veya **`group`** ifadesiyle sona erer.

##### 🧱 **group örneği:**

```csharp
var queryCountryGroups =
    from country in countries
    group country by country.Name[0];
```

##### ✨ **select örneği:**

```csharp
IEnumerable<Country> sortedQuery =
    from country in countries
    orderby country.Area
    select country;
```

> `select` aynı zamanda **veri dönüşümü (projection)** yapabilir:

```csharp
var queryNameAndPop =
    from country in countries
    select new { Name = country.Name, Pop = country.Population };
```

---

#### 🔁 **into ile devam sorguları (continuations)**

`into`, bir sorgudan sonra yeni işlemler yapmayı sağlar.

```csharp
var percentileQuery =
    from country in countries
    let percentile = (int)country.Population / 1_000
    group country by percentile into countryGroup
    where countryGroup.Key >= 20
    orderby countryGroup.Key
    select countryGroup;
```

---

#### 🔍 **Filtreleme, sıralama ve birleştirme**

* **`where`** → filtreleme
* **`orderby`** → sıralama
* **`join`** → veri kaynaklarını birleştirme
* **`let`** → ara değişken tanımlama

Örnekler:

```csharp
// where
IEnumerable<City> queryCityPop =
    from city in cities
    where city.Population is < 15_000_000 and > 10_000_000
    select city;

// orderby
IEnumerable<Country> querySortedCountries =
    from country in countries
    orderby country.Area, country.Population descending
    select country;

// join
var categoryQuery =
    from cat in categories
    join prod in products on cat equals prod.Category
    select new { Category = cat, Name = prod.Name };

// let
string[] names = ["Svetlana Omelchenko", "Claire O'Donnell"];
var queryFirstNames =
    from name in names
    let firstName = name.Split(' ')[0]
    select firstName;
```

---

#### 🧠 **Alt sorgular (Subqueries)**

Bir sorgu ifadesi içinde başka bir sorgu kullanılabilir:

```csharp
var queryGroupMax =
    from student in students
    group student by student.Year into studentGroup
    select new
    {
        Level = studentGroup.Key,
        HighestScore = (
            from student2 in studentGroup
            select student2.ExamScores.Average()
        ).Max()
    };
```

---

✨ **Özetle:**
LINQ sorguları, C# içinde **SQL benzeri** bir biçimde veriyle çalışmayı sağlar.
Hem **okunabilir**, hem de **tür güvenli** bir yapı sunar.

---
