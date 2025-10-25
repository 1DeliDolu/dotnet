# Liste<T> und Sammlungen von Daten (Teil 12 von 19) | C# für Anfänger

Bu bölümde C# ve .NET'te veri koleksiyonlarını yönetmek için en yaygın kullanılan yapı olan `List<T>` ve diğer koleksiyon türleri (Dictionary, Queue, Stack, HashSet vb.) kısa ve örnekli şekilde anlatılmaktadır. Ayrıca `var` ve `new` kısa kullanımına değinilecektir. İçerik Scott Hanselman / David Fowler videosunun pratik konularını ve temel kavramları özetler.

- `List<T>` nedir?
	- Açıklama: Dinamik büyüyen, generic (tip güvenli) bir dizi benzeri koleksiyondur. `System.Collections.Generic` içinde bulunur.
	- Örnek:
		- `var list = new List<int>(); list.Add(1); list.AddRange(new[]{2,3}); int first = list[0]; int count = list.Count;`

- Liste oluşturma yolları
	- Açıklama: Boş liste, başlangıç elemanlarıyla veya kapasite belirterek oluşturabilirsiniz.
	- Örnekler:
		- `var empty = new List<string>();`
		- `var names = new List<string>{ "Ali", "Ayşe" };`
		- `var withCap = new List<int>(100); // başlangıç kapasitesi`

- Yaygın `List<T>` metotları
	- Açıklama: Ekleme, silme, arama, insert ve düzenleme için kullanılır.
	- Örnekler:
		- `list.Add(item); list.AddRange(other); list.Insert(1, value); list.Remove(value); list.RemoveAt(0); list.Clear(); list.Contains(x); list.IndexOf(x); list.Sort();`

- `Count` vs `Capacity`
	- Açıklama: `Count` listedeki gerçek öğe sayısıdır; `Capacity` arka planda tutulan dizi kapasitesidir. Ekleme sırasında kapasite gerektiği gibi artar (kopyalama maliyeti olabilir).

- Dizi (`T[]`) ile farkları
	- Açıklama: Dizi sabit boyutludur; `List<T>` dinamik ve daha rahat API sağlar. Performans kritik ve sabit boyutlu veri için dizi tercih edilebilir.

- `foreach` ve `for` ile iterasyon
	- Açıklama: `foreach` okunaklıdır; `for` indeks gerektiğinde veya performans hassasiyeti varsa tercih edilebilir.
	- Örnek:
		- `foreach(var x in list) Console.WriteLine(x);`

- Diğer koleksiyon tipleri kısa özet
	- `Dictionary<TKey,TValue>`: Anahtar-değer depolama. `TryGetValue` ile güvenli erişim.
		- `var dict = new Dictionary<string,int>(); dict["a"] = 1; dict.TryGetValue("b", out var v);`
	- `Queue<T>`: FIFO (ilk giren ilk çıkar). `Enqueue`/`Dequeue`.
		- `var q = new Queue<string>(); q.Enqueue("m"); var item = q.Dequeue();`
	- `Stack<T>`: LIFO (son giren ilk çıkar). `Push`/`Pop`.
		- `var st = new Stack<int>(); st.Push(1); var top = st.Pop();`
	- `HashSet<T>`: Benzersiz öğeler kümesi, hızlı Contains.
		- `var set = new HashSet<int>{1,2,2}; // set.Count == 2`
	- `SortedList`/`SortedDictionary`, `LinkedList<T>`, `ConcurrentQueue<T>` gibi ihtiyaca göre başka seçenekler de vardır.

- Performans ve bellek notları
	- Açıklama: `List<T>` arka planda dizi kullandığı için orta maliyetli eklemelerde (yeni kapasite gerektiğinde) kopyalama olabilir. Sık insert/remove işlemleri büyük koleksiyonlarda farklı veri yapıları (LinkedList, SortedList) veya özel algoritmalar düşünülmelidir.

- Thread-safety (çoklu iş parçacığı güvenliği)
	- Açıklama: Koleksiyonlar varsayılan olarak thread-safe değildir. Çoklu iş parçacığında kullanılacaksa `ConcurrentBag<T>`, `ConcurrentQueue<T>`, `ConcurrentDictionary<TKey,TValue>` gibi concurrent koleksiyonlar tercih edilmelidir.

- LINQ ve koleksiyonlar
	- Açıklama: Koleksiyonlar üzerinde filtreleme, sıralama, gruplama gibi işlemler için LINQ (System.Linq) kullanılır; sorgular tembel (deferred) veya hemen (ToList/ToArray) olarak yürütülebilir.
	- Örnek:
		- `var evens = list.Where(x => x % 2 == 0); var sorted = list.OrderBy(x => x); var top3 = list.OrderByDescending(x => x).Take(3);`

- `var` ve `new` kısa yazımı
	- Açıklama: C# `var` ile değişken türünü bağlarken sağ taraftaki ifade türünü çıkarır; `new` ile tip tekrar etmeye gerek yoktur.
	- Örnek:
		- `var numbers = new List<int> {1,2,3}; // List<int> olarak infer edilir`

- Hata yapma eğilimleri / en iyi uygulamalar
	- Mutabakat: Koleksiyonu iterasyon ederken aynı koleksiyona öğe eklemeyin veya çıkarmayın.
	- Kapasiteyi önceden biliyorsanız `new List<T>(capacity)` ile başlamak performansı artırır.
	- Büyük koleksiyonlarda LINQ zincirleri belleği etkileyebilir; gerektiğinde `ToList()` ile ara sonuçları kontrol edin.

- Hızlı örnek: Liste ile basit işlem
	- Örnek:
		- `var names = new List<string>{"Ali","Ayşe","Mehmet"}; names.Remove("Ayşe"); Console.WriteLine(names.Count); // 2`

Empfohlene Ressourcen (örnek olarak video referansı)
	- Scott Hanselman & David Fowler — "List<T> and managing collections" video (örnek tarih/serbest özet: 10 Nov 2023)
	- Microsoft docs — Collections and generics (`System.Collections`, `System.Collections.Generic`)

Not: Örnekler C# içindir; gerekli namespace'ler: `System`, `System.Collections.Generic`, `System.Linq`. Bu doküman önceki bölümlerin kısa açıklama + örnekler stilinde hazırlanmıştır.

