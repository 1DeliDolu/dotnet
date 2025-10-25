# C# Nesneleri: Tür Örnekleri Oluşturma

Bu belge, "Objects - create instances of types" makalesini kısa notlar ve örneklerle özetler.

## Sınıf vs. struct örnekleri
- `class` referans tiptir; değişken nesnenin adresine işaret eder. Aynı referansı paylaşan her iki değişken de aynı örneği temsil eder.

```csharp
var person1 = new Person("Leopold", 6);
var person2 = person1;    // aynı referans
person2.Name = "Molly";   // person1.Name de değişir
```

- `struct` değer tiptir; kopya semantiğiyle çalışır. Atama yeni bir kopya oluşturur.

```csharp
PersonStruct p1 = new("Alex", 9);
PersonStruct p2 = p1;  // p1’in kopyası
p2.Name = "Spencer";  // p1 etkilenmez
```

- Sınıf örnekleri heap üzerinde, struct örnekleri genellikle stack üzerinde tahsis edilir; CLR, heap tahsis/de-tahsis işlemlerini optimize eder.

## Bellek yönetimi
- Sınıf nesneleri için bellek, tüm referanslar scope dışına çıktığında GC tarafından geri kazanılır.
- Struct’lar scope bittiğinde otomatik olarak stack’ten temizlenir; bu yüzden kopyalama semantiği uygulanır.

## Nesne kimliği vs. değer eşitliği
- **Kimlik (identity)**: `object.ReferenceEquals(a, b)`  iki referansın aynı nesneye işaret edip etmediğini kontrol eder.
- **Değer eşitliği**: varsayılan olarak struct’larda `ValueType.Equals` alanları karşılaştırır; sınıflarda anlamlı sonuç için `Equals`/`==` aşırı yüklenmeli veya `IEquatable<T>` uygulanmalıdır.
- Record türleri referans tipi olmalarına rağmen değer semantiği sağlar.

```csharp
var p1 = new PersonStruct("Wallace", 75);
var p2 = new PersonStruct("Wallace", 75);
Console.WriteLine(p1.Equals(p2)); // true
```

## Nesne oluşturma yöntemleri
- `new` operatörü çoğu senaryoda gereklidir; struct’lar için opsiyoneldir (alanlar ayrı ayrı atanabilir), fakat kurucusu varsa çağırmak gerekir.
- Object initializer: `var person = new Person { Name = "Ada", Age = 28 };`
- Koleksiyon veya dizilerde de anonim/strong typelar saklanabilir.

## Tasarım notları
- Sınıflar ve struct’lar, `Equals` (ve mümkünse `GetHashCode`) yöntemlerini türün mantığına göre yeniden tanımlamalıdır.
- Dış gren sınırlarında anonim tip taşımak yerine adlandırılmış türler tercih edilir.

## Daha fazla okuma
- [new operator](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/new-operator)
- [Value equality for structs](https://learn.microsoft.com/dotnet/standard/design-guidelines/value-equality)
- [Garbage Collection](https://learn.microsoft.com/dotnet/standard/garbage-collection/)
