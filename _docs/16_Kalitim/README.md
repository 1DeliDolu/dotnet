# C# Kalıtım (Inheritance) Özeti

Bu not, "Inheritance - derive types to create more specialized behavior" makalesindeki ana kavramları özetler.

## Temel kavram
- Kalıtım, yeni bir sınıfın (türemiş sınıf) başka bir sınıfın (taban sınıf) üyelerini devralarak davranışı genişletmesini sağlar.
- C# tekli kalıtımı destekler: her sınıfın yalnızca bir doğrudan taban sınıfı olabilir; ancak bu zincir transittir (`ClassC : ClassB : ClassA`).
- Struct’lar kalıtım desteklemez fakat interface uygulayabilir.

## Taban sınıftan devralınanlar
- Kurucular ve finalizer’lar hariç tüm public/protected/internal üyeler devralınır.
- Türemiş sınıf ek özellik/metot ekleyebilir ya da taban sınıftaki `virtual` üyeleri override edebilir.

## Örnek senaryo
- `WorkItem` taban sınıfı, iş öğesi temsil eder; `ChangeRequest` sınıfı aynı üyeleri devralıp ek alanlar (ör. `originalItemID`) tanımlar.
- Taban sınıf `ToString()` metodunu override ettiğinde, türemiş sınıf bu davranışı otomatik alır.

## Abstract ve virtual üyeler
- `virtual` üyeler isteğe bağlı override edilebilir.
- `abstract` üyeler ise türemiş sınıfta zorunlu olarak uygulanmalıdır; bu üyeleri içeren sınıf `abstract` olarak işaretlenir.
- Polimorfizmin temeli, aynı taban referansından farklı türemiş sınıf implementasyonlarının çağrılabilmesidir.

## Arayüzlerle ilişki
- Interface’ler sınıf/struct’ların uygulaması gereken sözleşmeleri tanımlar; bir sınıf birden çok interface’i uygulayabilir.
- Default interface metotları ile ortak implementasyon sağlanabilir.

## Kalıtımı sınırlamak
- `sealed` sınıflar veya `sealed override` üyeler daha fazla türetilmeyi engeller.
- `new` anahtar sözcüğüyle taban sınıftaki üyeleri gizleyebilirsiniz; override ile karıştırmamak için dikkatli kullanılmalıdır.

## Tasarım ipuçları
- "is-a" ilişkisi net değilse kalıtım yerine kompozisyon veya interface tercih edin.
- Taban sınıfın parametresiz kurucusu yoksa, türemiş sınıf `base(...)` çağrısıyla uygun kurucuyu seçmelidir.

## Kaynaklar
- [Polymorphism](https://learn.microsoft.com/dotnet/csharp/fundamentals/object-oriented/polymorphism)
- [Interfaces](https://learn.microsoft.com/dotnet/csharp/fundamentals/types/interfaces)
- [sealed keyword](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/sealed)
