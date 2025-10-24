# Lernpfad: Einfache .NET-Anwendung

1. [Record-Typen in C#](1_RecordTypes/README.md)
2. [String ve Text](2_StringVeText/README.md)
3. [Sayılar ve Numerik Türler](3_NumericTypes/README.md)
4. [Şartlar ve Döngüler](4_SartlarVeDonguler/README.md)
5. [List Koleksiyonları](5_ListCollections/README.md)
6. [C# Programlarının Genel Yapısı](6_CSharpGenelYapi/README.md)
7. [C# Tip Sistemi](7_TypeSystem/README.md)
8. [Namespaces ile Türleri Düzenleme](8_Namespaces/README.md)
9. [C# Sınıflarına Giriş](9_SiniflaraGiris/README.md)
10. [Record Türlerine Giriş](10_RecordTypesIntro/README.md)
11. [Arayüzlerle Davranış Tanımlama](11_InterfaceGiris/README.md)
12. [Generic Sınıf ve Metotlar](12_Generics/README.md)
13. [Anonymous Tipler](13_AnonimTipler/README.md)
14. [Nesne Yönelimli Teknikler Genel Bakış](14_OOPGenelBakis/README.md)
15. [Nesnelerle Çalışmak](15_Nesneler/README.md)
16. [Kalıtım Ile Uzmanlaşma](16_Kalitim/README.md)
17. [Pattern Matching ile Akış Tasarlama](17_PatternMatching/README.md)
18. [Discards ile Gürültüyü Azaltma](18_Discards/README.md)

## TODO.md'deki Pattern Matching Notları

`TODO.md` şu an desen eşleştirme (pattern matching) turuna ayrılmış durumda. Makale, `is` ve `switch` ifadelerinin aynı anda hem tür kontrolü hem de değişken bildirimi yapabildiğini; bu sayede null kontrolleri veya interface doğrulamaları sırasında fazladan cast/if bloklarına ihtiyaç kalmadığını vurguluyor. Nullable sayılar ve opsiyonel mesaj metinleri örneklerinde, desen eşleştirme sayesinde değişkenlerin yalnızca güvenli kapsamda erişilebilir olduğuna dikkat çekiliyor; `not` gibi mantıksal desenlerle null olmayan durumları ifade etmek daha okunaklı hâle geliyor.

Devamında, koleksiyon türlerini tanıyıp özel algoritmalar seçebilmek için tür desenleri ve `switch` ifadeleri anlatılıyor. `IList<T>` uygulayan diziler listesinden tam ortadaki öğeyi bulma senaryosu, pattern matching'in hem null koruması hem de farklı çalışma zamanı türlerine özel davranışlar yazma açısından nasıl avantaj sağladığını gösteriyor. Aynı yaklaşım, enum ya da metin tabanlı komut kümelerinde ilk eşleşen desene göre metod çağrısı yaparken de kullanılıyor; kapsanmayan durumları yakalamak için discard deseninin şart olduğu hatırlatılıyor.

İlişkisel ve özellik desenleri bölümünde, sipariş sayısı ve maliyeti gibi birden fazla property'yi tek koşulda sınayarak farklı indirim oranları hesaplanıyor. Aynı mantık, `Order` tipinin deconstructor desteği varsa konumsal desenlere taşınabiliyor; böylece property adlarını tekrarlamadan değerlerin sırasına göre eşleştirme yapılabiliyor. Nesnelerin belirli alanlarının yalnızca null olup olmadığını kontrol etmek için `{ }` gibi “non-null” desenlerinin yeterli olduğu belirtiliyor.

Makalenin son kısmı liste desenlerine ayrılmış; farklı kolon sayıları olan CSV bankacılık kayıtlarını inceleyip, işlem türüne göre bakiyeyi güncelleyen örnek üzerinde duruluyor. Dizi içerisindeki belirli alanlara ulaşmak, gereksiz elemanları `_` ile yoksaymak ya da `..` dilimiyle esnek uzunluktaki bölümleri kapsamak gibi tekniklerle, düzensiz veri satırlarını dönüştürmeden yorumlayabileceğiniz anlatılıyor. Özetle, TODO.md; null güvenliğinden gelişmiş `switch` ifadelerine, liste şekli kontrolünden deconstruction’a kadar tüm güncel C# desenlerini kuramsal anlatımlar ve sözel örneklerle toparlıyor.

## WSL 2 ile çalıştırma

Visual Studio'da WSL üzerinden hata ayıklayabilmek için `TODO.md` dosyasındaki adımları takip edin. Özetle:
- Visual Studio'da **.NET Debugging with WSL** bileşeninin yüklü olduğundan emin olun ve WSL dağıtımınızı hazırlayın.
- `Readme.sln` çözümünü açtıktan sonra `DotnetPlayground` projesi için `WSL` profillerinden birini seçin; `Properties/launchSettings.json` içerisinde varsayılan, Ubuntu 20.04 ve Debian profilleri hazır.
- Konsol uygulaması kullanıcı girdisi gerektiriyorsa, WSL terminalinde `dotnet run --project DotnetPlayground.csproj` komutunu çalıştırarak giriş akışına (stdin) erişebilirsiniz.

### WSL içinde Windows'taki `dotnet`'i kullanmak

WSL Ubuntu ortamında ek paket kurmadan Windows tarafındaki .NET SDK'yı kullanmak için:
1. WSL terminalinizde proje kökünde `scripts/wsl/enable-windows-dotnet.sh` çalıştırın.
2. Sonrasında `source ~/.bashrc` komutuyla güncel ortam değişkenlerini yükleyin (veya yeni bir shell açın).
3. Artık WSL içinde doğrudan `dotnet run` komutunu kullanabilirsiniz; çağrı, Windows'taki `/mnt/c/Program Files/dotnet/dotnet.exe` üzerinden çalışır.
