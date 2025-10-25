✨ **C#’ta LINQ’u Destekleyen Özellikler**
📅 *25 Nisan 2024*

---

### 🧩 **Sorgu İfadeleri (Query Expressions)**

Sorgu ifadeleri, **SQL** veya **XQuery**’ye benzer **bildirimsel (declarative)** bir sözdizimi kullanır.
Derleme zamanında bu sözdizimi, **LINQ sağlayıcısının standart sorgu yöntemlerini** çağıran metotlara dönüştürülür.

💡 Örnek:

```csharp
var query = from str in stringArray
            group str by str[0] into stringGroup
            orderby stringGroup.Key
            select stringGroup;
```

---

### 🧠 **Dolaylı Tip Atama (Implicitly Typed Variables - var)**

`var` anahtar sözcüğü derleyicinin tipi **otomatik olarak çıkarmasını** sağlar.
Bu değişkenler **güçlü tipli (strongly typed)** olmaya devam ederler.

```csharp
var number = 5;
var name = "Virginia";
var query = from str in stringArray
            where str[0] == 'm'
            select str;
```

---

### 🧱 **Nesne ve Koleksiyon Başlatıcıları (Object and Collection Initializers)**

Bu özellik, **yeni nesneleri kurucu çağırmadan** başlatmayı sağlar.

```csharp
var cust = new Customer { Name = "Mike", Phone = "555-1212" };
```

🔹 LINQ içinde veri kaynaklarından yeni nesneler oluşturmak için kullanılır:

```csharp
var newLargeOrderCustomers =
    from o in IncomingOrders
    where o.OrderSize > 5
    select new Customer { Name = o.Name, Phone = o.Phone };
```

💬 Aynı sorgunun **metot sözdizimiyle** yazılmış hali:

```csharp
var newLargeOrderCustomers = 
    IncomingOrders
        .Where(x => x.OrderSize > 5)
        .Select(y => new Customer { Name = y.Name, Phone = y.Phone });
```

---

### 🧩 **Anonim Tipler (Anonymous Types)**

Yeni bir sınıf tanımlamadan **geçici veri grupları** oluşturmanı sağlar.

```csharp
select new { name = cust.Name, phone = cust.Phone };
```

📘 *C# 7’den itibaren* tuple’lar da anonim tipler gibi kullanılabilir.

---

### ⚙️ **Genişletme Metotları (Extension Methods)**

Statik metotların, var olan tiplere **yeni davranış eklemesini** sağlar.
LINQ’un tüm standart sorgu operatörleri (`Where`, `Select`, `GroupBy`, vb.) bu yöntemlerle tanımlanır.

---

### 🔁 **Lambda İfadeleri (Lambda Expressions)**

Lambda ifadeleri, **anonim fonksiyonlardır** ve LINQ operatörleriyle doğrudan kullanılabilirler.

```csharp
x => x.OrderSize > 5
```

---

### 🧮 **Veri Olarak İfadeler (Expressions as Data)**

Sorgular **bileşebilir (composable)** nesnelerdir; yani bir sorgu nesnesi başka bir metottan döndürülebilir, değiştirilebilir veya genişletilebilir.

```csharp
IEnumerable<string> QueryMethod1(int[] ints) =>
    from i in ints
    where i > 4
    select i.ToString();

void QueryMethod2(int[] ints, out IEnumerable<string> returnQ) =>
    returnQ = from i in ints
              where i < 4
              select i.ToString();
```

📋 **Kullanımı:**

```csharp
int[] nums = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

// 1️⃣ QueryMethod1'in dönüşünü değişkende tutmak
var myQuery1 = QueryMethod1(nums);

foreach (var s in myQuery1)
{
    Console.WriteLine(s);
}

// 2️⃣ Doğrudan çağırmak
foreach (var s in QueryMethod1(nums))
{
    Console.WriteLine(s);
}

// 3️⃣ out parametreyle almak
QueryMethod2(nums, out IEnumerable<string> myQuery2);
foreach (var s in myQuery2)
{
    Console.WriteLine(s);
}

// 4️⃣ Sorguyu yeniden biçimlendirmek (query composition)
myQuery1 = from item in myQuery1
           orderby item descending
           select item;

Console.WriteLine("\nResults of executing modified myQuery1:");
foreach (var s in myQuery1)
{
    Console.WriteLine(s);
}
```

---

💡 **Özetle:**
LINQ’un gücünü sağlayan başlıca C# özellikleri:

* 🧩 Sorgu ifadeleri
* 🧠 `var` ile dolaylı tip atama
* 🧱 Nesne & koleksiyon başlatıcıları
* 🧩 Anonim tipler
* ⚙️ Genişletme metotları
* 🔁 Lambda ifadeleri
* 🧮 Sorgu bileşimi (composable queries)

---

Tek bütün kod olarak 👇

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public int OrderSize { get; set; }
}

public class Program
{
    public static void Main()
    {
        string[] stringArray = { "mike", "mary", "john", "matt", "lisa" };

        var query = from str in stringArray
                    group str by str[0] into stringGroup
                    orderby stringGroup.Key
                    select stringGroup;

        foreach (var group in query)
        {
            Console.WriteLine($"Group {group.Key}:");
            foreach (var name in group)
                Console.WriteLine($"  {name}");
        }

        var cust = new Customer { Name = "Mike", Phone = "555-1212" };

        var IncomingOrders = new List<Customer>
        {
            new Customer { Name = "Alice", Phone = "111-1111", OrderSize = 3 },
            new Customer { Name = "Bob", Phone = "222-2222", OrderSize = 7 },
            new Customer { Name = "Charlie", Phone = "333-3333", OrderSize = 9 }
        };

        var newLargeOrderCustomers = 
            IncomingOrders
                .Where(x => x.OrderSize > 5)
                .Select(y => new Customer { Name = y.Name, Phone = y.Phone });

        foreach (var c in newLargeOrderCustomers)
            Console.WriteLine($"New Customer: {c.Name}, {c.Phone}");

        int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        IEnumerable<string> QueryMethod1(int[] ints) =>
            from i in ints
            where i > 4
            select i.ToString();

        void QueryMethod2(int[] ints, out IEnumerable<string> returnQ) =>
            returnQ = from i in ints
                      where i < 4
                      select i.ToString();

        var myQuery1 = QueryMethod1(nums);
        foreach (var s in myQuery1)
            Console.WriteLine(s);

        QueryMethod2(nums, out IEnumerable<string> myQuery2);
        foreach (var s in myQuery2)
            Console.WriteLine(s);

        myQuery1 = from item in myQuery1
                   orderby item descending
                   select item;

        Console.WriteLine("\nModified myQuery1:");
        foreach (var s in myQuery1)
            Console.WriteLine(s);
    }
}
```
