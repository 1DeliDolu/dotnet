# Zahlen, Genauigkeit, Guss, Doppel ve daha fazlası (Teil 8 von 19) | C# für Anfänger

Bu bölümde C#'ta sayılarda hassasiyet (precision), tür dönüşümleri (casting/guss), `float`/`double`/`decimal` farkları, yuvarlama davranışları ve sık yapılan hatalar kısa ve örnekli bir şekilde anlatılmaktadır.

- Temel kavramlar: hassasiyet ve aralık
	- Açıklama: "Hassasiyet" bir sayının kaç ondalık basamağa doğru saklandığını / hesaplandığını; "aralık" ise tipin saklayabildiği en küçük ve en büyük değerleri ifade eder.
	- Örnekler:
		- `float` (≈7 ondalık basamak doğruluk, 32-bit)
		- `double` (≈15-17 ondalık basamak doğruluk, 64-bit)
		- `decimal` (≈28-29 ondalık basamak doğruluk, 128-bit, finansal işlemler için)

- Hangi tür ne zaman?
	- Açıklama: Bilimsel hesaplarda ve performansta `double` sık kullanılır. Para-benzzeri (finansal) hesaplarda `decimal` tercih edilir. `float` daha nadir kullanılır; bellek/perf gereksinimi varsa tercih edilebilir.
	- Örnekler:
		- `double x = 0.1;`
		- `decimal price = 19.95m;`

- Ondalık kesirlerin temsili ve beklenmeyen sonuçlar
	- Açıklama: Kayan nokta (binary floating point) türleri bazı ondalık sayıların tam temsiline izin vermez; bu yüzden 0.1 gibi sayılar tam olarak saklanmaz ve küçük farklar ortaya çıkar.
	- Örnek:
		- `Console.WriteLine(0.1 + 0.2 == 0.3); // genellikle false (double)`
		- Açıklama: 0.1 ve 0.2'nin ikili gösterimleri toplandığında 0.3'in tam karşılığı elde edilmeyebilir.

- `decimal` bu durumda daha öngörülebilirdir
	- Örnek:
		- `Console.WriteLine(0.1m + 0.2m == 0.3m); // true (decimal)`

- Tür dönüşümleri (casting) ve kayıp
	- Açıklama: kayan nokta -> tamsayı dönüşümlerinde kesir kısmı atılır; açık cast gerekir ve veri kaybı oluşabilir.
	- Örnek:
		- `double d = 3.9; int i = (int)d; // i == 3`
		- `int j = 5; double dd = j; // implicit: dd == 5.0`

- Sayı taşması (overflow) ve kontrol
	- Açıklama: Tamsayı işlemlerinde limit aşıldığında taşma olur; `checked` bloğunda `OverflowException` fırlatılabilir. Kayan noktalarda overflow genellikle `Infinity` ile sonuçlanır.
	- Örnek:
		- `int x = int.MaxValue; var y = checked(x + 1); // OverflowException`
		- `double big = double.MaxValue * 2; // Infinity`

- Yuvarlama davranışları
	- Açıklama: `Math.Round` varsayılan olarak "banker's rounding" (ToEven) kullanır. Yuvarlama davranışını belirtmek için `MidpointRounding` kullanılabilir.
	- Örnekler:
		- `Math.Round(2.5); // 2 (to even)`
		- `Math.Round(3.5); // 4`
		- `Math.Round(2.5, MidpointRounding.AwayFromZero); // 3`

- Formatlama ve çıktıda yuvarlama
	- Açıklama: Görüntüleme amacıyla `ToString` formatları yuvarlama yapar ancak arka plandaki değer değişmez.
	- Örnek:
		- `double v = 1.23456; v.ToString("F2"); // "1.23"` (görüntü 2 ondalık, gerçek değer değişmez)

- Karşılaştırma: epsilon (yaklaşık eşitlik)
	- Açıklama: Kayan nokta değerlerini doğrudan `==` ile karşılaştırmak güvenli değildir; genelde bir tolerans (epsilon) ile karşılaştırma yapılır.
	- Örnek:
		- `bool AlmostEqual(double a, double b, double eps = 1e-12) => Math.Abs(a - b) <= eps;`

- Karışık tip işlemleri (promotion)
	- Açıklama: Operatörler farklı tiplere uygulanırsa C# otomatik tür yükseltmesi (promotion) yapar; örneğin `int + double` -> `double`.
	- Örnek:
		- `int a = 5; double b = 2.0; var c = a + b; // c is double (7.0)`

- Performans ve bellek notları
	- Açıklama: `double` genelde `decimal`'den daha hızlıdır ve daha az yer kaplar; `decimal` daha ağırdır çünkü ondalık tabanlı yüksek doğruluk sağlar.

- Kısa ipuçları / sık yapılan hatalar
	- 0.1 gibi ondalıkların double ile tam saklanamayacağını unutmayın.
	- Finansal/para hesaplarında `decimal` kullanın.
	- Yuvarlama politikasına dikkat edin (banker's vs away-from-zero).
	- Kayan nokta karşılaştırmalarında tolerans (epsilon) kullanın.

- Hızlı örnekler
	- Ondalık hatası örneği (double):
		- `Console.WriteLine(0.1 + 0.2); // 0.30000000000000004 gibi bir çıktı`
	- Decimal doğru örneği:
		- `Console.WriteLine(0.1m + 0.2m); // 0.3`
	- Yuvarlama örneği:
		- `Console.WriteLine(Math.Round(2.345, 2)); // 2.35 (to even davranışı burada 2.35 verir)`

Not: Örnekler C# içindir; gerekli namespace'ler: `System`, `System.Math` (kök fonksiyonlar), `System.Linq` (koleksiyon işlemleri) gerektiğinde. Bu doküman `Teil-4-von-19.md` üslubunda kısa açıklamalar ve örnekler formatındadır.

