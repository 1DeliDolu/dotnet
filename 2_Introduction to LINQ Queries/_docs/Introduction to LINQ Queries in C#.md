## 💡 C#’ta LINQ Sorgularına Giriş

📅 **03/24/2025**

Bir **sorgu (query)**, bir veri kaynağından veri almak için kullanılan bir ifadedir.
Farklı veri kaynaklarının farklı **yerel sorgu dilleri** vardır — örneğin, ilişkisel veritabanları için **SQL**, XML için **XQuery**.
Geliştiricilerin her veri kaynağı türü için farklı bir sorgu dili öğrenmesi gerekir.

**LINQ**, bu karmaşıklığı ortadan kaldırır ve tüm veri türleri için **tutarlı bir C# sorgulama modeli** sunar.
LINQ sorgularında daima **C# nesneleri** ile çalışırsın.
XML belgeleri, SQL veritabanları, .NET koleksiyonları veya diğer veri biçimleri fark etmeksizin, aynı temel sorgulama desenlerini kullanırsın.

---

## ⚙️ Bir LINQ Sorgusunun Üç Ana Bölümü

1. **Veri kaynağını elde et (Data Source)**
2. **Sorguyu oluştur (Create the Query)**
3. **Sorguyu çalıştır (Execute the Query)**

### 🧩 Örnek:

```csharp
// 1️⃣ Veri kaynağı
int[] numbers = [ 0, 1, 2, 3, 4, 5, 6 ];

// 2️⃣ Sorgu oluşturma
// numQuery bir IEnumerable<int>’tir
var numQuery = from num in numbers
               where (num % 2) == 0
               select num;

// 3️⃣ Sorguyu yürütme
foreach (int num in numQuery)
{
    Console.Write("{0,1} ", num);
}
```

> 🔎 LINQ’da sorgunun yürütülmesi (execution) ve tanımlanması (declaration) **ayrı işlemlerdir.**
> Yani, sorgu değişkenini oluşturmak veriyi hemen çekmez.

---

## 🧱 Veri Kaynağı (Data Source)

Yukarıdaki örnekte veri kaynağı bir dizidir (`int[]`), bu da **`IEnumerable<T>`** arayüzünü destekler.
Dolayısıyla LINQ ile sorgulanabilir.

Bir sorgu, genellikle **`foreach`** döngüsü içinde çalıştırılır çünkü **`foreach`**, `IEnumerable` veya `IEnumerable<T>` gerektirir.
Bu türleri destekleyen tüm veri yapıları **sorgulanabilir tipler (queryable types)** olarak adlandırılır.

### 🔸 XML’den Veri Kaynağı Oluşturma

```csharp
// using System.Xml.Linq;
XElement contacts = XElement.Load(@"c:\myContactList.xml");
```

### 🔸 Entity Framework Örneği

```csharp
Northwnd db = new Northwnd(@"c:\northwnd.mdf");

// Londra’daki müşterileri sorgula
IQueryable<Customer> custQuery =
    from cust in db.Customers
    where cust.City == "London"
    select cust;
```

> 💬 Bir LINQ veri kaynağı, `IEnumerable<T>` veya ondan türetilen (`IQueryable<T>`) herhangi bir türdür.

---

## 🔍 Sorgu (Query)

Sorgu, veri kaynağından **hangi bilgilerin alınacağını** ve isteğe bağlı olarak **nasıl sıralanacağını, gruplanacağını** belirtir.
Sorgular **C# sorgu sözdizimi (query syntax)** kullanılarak yazılır.

Örnek sorgu:

```csharp
var evenNumQuery = from num in numbers
                   where (num % 2) == 0
                   select num;
```

> 🧠 Sorgu değişkeni (ör. `evenNumQuery`) veriyi tutmaz, yalnızca sorgunun **nasıl yürütüleceğini tarif eder.**

---

## ⚡ Sorguların Çalışma Biçimleri

### 🟢 **Anında Yürütme (Immediate Execution)**

Veri kaynağı hemen okunur ve sonuç tek seferde üretilir.
`Count()`, `Max()`, `Average()`, `First()` gibi sorgular anında yürütülür.

```csharp
int evenNumCount = evenNumQuery.Count();
```

Ayrıca sorguyu hemen yürütüp sonuçları belleğe almak için:

```csharp
List<int> numQuery2 = (from num in numbers
                       where (num % 2) == 0
                       select num).ToList();

var numQuery3 = (from num in numbers
                 where (num % 2) == 0
                 select num).ToArray();
```

> 🔸 `ToList()` veya `ToArray()` çağrıları sorguyu **hemen çalıştırır** ve sonucu belleğe **önbellekler (cache)**.

---

### 🕐 **Ertelenmiş Yürütme (Deferred Execution)**

Sorgu, tanımlandığı anda değil; yalnızca **üzerinde dönüldüğünde** (`foreach` gibi) yürütülür.

```csharp
foreach (int num in numQuery)
{
    Console.Write("{0,1} ", num);
}
```

> 🔄 Veri kaynağı değişirse, sorgu yeniden yürütüldüğünde **güncel verileri** döndürür.
> Bu, sorgunun **yeniden kullanılabilir (reusable)** olmasını sağlar.

---

## 🧮 Ertelenmiş Yürütmenin Türleri

### 🔹 Akış (Streaming)

Veri kaynağını **tamamını okumadan** sonuç üretmeye başlar.
Örn. `Where`, `Select`, `Take` operatörleri.

### 🔸 Akışsız (Non-Streaming)

Tüm veriyi **önce okur**, sonra sonuç üretir.
Örn. `OrderBy`, `GroupBy`, `Reverse`.

---

## 📊 Sorgu Operatörlerinin Sınıflandırması

| Standart Sorgu Operatörü                       | Dönen Tür          | Anında | Ertelenmiş (Akışlı) | Ertelenmiş (Akışsız) |
| ---------------------------------------------- | ------------------ | :----: | :-----------------: | :------------------: |
| **Aggregate**                                  | TSource            |    ✅   |                     |                      |
| **All / Any / Contains**                       | Boolean            |    ✅   |                     |                      |
| **Average / Count / Max / Min / Sum**          | Tek değer          |    ✅   |                     |                      |
| **Where / Select / Skip / Take**               | IEnumerable        |        |          ✅          |                      |
| **OrderBy / GroupBy / Reverse / ThenBy**       | IOrderedEnumerable |        |                     |           ✅          |
| **Concat / Union / Join / Intersect / Except** | IEnumerable        |        |          ✅          |           ✅          |
| **ToList / ToArray / ToDictionary**            | Koleksiyon         |    ✅   |                     |                      |

---

## 🧠 LINQ to Objects

“**LINQ to Objects**” ifadesi, `IEnumerable` veya `IEnumerable<T>` tabanlı herhangi bir koleksiyonun LINQ ile sorgulanması anlamına gelir.
Örneğin: `List<T>`, `Array`, `Dictionary<TKey, TValue>` vb.

Avantajları:

1. Kod **daha kısa ve okunabilir** olur.
2. **Filtreleme, sıralama ve gruplama** kolayca yapılır.
3. **Farklı veri kaynaklarına taşınabilir**.

---

## 💾 Sorgu Sonuçlarını Belleğe Kaydetme

Bir sorgu, veriyi hemen değil **istek üzerine (lazy)** üretir.
Eğer sonucu **önceden belleğe almak** istiyorsan aşağıdaki metotları kullanabilirsin:

* `ToList()`
* `ToArray()`
* `ToDictionary()`
* `ToLookup()`

### Örnek:

```csharp
List<int> numbers = [ 1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 ];

IEnumerable<int> queryFactorsOfFour = from num in numbers
                                      where num % 4 == 0
                                      select num;

// Sorgu sonucunu belleğe al
var factorsofFourList = queryFactorsOfFour.ToList();

// Liste verilerini okuma ve değiştirme
Console.WriteLine(factorsofFourList[2]);
factorsofFourList[2] = 0;
Console.WriteLine(factorsofFourList[2]);
```

---

✨ **Özetle:**
LINQ, C# içinde veriye erişimi basitleştirir.
Aynı sözdizimiyle farklı veri kaynaklarında sorgular yazabilir,
**ertelemeli yürütme (deferred execution)** sayesinde sorgularını **yeniden kullanabilir**
ve sonuçları ister anında ister belleğe alarak yönetebilirsin.
