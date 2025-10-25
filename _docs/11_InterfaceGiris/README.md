# C# Arayüzlerine (Interface) Giriş

Bu döküm, "Interfaces - define behavior for multiple types" makalesindeki başlıkları özetler; yalnızca kavramsal açıklamalar ve örnekler içerir.

## Arayüz kavramı
- `interface` bir grup ilişkili davranışın sözleşmesini tanımlar; soyut olmayan sınıflar veya struct’lar bu sözleşmeyi **uygulamakla yükümlüdür**.
- C# birden fazla sınıf kalıtımını desteklemediği için, çoklu davranış paylaşımı için arayüzler kritik öneme sahiptir; ayrıca struct’lar başka struct/class’tan türeyemediğinden, kalıtım benzeri yapı yalnızca interface ile sağlanır.

## Bildirim sözdizimi ve isimlendirme
```csharp
interface IEquatable<T>
{
    bool Equals(T obj);
}
```
- İsimler geçerli C# tanımlayıcısı olmalıdır; konvansiyon gereği büyük `I` harfiyle başlar (örn. `IDisposable`).
- Arayüzler örnek alan (field) içeremez; ancak metot, özellik, olay ve indexer bildirebilir. Ayrıca sabitler, static üyeler, varsayılan implementasyonlar ve C# 11 ile `static abstract` üyeler tanımlanabilir.

## Üyeleri uygulamak
- **İmplicit implementasyon**: Sınıf üyeleri `public`, non-static ve aynı imzaya sahip olmalıdır.
- **Explicit implementasyon**: Arayüz üyeleri `InterfaceName.Member` biçiminde uygulanır; özellikle iç (internal) türleri açığa sermek istemediğinizde veya erişimi kısıtlamak istediğinizde kullanılır.
- Bir sınıf/struct, varsayılan gövdeli olmayan tüm üyeler için implementasyon sağlamalıdır; fakat taban sınıf zaten implement ettiyse türetilmiş sınıf bu davranışı miras alır.

## Erişilebilirlik ve varsayılan implementasyonlar
- Interface üyeleri varsayılan olarak `public` kabul edilir; C# 8.0 ve sonrası erişim belirleyicileri (public, private, protected internal vb.) ve **default interface methods** destekler.
- `private` interface üyesi belirlerseniz mutlaka varsayılan bir gövde sağlamalısınız.
- Statik üyeler tür bazında ayrı kabul edilir; arabirimdeki statik üyeler override edilmez, her tip kendi statik sürümünü tanımlar.

## İç (internal) interface senaryoları
Aşağıdaki örnekte `InternalConfiguration` tipi internal olduğu için arayüzü implicit uygulamak mümkün değildir:

```csharp
internal interface IConfigurable
{
    void Configure(InternalConfiguration config);
}

public class ServiceImplementation : IConfigurable
{
    void IConfigurable.Configure(InternalConfiguration config)
    {
        Console.WriteLine($"Configured with: {config.Setting}");
    }
}
```
- `ILogging` gibi yalnızca public türler kullanan internal arayüzler, public üyelerle implicit uygulanabilir.

## Kalıtım ve bileşim
- Arayüzler başka arayüzlerden **çoklu kalıtım** alabilir. Bir sınıf türetilmiş bir arayüzü uyguladığında, tabanlarının tamamındaki üyeleri de implement etmek zorundadır.
- Bir sınıf arayüzü dolaylı olarak birden fazla yoldan (taban sınıflar ya da diğer arayüzlerin kalıtımı) elde edebilir; ancak aynı sözleşme yalnızca bir kez uygulanır. Taban sınıf already implement ettiyse, türetilmiş sınıf `virtual` üyeleri override ederek davranışı değiştirebilir.
- Varsayılan implementasyon tanımlanmışsa, sınıf arayüz referansı üzerinden bu davranışı doğrudan kullanabilir.

## Özet
- Arayüzler çoklu davranış paylaşımı için ve struct’larda sözleşme tanımlamak için kullanılır.
- C# 8.0 öncesinde tüm üyeler soyuttu; yeni sürümlerde varsayılan gövdeli üyeler, statik abstract üyeler ve erişim belirleyicileri desteklenir.
- Arayüzler doğrudan örneklenemez; bir sınıf ya da struct aynı anda bir base class’tan kalıtım alabilir ve birçok arayüz uygulayabilir.

## Daha fazla okuma
- [default interface methods](https://learn.microsoft.com/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods)
- [Explicit Interface Implementation](https://learn.microsoft.com/dotnet/csharp/programming-guide/interfaces/explicit-interface-implementation)
- [Polymorphism](https://learn.microsoft.com/dotnet/csharp/fundamentals/object-oriented/polymorphism)
