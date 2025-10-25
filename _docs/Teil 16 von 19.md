# LINQ-Abfrageausdrücke: from, where, orderby, select (Teil 16 von 19) | C# für Anfänger

C# için LINQ sorgu ifadeleri (Query Expressions) veri kaynaklarını daha okunabilir bir sorgu-sözdizimiyle filtrelemek, sıralamak ve dönüştürmek için kullanılır. Aşağıda temel anahtar kelimeler olan `from`, `where`, `orderby` ve `select`'in nasıl kullanıldığına dair kısa açıklamalar ve örnekler (Türkçe) bulunmaktadır.

## Kısa özet
- `from` — veri kaynağını ve sorguda kullanılacak öğe adını tanımlar.
- `where` — öğeleri filtreler (koşul doğruysa dahil eder).
- `orderby` — sonuçları bir veya birden fazla anahtara göre sıralar (varsayılan artan). `descending` ile azalttığınız belirtirsiniz.
- `select` — sonuç olarak hangi değeri veya yapıyı döndüreceğinizi belirtir (projeksiyon).

> Not: LINQ sorgu ifadeleri, derleme zamanında yöntem çağrılarına (metot sözdizimi — `Where`, `Select`, `OrderBy`) dönüştürülür. Sorgu söz dizimi genellikle daha okunaklıdır; fakat karmaşık dönüşümler için metot zincirleri kullanılabilir.

## Basit örnek — sayılar

```csharp
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 5, 2, 8, 1, 3, 7 };

        // Sorgu sözdizimi (query expression)
        var smallSorted =
            from n in numbers
            where n < 6        // filtre
            orderby n ascending // artan
            select n;           // projeksiyon

        foreach (var n in smallSorted)
            Console.WriteLine(n); // 1,2,3,5
    }
}
```

Eşdeğeri metot zinciriyle:

```csharp
var smallSorted = numbers
    .Where(n => n < 6)
    .OrderBy(n => n)
    .Select(n => n);
```

## Projeksiyon — anonim tipler

```csharp
var people = new[] {
    new { Name = "Ayşe", Age = 30 },
    new { Name = "Mehmet", Age = 22 },
    new { Name = "Fatma", Age = 40 }
};

var result =
    from p in people
    where p.Age >= 25
    orderby p.Name
    select new { p.Name, p.Age };

// result, Name ve Age içeren anonim tipleri döndürür
```

## Birden çok sıralama anahtarı

```csharp
var items = new[] {
    new { A = 1, B = 2 },
    new { A = 1, B = 1 },
    new { A = 2, B = 0 }
};

var sorted =
    from it in items
    orderby it.A, it.B descending
    select it;

// Önce A artan, sonra B azalan olarak sıralanır.
```

## `let` ile ara hesaplama

`let` anahtarı sorguda ara hesaplamaları isimlendirmenizi sağlar:

```csharp
var words = new[] { "apple", "banana", "pear" };

var q =
    from w in words
    let len = w.Length
    where len >= 5
    select new { Word = w, Length = len };
```

## Performans ve davranış notları
- Sorgu ifadeleri, genelde `IEnumerable<T>` üzerinde çalışır; yürütme (execution) geciktirilebilir (deferred). Sonucu bir koleksiyona almak isterseniz `ToList()` veya `ToArray()` çağırın.
- Sorgu sözdizimi, metot zincirlerine dönüştüğü için tüm LINQ operatörleri kullanılabilir (Join, GroupBy, SelectMany vs.).
- Karmaşık dönüşümler veya performans ihtiyaçları için metot sözdizimi bazen daha doğrudan ve okunabilir olabilir.

## Küçük ipucu
- Sorguyu debug ederken sorgu oluşumunu çağırıp sonucu hemen görebilmek için `ToList()` kullanın.
- `orderby`'de `ascending` (varsayılan) veya `descending` kullanabilirsiniz.

---
Bu doküman Scott Hanselman ve David Fowler tarafından hazırlanan video serisindeki "LINQ query expressions" konusunu temel alır. İsterseniz aynı örnekleri çalıştırılabilir bir konsol projesine dönüştürebilir ve her örnek için beklenen çıktıların testlerini ekleyebilirim.
