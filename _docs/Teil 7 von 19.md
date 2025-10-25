# Zahlen, Ganze Zahlen und Mathematik

Aşağıda C#'ta sayılar, tam sayılar ve matematikle ilgili sık kullanılan türler, operatörler ve yöntembilgileri (metotlar) kısa açıklamalar ve örneklerle verilmektedir.

- Sayı türleri (kısa bakış)
	- Açıklama: C#'ta farklı doğruluk ve aralık gereksinimleri için çeşitli sayısal türler vardır.
	- Örnekler:
		- `int` (32-bit, tam sayı)
		- `long` (64-bit, tam sayı)
		- `short` (16-bit, tam sayı)
		- `byte` / `sbyte` (8-bit)
		- `float` (32-bit kayan nokta)
		- `double` (64-bit kayan nokta)
		- `decimal` (yüksek doğruluk, finansal hesaplar için)

- Literaller ve tür sonekleri
	- Açıklama: Sayı yazarken türü belirtmek için sonek kullanılabilir.
	- Örnek: `1` (int), `1L` (long), `3.14f` (float), `3.14m` (decimal)

- Aritmetik operatörler
	- Açıklama: Temel operatörler +, -, *, /, % geçerlidir. Tam sayılarla bölme tam sayı sonucu verir; kayan nokta ile kayan nokta sonucu alırsınız.
	- Örnekler:
		- `int a = 7 / 2; // 3`
		- `double b = 7.0 / 2; // 3.5`
		- `int r = 7 % 2; // 1` (kalan)

- Bölme ve yuvarlama davranışı
	- Açıklama: Tam sayılar arasında bölme sonucu kesir kısmı atılır. Yuvarlama için `Math` sınıfı kullanılır.
	- Örnekler:
		- `int q = 10 / 4; // 2`
		- `double d = 10.0 / 4.0; // 2.5`
		- `Math.Floor(2.7); // 2.0`
		- `Math.Ceiling(2.1); // 3.0`
		- `Math.Round(2.5); // 2 (varsayılan: banker's rounding)

- Tür dönüşümleri (casting)
	- Açıklama: Veri kaybını önlemek veya özel davranış almak için açık veya örtük dönüşümler kullanılır.
	- Örnekler:
		- `int i = (int)3.9; // 3` (explicit cast)
		- `double x = 5; // implicit cast from int to double`

- Checked / unchecked ve taşma (overflow)
	- Açıklama: Tam sayı taşmaları varsayılan olarak unchecked olabilir; `checked` anahtar sözcüğü taşma durumunda `OverflowException` fırlatır.
	- Örnek:
		- `int max = int.MaxValue; int v = checked(max + 1); // OverflowException`

- `Math` sınıfı (System.Math)
	- Açıklama: Yaygın matematiksel fonksiyonları sağlar.
	- Örnekler:
		- `Math.Abs(-5); // 5`
		- `Math.Pow(2, 3); // 8.0`
		- `Math.Sqrt(16); // 4.0`
		- `Math.Log(10); // doğal logaritma`

- `decimal` vs `double` seçim rehberi
	- Açıklama: Finansal veya yüksek doğruluk gerektiren hesaplar için `decimal`, bilimsel hesaplar için `double` tercih edilir.
	- Örnek: `decimal price = 19.95m;`

- BigInteger (çok büyük tam sayılar)
	- Açıklama: Çok büyük veya sınırsız tamsayı gereksinimleri için `System.Numerics.BigInteger` kullanın.
	- Örnek:
		- `using System.Numerics; BigInteger big = BigInteger.Pow(2, 100);`

- Random sayı üretimi
	- Açıklama: `Random` sınıfı ile pseudo-rastgele sayılar oluşturulur. Kriptografik güvenlik gerekiyorsa `RandomNumberGenerator` kullanın.
	- Örnekler:
		- `var rnd = new Random(); int n = rnd.Next(1, 101); // 1..100 arası` 
		- `double v = rnd.NextDouble(); // 0.0 <= v < 1.0`

- Formatlama ve gösterim
	- Açıklama: Sayıları string'e döndürürken format belirteçleri kullanabilirsiniz.
	- Örnekler:
		- `double pi = Math.PI; pi.ToString("F2"); // "3.14"` (sabit ondalık)
		- `12345.678.ToString("N2"); // "12,345.68" (kültüre göre)`
		- `price.ToString("C"); // para birimi biçimi (kültüre bağlı)`

- Performans ve doğruluk ipuçları
	- Açıklama: Kayan nokta hesaplarda doğruluk beklentilerini bilmek önemlidir; finansal hesaplarda `decimal` tercih edin. Çok sayıda küçük işlemler koleksiyonları etkileyebilir; mümkünse toplu hesaplarda algoritma optimizasyonu yapın.

- Küçük örnek: toplam, ortalama, medyan
	- Açıklama: Basit istatistik hesapları nasıl yapılır.
	- Örnek:
		- `int[] arr = {1,2,3,4,5}; int sum = arr.Sum(); double avg = arr.Average();`
		- Medyan için: `var sorted = arr.OrderBy(x => x).ToArray(); var median = sorted[sorted.Length/2];`

Not: Örnekler C# içindir; gerekli namespace'ler: `System`, `System.Linq` (gerektiğinde), `System.Numerics` (BigInteger) ve `System.Security.Cryptography` (güvenli rastgele sayı üretimi gerektiğinde).

