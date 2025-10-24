# C# Anonymous Tiplerine Giriş

Bu özet, "Anonymous types" makalesinde geçen kavramları açıklama ve örneklerle öne çıkarır; kodlar yalnızca referans amaçlıdır.

## Temel fikir
- `new { ... }` sözdizimiyle adını belirtmeden, derleyicinin oluşturduğu okuma amaçlı özellikler içeren bir referans tipi oluşturursunuz.
- Özellik tipleri ifade üzerinden çıkarılır; nesnenin gerçek tipi derleyici tarafından adlandırılır ve kaynak kodda erişilemez.

```csharp
var v = new { Amount = 108, Message = "Hello" };
Console.WriteLine(v.Amount + v.Message); // Amount:int, Message:string
```

## Kullanım alanları
- En sık LINQ sorgularının `select` kısmında, bir veri kümesinden yalnızca gereken alanları taşımak için kullanılır.
- Sınırlamalar: yalnızca public read-only özellikler tanımlanabilir; metot, event vb. üyeler ya da `null`/lambda/pointer ifadeleri başlangıç değeri olamaz.

## Projection initializer
- Yerel değişken adlarını doğrudan kullanarak isimleri otomatik çıkarabilirsiniz.

```csharp
var firstName = "Ada";
var lastName = "Lovelace";
var person = new { firstName, lastName }; // Üye adları firstName/lastName
```

- Eğer aday ad geçersizse veya aynı isim daha önce tanımlandıysa adları açıkça vermeniz gerekir.

## İç içe anonim nesneler
- Özellik değerleri başka sınıflar ya da anonim tipler olabilir:

```csharp
var product = new Product();
var bonus = new { note = "You won!" };
var shipment = new { address = "Nowhere", product, bonus };
```

- Anonim tipler çoğunlukla `var` ile bildirilen yerel değişkenlerde tutulur. Derlenen tip adı kullanılamayacağı için alan, parametre, dönüş tipi gibi imzalarda anonim tip kullanılması önerilmez.

## Diziler ve with ifadeleri
- `var anonArray = new[] { new { name = "apple", diam = 4 }, new { name = "grape", diam = 1 } };`
- C# 10 itibarıyla `with` ifadesi anonim tiplerde de desteklenir; özellik değerlerini değiştirmeden yeni örnek türetir.

```csharp
var apple = new { Item = "apples", Price = 1.35M };
var discounted = apple with { Price = 0.79M };
```

## Eşitlik, erişim ve ToString
- İki anonim nesne aynı derleme içinde aynı özellik isim/sıra/tip kombinasyonuyla tanımlandıysa derleyici onları aynı tip kabul eder.
- `Equals`/`GetHashCode` özellik değerlerine göre çalışır; farklı assembly’lerde oluşturulan benzer yapılar eşit sayılmaz.
- `ToString()` otomatik olarak `{ Prop = Value, ... }` biçiminde bir çıktı üretir.

## Ne zaman kaçınılmalı?
- Bir yöntemden geri döndürmeniz, alan/properties olarak saklamanız veya sınırlar arasında geçirmeniz gerekiyorsa güçlü tipli `record/class/struct` tercih edin; aksi halde tür adı erişilemeyeceği için bakımı zorlaşır.
