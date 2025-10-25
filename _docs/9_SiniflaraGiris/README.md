# C# Sınıflarına Giriş

Bu özet, "Introduction to classes" makalesindeki kavramları kod yazmadan anlatır; yalnızca kısa örnek blokları içerir.

## Referans tipleri ve bellek modeli
- `class` ile tanımlanan her tür **referans tipidir**. Bir değişken `new` ile örnek oluşturulana kadar `null` değerini taşır.
- Nesne oluşturulduğunda managed heap üzerinde yer ayrılır, değişken yalnızca bu konuma işaret eden referansı tutar.
- Bellek geri kazanımı CLR’ın çöp toplayıcısı tarafından otomatik yapılır; geliştirici manuel olarak serbest bırakmaz.

## Sınıf bildirimi
- Sözdizimi: `[erişim belirleyici] class [Ad] { /* üyeler */ }`. Varsayılan erişim `internal`, `public` kullanıldığında herkes örnekleyebilir.
- Sınıf gövdesine alanlar, özellikler, metotlar ve olaylar gibi **üyeler** eklenir. Bir sınıf adı geçerli bir C# tanımlayıcısı olmalıdır.

## Nesne oluşturma
- Bir sınıf türünü somutlamak için `new SınıfAdı()` yazılır; dönen değer oluşturulan nesnenin referansıdır.
- Aynı nesne referansını birden çok değişkene atadığınızda (ör. `var a = new Customer(); var b = a;`) her ikisi de aynı örneği paylaşır; değişiklikler karşılıklı yansır.
- Referans değişkenini nesne oluşturmadan bırakmak (`Customer c;`) mümkündür fakat kullanmadan önce örnek ataması yapılmalıdır; aksi halde çalışma zamanında hata alınır.

## Başlatma stratejileri
- .NET varsayılanları (sayılar için `0`, referanslar için `null`) kullanılabilir ancak çoğunlukla daha anlamlı başlangıç değerleri gerekir.
- **Alan başlatıcıları**: alan tanımında doğrudan değer atayabilirsiniz.
- **Kurucular**: Parametre alan veya almayan kurucular (`public Container(int capacity)`) zorunlu başlangıç verilerini toplar.
- **Birincil kurucular** (C# 12): `public class Container(int capacity) { ... }` biçiminde parametreleri doğrudan sınıf deklarasyonuna yazarsınız.
- **required özellikler**: `public required string FirstName { get; set; }` gibi üyeler, nesne başlatılırken mutlaka set edilmek zorundadır ve nesne başlatıcılarıyla kullanılır (`new Person { FirstName = "Grace", LastName = "Hopper" };`).

## Kalıtım ve sınıf türleri
- Bir sınıf, `:` operatörüyle başka bir sınıftan türeyebilir (`public class Manager : Employee`). Taban sınıfın tüm üyeleri (kurucular hariç) devralınır.
- C# tekil kalıtımı destekler: doğrudan yalnızca bir taban sınıf seçilebilir ancak o taban başka bir sınıftan türeyebilir. Ayrıca sınıflar çoklu arayüzleri (`interface`) aynı anda uygulayabilir.
- **abstract** sınıflar soyut üyeler barındırabilir ve doğrudan örneklenemez; bu üyeler türetilmiş sınıflarda uygulanır. **sealed** sınıflar ise başka sınıfların kendilerinden türemesine izin vermez.

## Kısmi sınıflar
- `partial` anahtar sözcüğüyle bir sınıf tanımı birden çok `.cs` dosyasına bölünebilir. Bu yöntem büyük türlerde ekipler arası iş bölümü sağlamaya yardımcı olur.

## Ek kaynaklar
- [Automatic memory management and garbage collection](https://learn.microsoft.com/dotnet/standard/garbage-collection/)
- [Inheritance](https://learn.microsoft.com/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [Abstract and sealed classes and class members](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/abstract)
- [Partial classes and methods](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/partial)
