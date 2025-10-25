# Arrays, Listen, Indizierung und Foreach (Teil 13 von 19) | C# für Anfänger

Bu bölümde C#'ta diziler (`T[]`), listeler (`List<T>`), indeksleme, `foreach` kullanımı ve dizilerin çeşitleri (çok boyutlu, jagged) hakkında kısa açıklamalar ve örnekler verilmektedir. İçerik Scott Hanselman & David Fowler videosunun özetine uygundur.

- Dizi (`T[]`) nedir?
	- Açıklama: Sabit uzunluklu, ardışık bellekte saklanan tip güvenli bir koleksiyondur. Oluşturulduktan sonra boyutu değişmez.
	- Örnek:
		- `int[] arr = new int[3]; arr[0] = 10; arr[1] = 20; arr[2] = 30;`
		- Kısa: `var a = new[] {1,2,3};`

- List<T> ile farkları
	- Açıklama: `List<T>` dinamik boyutlu, daha zengin API sağlar. Dizi daha hafif ve sabit boyutlu veri için tercih edilir.
	- Örnek not:
		- `var list = new List<int>{1,2,3}; // list.Add ile büyür`

- İndeksleme ve sınır denetimi
	- Açıklama: Dizi/list elemanına köşeli parantezle erişilir (`arr[i]`). İndeks dışında erişim `IndexOutOfRangeException` fırlatır.
	- Örnek:
		- `int x = arr[0]; // ilk öğe`

- Çok boyutlu diziler
	- Açıklama: Kare veya dikdörtgen şekilli veriler için `[, ]` (multidimensional) diziler kullanılabilir.
	- Örnek:
		- `int[,] matrix = new int[3,3]; matrix[0,1] = 5;`

- Jagged (kırık) diziler
	- Açıklama: İç içe diziler (dizi dizisi). Her iç dizi farklı uzunlukta olabilir.
	- Örnek:
		- `int[][] jagged = new int[2][]; jagged[0] = new int[]{1,2}; jagged[1] = new int[]{3,4,5};`

- `foreach` ile iterasyon
	- Açıklama: Dizi ve koleksiyonları sırayla okumak için temiz ve güvenli yöntemdir. İterasyon sırasında koleksiyonun yapısını değiştirmeyin.
	- Örnek:
		- `foreach (var item in arr) Console.WriteLine(item);`

- `for` ile indeksli iterasyon
	- Açıklama: İndeks veya komşu öğelerle işlem yapmak gerektiğinde `for` uygundur.
	- Örnek:
		- `for (int i = 0; i < arr.Length; i++) Console.WriteLine(arr[i]);`

- Span<T> ve bellek odaklı alternatifler (kısa)
	- Açıklama: Performans/GC azaltma için `Span<T>` ve `Memory<T>` kullanılabilir; özellikle büyük veri ve slice işlemlerinde faydalıdır.

- Sık yapılan hatalar / en iyi uygulamalar
	- Dizi boyutunu değiştirmeye çalışma (dizi sabittir) — `List<T>` kullanın.
	- İndeks sınırlarını kontrol etmeyip `IndexOutOfRangeException` almak.
	- `foreach` içinde koleksiyonu değiştirmeye çalışmak — InvalidOperationException.

- Hızlı örnekler
	- Dizi tanımlama ve yazdırma:
		- `var nums = new[] {10,20,30}; foreach(var n in nums) Console.WriteLine(n);`
	- Çok boyutlu dizi örneği:
		- `int[,] m = { {1,2}, {3,4} }; Console.WriteLine(m[1,0]); // 3`
	- Jagged örnek:
		- `int[][] j = { new[]{1}, new[]{2,3} }; Console.WriteLine(j[1][1]); // 3`

Empfohlene Ressourcen
	- Scott Hanselman & David Fowler — "Arrays and lists" video (10 Nov 2023)
	- Microsoft docs — Arrays, List<T>, Span<T>

Not: Örnekler C# içindir; gerekli namespace'ler: `System`, `System.Collections.Generic`. Bu doküman önceki bölümlerin kısa açıklama + örnekler stilinde hazırlanmıştır.

