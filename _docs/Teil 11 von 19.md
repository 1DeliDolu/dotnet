# Für Schleifen (Teil 11 von 19) | C# für Anfänger

Bu bölümde C#'ta `for` döngüleri, `foreach`, iç içe döngüler, koleksiyon ve dizi iterasyonu, indeks ve performans notları kısa açıklama ve örneklerle anlatılmaktadır.

- Temel `for` döngüsü
	- Açıklama: Sayaç tabanlı tekrarlar için kullanılır. Başlatma; koşul; artırma/azaltma biçimindedir.
	- Örnek:
		- `for (int i = 0; i < 5; i++) { Console.WriteLine(i); } // 0..4`

- `foreach` (okunaklı ve güvenli)
	- Açıklama: Koleksiyonun her öğesi için işlem yapar; indeks gerekmediğinde tercih edilir. Koleksiyon üzerinde değişiklik yapılmasına izin vermez (InvalidOperationException riskine dikkat).
	- Örnek:
		- `foreach (var item in list) { Console.WriteLine(item); }`

- Diziler ve koleksiyonlarda indeks kullanım örneği
	- Açıklama: İndeks gerektiğinde `for` ile iterasyon yapılır; örneğin komşu öğeler üzerinde işlem.
	- Örnek:
		- `var arr = new[] {1,2,3,4}; for (int i = 0; i < arr.Length - 1; i++) { Console.WriteLine(arr[i] + arr[i+1]); }`

- İç içe (nested) döngüler
	- Açıklama: Matris, kartesyen çarpım gibi durumlarda iç içe `for` kullanılır; karmaşıklık O(n*m) olur, dikkatli kullanılmalı.
	- Örnek:
		- `for (int r = 0; r < rows; r++) { for (int c = 0; c < cols; c++) { Console.WriteLine(matrix[r][c]); } }`

- Geriye dönük iterasyon
	- Açıklama: Silme işlemleri veya belirli düzenlemeler için geriye doğru `for` kullanmak güvenlidir.
	- Örnek:
		- `for (int i = list.Count - 1; i >= 0; i--) { if (ShouldRemove(list[i])) list.RemoveAt(i); }`

- `for` vs `foreach` performans
	- Açıklama: `foreach` daha okunaklıdır; ancak çok yüksek performans gereken sıcak döngülerde `for` diziler için biraz daha hızlı olabilir (özellikle value-type öğeler için). Çoğu durumda fark önemsizdir; önce okunaklılığı düşünün.

- Döngü kontrol: `break`, `continue`
	- Açıklama: `break` döngüyü sonlandırır; `continue` döngüdeki sonraki yinelemeye atlar.
	- Örnek:
		- `for (...) { if (found) break; if (!ok) continue; /* işlem */ }`

- Sonsuz döngü (`for (;;)` ve `while(true)`) kullanımı
	- Açıklama: `for (;;)` kısa bir sonsuz döngü yazımıdır; çıkış mekanizması (break/cancellation) mutlaka düşünülmelidir.

- LINQ ile iterasyon (defered execution)
	- Açıklama: LINQ sorguları tembel yürütülür (deferred); `foreach` ile tüketildiğinde çalışır. Ağır işlemler veya yan etkiler LINQ içinde dikkatle ele alınmalıdır.
	- Örnek:
		- `var evens = numbers.Where(n => n % 2 == 0); foreach (var x in evens) Console.WriteLine(x);`

- Koleksiyon değiştirirken dikkat
	- Açıklama: Bir koleksiyonu iterasyon sırasında değiştirmek genelde hata verir; kaldırma gerekiyorsa geriye doğru indeksle silme veya ayrı bir listeye ekleyip sonra işlem yapın.

- Örnekler: kısa kod parçacıkları
	- Basit `for`:
		- `for (int i = 0; i < 3; i++) Console.WriteLine(i); // 0,1,2`
	- `foreach` ile listeyi yazdırma:
		- `var list = new List<string>{"a","b","c"}; foreach(var s in list) Console.WriteLine(s);`

Not: Örnekler C# içindir; gerekli namespace'ler: `System`, `System.Collections.Generic`, `System.Linq` gerektiğinde. Bu doküman önceki bölümlerin üslubunda kısa açıklamalar ve örnekler formatındadır.

