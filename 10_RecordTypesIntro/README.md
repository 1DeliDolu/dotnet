# C# Kayıt (record) Türlerine Giriş

Bu özet, "Introduction to record types in C#" makalesinde anlatılan kavramları açıklayıcı notlar ve kısa örneklerle derler.

## Record nedir?
- `record` anahtar sözcüğüyle tanımlanan sınıflar veya yapılar, veri modeli odaklı senaryolar için özel eşitlik ve `ToString()` davranışları üretir.
- Derleyici, değer eşitliğini (`==`, `Equals`), biçimlenmiş `ToString` çıktısını ve positional kayıtlar için `Deconstruct` yöntemini otomatik olarak üretir.

## Ne zaman record kullanmalı?
- Türünüzün **değer eşitliği** semantiğine sahip olmasını istiyorsanız.
- **Değişmez (immutable)** veri modelleriyle çalışıyorsanız.
- Not: Entity Framework gibi referans eşitliğine ihtiyaç duyan altyapılarda record uygun olmayabilir.

## Değer eşitliği
- İki record örneği, tipleri aynı ve tüm alan/özellik değerleri eşit olduğunda eşit kabul edilir.
- Referans türü olan sıradan sınıflarda varsayılan davranış referans eşitliğidir; records bu davranışı otomatik olarak değiştirir.

```csharp
public record Person(string FirstName, string LastName, string[] Phones);

var phones = new string[2];
var p1 = new Person("Nancy", "Davolio", phones);
var p2 = new Person("Nancy", "Davolio", phones);
Console.WriteLine(p1 == p2);              // True
Console.WriteLine(ReferenceEquals(p1, p2)); // False
```

## İmmutability ve with ifadeleri
- Positional record’lar varsayılan olarak `init` erişimli özellikler üretir; `with` ifadesi mevcut örneğin kopyasını alıp belirttiğiniz özellikleri değiştirir.

```csharp
Person person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[1] };
Person person2 = person1 with { FirstName = "John" };
// person2 mevcut alanları kopyalar, yalnızca FirstName değişir.
```

- Hesaplanan (computed) özellikler, `with` ile klonlanan örneklerde tutarlılık için erişim anında hesaplanmalıdır; aksi takdirde kayıt yerine sınıf tercih edin.

## Record sınıf mı struct mı?
- `record class` (veya sadece `record`) referans tiptir; yalnızca başka bir record’dan kalıtım alabilir ve ondan türetilebilir.
- `record struct` değer tiptir; derleyici eşitlik üyeleri ve `ToString` çıktısını üretir, positional sürümlerde otomatik `Deconstruct` eklenir.

## Primary constructor ve init-only özellikler
- Record sınıflarında positional parametreler için `public init` özellikler otomatik oluşur.
- Record struct için `public` getter/setter oluşturulur.
- Bu özellikler `with` kullanımı ve nesne başlatıcılarıyla uyumludur.

## Yekpare örnek
```csharp
public record Person(string FirstName, string LastName)
{
    public required string[] PhoneNumbers { get; init; }
}

Person p1 = new("Nancy", "Davolio") { PhoneNumbers = new string[1] };
Person p2 = p1 with { FirstName = "John" };
Person p3 = p1 with { };
Console.WriteLine(p1 == p3); // True
Console.WriteLine(p1 == p2); // False
```

## Kaynaklar
- [Records (C# reference)](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/record)
- [With expressions](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/with-expression)
