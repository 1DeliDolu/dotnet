# C# Discard ( `_` ) Kullanımı Özeti

Bu not, "Discards - C# Fundamentals" makalesindeki ana fikirleri kod örneklerini tekrar etmeden toparlar.

## Discard nedir?
- Discard, `_` adıyla atanan ve bilinçli olarak kullanılmayan sözde değişkendir; derleyiciye sonucu yok saymak istediğinizi anlatır.
- `_` gerçek bir değer tutmadığı için, aynı satırda birden çok sonucu rahatça atabilirsiniz.
- Amaç: okunabilirliği artırmak, gereksiz yerel değişkenler açmadan fonksiyon imzalarını temiz tutmak.

## Tuple ve deconstruction senaryoları
- Şehir bilgisi gibi geniş tuple dönen metotlarda, yalnızca nüfus değişimini önemsediğinizde diğer alanları `_` diyerek pas geçebilirsiniz.
- Kullanıcı tanımlı türlerin `Deconstruct` metodunda da aynı yaklaşım geçerli; örneğin `Person` nesnesinden sadece ad ve şehir değerlerini kullanırken soyadı ve eyalet bilgisini discard edebilirsiniz.

## Pattern matching ve switch ifadeleri
- `obj switch` örneğinde yalnızca `IFormatProvider` uygulayan nesneleri özel mesajla yazdırıp gerisini `_` koluna yönlendirerek “format bilgisi yok” demek mümkün.
- Discard, bu tür switch kollarında “geri kalan her şey” anlamını netleştirir ve exhaustiveness uyarılarını önler.

## `out` parametreleri ve TryParse çağrıları
- `DateTime.TryParse` gibi metotlar başarı/başarısızlık bilgisi yanında ek veri döndürür. Tarihin kendisiyle ilgilenmiyorsanız, `out` parametresini `_` olarak işaretleyip yalnızca boolean sonucu kullanabilirsiniz.
- Bu sayede gereksiz yerel değişkenler veya isim bulma derdi olmaz; okuyan kişi değeri bilerek attığınızı görür.

## Standalone discard kullanımları
- Null kontrolü zorunlu olsun diye `_ = arg ?? throw ...` kalıbı, dönüş değerini kullanmaksızın parametre doğrulaması yapar.
- Asenkron metotlarda `_ = Task.Run(...)` ifadesi, dönen `Task`'ı kasıtlı olarak izlemediğinizi belirtip CS4014 uyarısını sessize alır.

## `_` ismiyle ilgili dikkatler
- `_` hâlihazırda kapsamda gerçek bir değişkense, discard olarak kullanmak değerleri yanlışlıkla değiştirmenize veya tip uyumsuzluk hatalarına yol açabilir.
- Bu nedenle, projede `_` adını normal değişken olarak kullanmaktan kaçının; aksi durumda derleyici eşitlemeleri gerçek ata¬malar olarak yorumlar.

## Ne zaman tercih etmeli?
- Bir API, gereksinim duymadığınız döndürülen bilgiler sağlıyorsa veya pattern matching içinde az sayıda kural dışında tüm durumları tek satırda kapatmak istiyorsanız.
- Ekip içinde niyet iletişimi önemlidir: `_` gördüğünüzde değerin bilinçli olarak yok sayıldığını anlarsınız.
- Discard’lar performansa etki etmez; asıl kazanç, daha kısa ve amacına odaklı kod yazmaktır.

## Ek kaynaklar
- [Discards in C#](https://learn.microsoft.com/dotnet/csharp/fundamentals/functional/discards)
- [Tuples and deconstruction](https://learn.microsoft.com/dotnet/csharp/fundamentals/functional/deconstruct)
- [Pattern matching basics](https://learn.microsoft.com/dotnet/csharp/fundamentals/functional/pattern-matching)
