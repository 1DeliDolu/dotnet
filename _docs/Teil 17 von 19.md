# LINQ: Methodensyntax vs Abfrageausdruck (Teil 17 von 19) | C# für Anfänger

LINQ sorgularını iki ana şekilde yazabilirsiniz: metot (method) sözdizimi (lambda tabanlı zincirleme çağrılar) ve sorgu (query) sözdizimi (SQL-benzeri `from`/`where`/`select`). Her iki yaklaşım da aynı işlemleri yapabilir; tercih genellikle okunabilirlik ve kullanılacak operatörlerin çeşitliliğine bağlıdır.

Bu belge Scott Hanselman ve David Fowler tarafından verilen videonun ana fikrine dayanır ve C# için basit, Türkçe açıklamalar ile örnekler sunar.

## Kısa karşılaştırma
- Methodensyntax (metot zinciri): numbers.Where(...).Select(...).OrderBy(...)
  - Lambda ifadeleri ile doğrudan ve esnektir.
  - Genelde LINQ operatörlerinin tümünü destekler.
  - Entity Framework gibi sağlayıcılarda ifade ağaçlarına (expression trees) daha doğrudan bağlanır.
- Abfrage (query expression): from x in xs where ... orderby ... select ...
  - SQL benzeri, özellikle uzun veya karmaşık sorgularda daha okunabilir olabilir.
  - Bazı operasyonlar (ör. Zip) için sorgu sözdizimi doğrudan karşılığı yoktur.

## Basit örnek — aynı işi iki şekilde yapmak

Query expression (sorgu sözdizimi):

```csharp
using System;
using System.Linq;

int[] numbers = { 5, 2, 8, 1, 3, 7 };

var query =
    from n in numbers
    where n % 2 == 1
    orderby n
    select n * 2;

foreach (var v in query)
    Console.WriteLine(v); // 2,6,10,14 (1*2,3*2,5*2,7*2 sıralanmış)
```

Method syntax (metot zinciri) eşdeğeri:

```csharp
var method = numbers
    .Where(n => n % 2 == 1)
    .OrderBy(n => n)
    .Select(n => n * 2);

foreach (var v in method)
    Console.WriteLine(v);
```

## Neden biri diğerinden tercih edilir?
- Okunabilirlik: Basit filtreleme ve projeksiyonlarda her iki stil de temizdir; çok aşamalı sorgularda query syntax daha açıklayıcı olabilir.
- Expressiveness: Bazı LINQ operatörleri (ör. `Zip`) sorgu ifadesiyle yazılamaz; bu durumda method syntax gereklidir.
- Sağlayıcı uyumu: Entity Framework gibi sağlayıcılar lambda ifadelerini ifade ağacına (Expression<Func<...>>) dönüştürerek SQL üretir; method syntax burada sıkça kullanılır ama query syntax da derlenince method çağrılarına dönüştüğü için genelde eşdeğerdir.

## Karmaşık örnek: join ve grup

Query expression (join & group):

```csharp
var people = new[] {
    new { Id = 1, Name = "Ayşe" },
    new { Id = 2, Name = "Mehmet" }
};

var pets = new[] {
    new { OwnerId = 1, Pet = "Kedi" },
    new { OwnerId = 1, Pet = "Köpek" },
    new { OwnerId = 2, Pet = "Kuş" }
};

var q =
    from p in people
    join pet in pets on p.Id equals pet.OwnerId
    orderby p.Name
    select new { p.Name, pet.Pet };

// q: Ayşe-Kedi, Ayşe-Köpek, Mehmet-Kuş
```

Eşdeğeri method syntax ile:

```csharp
var m = people
    .Join(pets, p => p.Id, pet => pet.OwnerId,
          (p, pet) => new { p.Name, pet.Pet })
    .OrderBy(x => x.Name);
```

GroupBy örneği (method syntax genellikle daha sık kullanılır):

```csharp
var grouped = pets.GroupBy(p => p.OwnerId)
    .Select(g => new { OwnerId = g.Key, Pets = g.Select(x => x.Pet).ToList() });
```

## Dönüşüm ve `let` kullanımı
- Query syntax içinde `let` ile ara sonuçları adlandırabilir, ardından metot zincirine gerek olmadan kullanabilirsiniz. Metot zincirinde ise ara değişkenler için `Select` içinde anonim tipler veya yerel değişkenler kullanabilirsiniz.

## Deferred execution ve ToList()
- Hem query hem method syntax, IEnumerable üzerinde çalışırken yürütmeyi erteleyebilir. Eğer sorgunun sonucunu hemen elde etmek isterseniz `ToList()` veya `ToArray()` çağırın.

## Performans
- Syntactic olarak her iki stilin çalışma zamanı performansı aynıdır çünkü derlenmiş kod metot çağrılarına dönüşür. Performans farklılığı genellikle sorgunun kendisinden (gereksiz tekrarlar, büyük ara koleksiyonlar) kaynaklanır.

## Küçük ipuçları
- Kısa, tek adımlı seçimlerde method syntax (lambda) daha kısa olabilir.
- Karmaşık filtreleme, birden çok satırdaki hesaplamalar veya SQL-vari düşünce için query syntax okunabilirliği artırır.
- Bir proje içinde stil tutarlılığı önemlidir — takımınızla bir tercih belirleyin.

---
İsterseniz bu örnekleri çalıştırılabilir bir `Program.cs` içine taşıyıp çıktıları doğrulayan küçük testler ekleyebilirim. Hangi örnekleri çalıştırmamı istersiniz? (basit filtre, join, groupby...)
