# C# Pattern Matching Özeti

Bu not, "Pattern matching overview" makalesindeki kavramları kod kopyalamadan toparlar.

## Neden pattern matching?
- `is` ve `switch` ifadeleri, aynı satırda tür kontrolü yapıp güvenli şekilde yeni bir değişken bildirme imkânı sunar.
- Null güvenliği yükselir: nullable türler veya referanslar için fazladan `== null` mantığı yazmadan yalnızca geçerli değerleri işler, geri kalan durumları derleyici uyarılarıyla yakalarsınız.
- Açık cast gerektirmediği için aşırı yüklenmiş `==` operatörlerinden etkilenmez; böylece beklenmedik karşılaştırma sonuçları önlenir.

## Null ve tür kontrolleri
- Declaration pattern sayesinde nullable sayı örneği gibi değerleri kontrol ederken aynı anda yerel bir değişken üretirsiniz; değişken yalnızca if bloğunun true kolunda erişilebilir.
- `is not null` kalıbı, önce değeri doğrulayıp ardından çıktı üretme gibi basit senaryolarda daha okunaklıdır.
- `IList<T>` uygulayan koleksiyonları seçip ortadaki öğeyi döndürme senaryosunda olduğu gibi, tür kontrolü ve null koruması tek ifade ile yapılabilir.

## Sabit ve enum değerleriyle karar verme
- Enum tabanlı komutlarda `switch` ifadesi ilk eşleşen deseni çalıştırarak ilgili operasyonu çağırır; yakalama kolu (`_`) ekleyerek hatalı girdilerde açık hata mesajı verebilirsiniz.
- Aynı yaklaşımı metin komutları için kullanabilir, örneğin "Start" veya "Reset" gibi dizelere göre davranışı belirleyebilirsiniz.
- Diskard deseni (`_`) kapsanmayan durumları işlemek için zorunludur; aksi durumda derleyici tüm girdilerin ele alınmadığı konusunda uyarır.

## Özellik, ilişkisel ve konumsal desenler
- Sipariş adedi ve toplam tutarı gibi çoklu property’leri tek armdaki ilişkisellerle (örn. `> 10`, `> 1000`) birleştirerek indirim yüzdesi hesaplayabilirsiniz.
- Aynı `Order` türü bir `Deconstruct` metodu sunuyorsa, konumsal desenlerle property adlarını tekrarlamadan değer sırasına göre eşleşme yapabilirsiniz.
- `{ }` kalıbı, belirli bir property’nin yalnızca null olmayan değer taşıdığını doğrulamak için yeterlidir; örneğin gözlem kaydındaki açıklama alanının dolu olup olmadığını kontrol etmek gibi.

## Liste desenleri
- CSV bankacılık kayıtlarında satır uzunlukları ve kolon düzenleri tutarsız olsa bile, liste desenleri ile belirli konumlardaki alanları seçebilirsiniz.
- Discard (`_`) ve slice (`..`) kalıpları istenmeyen veya değişken sayıdaki kolonları atlamanıza izin verir; `var amount` gibi yakalama desenleri ise ihtiyaç duyulan alanı yeni değişkene bağlar.
- Bu yaklaşım, veri satırlarını nesne modellerine dönüştürmeden doğrudan şekillerine göre doğrulama yapmanızı sağlar.

## Tasarım ipuçları ve kaynaklar
- Desen eşleştirmeyi, null kontrolleri ve tür dönüşümleri manuel if/else bloklarına dönüştükçe tercih edin; kod daha kısa ve niyetini daha net ifade eder.
- `switch` ifadelerinde her olası girdiyi planlamak, çalışma zamanındaki beklenmedik değerlerin yakalanmasını kolaylaştırır.
- Kisiye özel algoritmaları yazarken önce girdinin şekline dair varsayımları desenlerle doğrulayın, ardından iş mantığını çalıştırın.
- Daha fazla detay için: [Pattern matching in C#](https://learn.microsoft.com/dotnet/csharp/fundamentals/functional/pattern-matching)
