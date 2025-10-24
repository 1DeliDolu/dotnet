# C# Nesne Yönelimli Tekniklere Genel Bakış

Bu belge, "Overview of object oriented techniques in C#" makalesindeki ana başlıkları hızlıca özetler. Kod örnekleri açıklama amaçlıdır.

## Tip tanımı ve nesneler
- C#’ta `class`, `struct` ve `record` birer şablondur; bellekte ayrılan blok (nesne) bu şablona göre yapılandırılır.
- Nesneler alanlar, özellikler ve metotlarla davranış/ veri kapsülasyonu sağlar.

## Kapsülleme ve erişilebilirlik
- Üyeleri dış dünyadan gizlemek için erişim belirleyiciler: `public`, `protected`, `internal`, `protected internal`, `private`, `private protected`.
- Kapsülleme, hataları ve kötüye kullanımı azaltır; gereksiz API yüzeyini gizler.

## Üye türleri
- Tüm alanlar, sabitler, özellikler, metotlar, kurucular, olaylar, yıkıcılar, indexer’lar, operatör aşırı yüklemeleri ve iç içe tipler bir türün üyesi sayılır.
- Global fonksiyonlar yoktur; `Main` bile sınıf/struct (veya üst düzey ifade) içinde tanımlanır.

## Kalıtım ve arayüzler
- Yalnızca sınıflar tekli kalıtım destekler (`class Derived : Base`). `abstract` sınıflar eksik uygulama bırakabilir; `sealed` kalıtımı engeller.
- Türler birden fazla interface’i uygulayarak davranış paylaşabilir; struct ve record’lar için bu mekanizma kritik önemdedir.

## Generic ve static tipler
- `List<T>` gibi tip parametreli türler, yeniden kullanılabilir ve tip güvenli veri yapıları sunar.
- `static` sınıflar yalnızca static üyeler içerir ve örneklenemez; fakat herhangi bir tür static üyeler barındırabilir.

## Diğer dil özellikleri
- **Record**: Değer eşitliği, `with` ifadeleri ve otomatik `ToString` ile veri modellerini sadeleştirir.
- **Partial**: Büyük türleri birden fazla dosyaya ayırmanızı sağlar.
- **Nested types**: Bir türü başka bir tür içinde kapsülleyerek kapsamı sınırlandırabilirsiniz.
- **Object initializer**: `var obj = new Person { Name = "Ada" };` biçiminde nesneyi oluştururken özellikleri set etmenizi sağlar.
- **Anonymous types**: Hızlı veri taşıyıcılar için adlandırılmamış sınıflar (`new { Color = "Red", Price = 10m }`).
- **Extension methods**: Statik bir sınıf üzerinden başka türlere sanki üye metotmuş gibi yeni davranışlar eklersiniz.
- **Implicitly typed locals (`var`)**: Derleyicinin tip çıkarmasına izin verir, ancak statik olarak tip belirlemeye devam eder.

## Özet
- Nesne yönelimli yaklaşım kapsülleme, kalıtım, polimorfizm ve soyutlama etrafında döner; C# bu kavramları zengin dil özellikleriyle destekler.
- Makalenin devamında nesnelerle çalışma detaylandırılır; bu belge tiplerin nasıl tanımlandığı ve hangi araçları sunduğuna odaklanır.
