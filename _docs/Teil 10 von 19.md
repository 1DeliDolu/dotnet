# Verzweigung und While-Schleifen (Teil 10 von 19) | C# für Anfänger

Bu bölümde C#'ta döngülerden özellikle `while` ve `do-while` yapılarından, `for` ile karşılaştırılmasından, `break`/`continue` kullanımından ve sonsuz döngüler/iptal stratejilerinden kısa ve örnekli olarak bahsedilmektedir.

- `while` döngüsü
	- Açıklama: Koşul true olduğu sürece bloğu tekrarlar; koşul döngü başında kontrol edilir.
	- Örnek:
		- `int i = 0; while (i < 5) { Console.WriteLine(i); i++; } // 0..4` 

- `do-while` döngüsü
	- Açıklama: Döngü gövdesi en az bir kez çalışır; koşul gövde çalıştıktan sonra kontrol edilir.
	- Örnek:
		- `int n; do { n = AskUser(); } while (n <= 0);` (en az bir kere sorma)

- `for` vs `while`
	- Açıklama: `for` sayma döngüleri için (başlatma;koşul;arttırma) idealdir; `while` daha genel ve koşula bağlı tekrarlar için uygundur.
	- Örnekler:
		- `for (int i = 0; i < 10; i++) { ... }` 
		- `while (hasNext) { ... } // sayıcı yoksa daha uygun`

- `break` ve `continue`
	- Açıklama: `break` döngüyü sonlandırır; `continue` döngünün sonraki yinelemesine atlar.
	- Örnekler:
		- `for (...) { if (found) break; }`
		- `for (...) { if (!ok) continue; Process(item); }`

- Sonsuz döngüler ve dikkat edilmesi gerekenler
	- Açıklama: `while(true)` yaygın bir yöntemdir; ancak çıkış koşulu ve kaynak yönetimi (CPU, bellek) dikkate alınmalıdır. Sonsuz döngüler genellikle bir `break` veya dışarıdan iptal mekanizması ile sonlandırılır.
	- Örnek:
		- `while (true) { var msg = Dequeue(); if (msg == null) break; Handle(msg); }`

- Döngü iptali ve CancellationToken (uzun çalışan işlerde)
	- Açıklama: Uzun süren veya arka plan görevlerinde `CancellationToken` kullanarak güvenli iptal sağlamak en iyi uygulamadır.
	- Örnek:
		- `while (!token.IsCancellationRequested) { /* iş */ }`

- Döngüde performans notları
	- Açıklama: Ağır işlemler döngü içinde asenkron yapılmalı; mümkünse koleksiyonlar üzerinde `foreach` veya LINQ kullanılabilir. Büyük koleksiyonlarda `for` genelde daha hızlıdır çünkü enumerator yaratılmaz.

- `foreach` ile karşılaştırma
	- Açıklama: `foreach` daha okunaklıdır ve enumerator kullanır; koleksiyonu değiştirmeniz gerekiyorsa `for` kullanın.
	- Örnek:
		- `foreach (var x in list) { Console.WriteLine(x); }`

- Yan etkili operasyonlarda dikkat
	- Açıklama: Döngü içinde IO, ağ veya ağır CPU işlerini doğrudan yapmak UI/performans sorunlarına yol açar; asenkron (async/await) veya arka plan işleme taşımak daha iyidir.

- Hata yapma eğilimleri / en iyi pratikler
	- Döngü değişkenini doğru yerde başlatın ve düzgün artırın/değiştirin.
	- Sonsuz döngülere `Thread.Sleep` veya bekleme/işaretleme (wait handle) ekleyerek CPU kullanımını düşürün (ancak asenkron tasarım tercih edin).
	- Koleksiyon üzerinde iterasyon sırasında koleksiyonu değiştirmeyin (InvalidOperationException riski).

- Örnek: Sayaçla while
	- `int count = 0; while (count < 3) { Console.WriteLine(count); count++; } // 0,1,2`

- Örnek: do-while kullanıcı girdisi
	- `string input; do { input = Console.ReadLine(); } while (string.IsNullOrWhiteSpace(input));`

Not: Örnekler C# içindir; gerekli namespace'ler: `System`, `System.Threading` (CancellationToken) gerektiğinde. Bu doküman önceki bölümlerin üslubunda kısa açıklamalar ve örnekler formatındadır.

