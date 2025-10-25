# Sortieren und Durchsuchen von Listen (Teil 14 von 19) | C# für Anfänger

Bu bölümde C#'ta listeleri nasıl sıralayacağınız, yerinde (in-place) sıralama ile yeni sıralı koleksiyon oluşturma arasındaki fark, özel karşılaştırıcılar, `IComparable`/`IComparer`, ikili arama (binary search) ve arama metodları (`Find`, `FindAll`, `Contains`) kısa ve örnekli olarak açıklanmıştır.

- Temel: `List<T>.Sort()`
	- Açıklama: `List<T>.Sort()` listedeki öğeleri yerinde (in-place) sıralar ve `Count` içinde değişiklik yapmaz. Genel olarak O(n log n) zaman karmaşıklığı vardır.
	- Örnek:
		- `var numbers = new List<int>{3,1,2}; numbers.Sort(); // artık [1,2,3]`

- `Sort` vs `OrderBy`
	- Açıklama: `List<T>.Sort()` yerinde değişiklik yapar (aynı listeyi sıralar). `Enumerable.OrderBy()` bir sıralama sorgusu döndürür; sonuçları almak için `ToList()` ile yeni bir liste oluşturabilirsiniz. `OrderBy` LINQ zinciri içinde daha okunaklıdır ve sıralamayı koruyan (stable) davranış sağlar.
	- Örnek:
		- `var sorted = list.OrderBy(x => x.Prop).ToList(); // yeni liste`

- Özel karşılaştırma: `Comparison<T>` ve `IComparer<T>`
	- Açıklama: Farklı sıralama kuralları için `Sort`'a delegate (`Comparison<T>`) veya `IComparer<T>` sağlayabilirsiniz.
	- Örnekler:
		- `list.Sort((a,b) => a.Length - b.Length); // uzunluğa göre` 
		- `list.Sort(new MyComparer()); // IComparer<T> implement eden sınıf`

- `IComparable<T>` ile doğal sıra
	- Açıklama: Kendi sınıfınız için `IComparable<T>` uygulayarak `Sort()`'un varsayılan davranışını belirleyebilirsiniz.
	- Örnek:
		- `class Person : IComparable<Person> { public int Age; public int CompareTo(Person? other) => Age.CompareTo(other?.Age); }`

- String sıralama ve `StringComparer`
	- Açıklama: Kültüre duyarlı veya duyarsız karşılaştırma için `StringComparer.CurrentCulture`, `OrdinalIgnoreCase` gibi hazır karşılaştırıcıları kullanın.
	- Örnek:
		- `names.Sort(StringComparer.OrdinalIgnoreCase);`

- İkili arama (BinarySearch)
	- Açıklama: `List<T>.BinarySearch(item)` sıralanmış listelerde hızlı arama sağlar (logaritmik zaman). Arama yapmadan önce liste mutlaka sıralanmış olmalıdır; aksi halde sonuçlar anlamlı olmayabilir.
	- Örnek:
		- `numbers.Sort(); int idx = numbers.BinarySearch(2); // idx >= 0 ise bulundu, değilse negative`

- `Find`, `FindAll`, `FindIndex`, `Contains` ve LINQ
	- Açıklama: `Find`/`FindAll` bir koşula uyan öğeleri bulur; `Contains` doğrudan eşitlik arar; LINQ (`FirstOrDefault`, `Where`) daha esnek sorgular sağlar.
	- Örnekler:
		- `var p = people.Find(p => p.Name == "Ali");`
		- `var matches = list.Where(x => x > 10).ToList();`

- Sıralama garantileri ve kararlı (stable) sıralama
	- Açıklama: `OrderBy` LINQ sıralamaları eşit anahtarlar için önceki düzeni koruyacak şekilde davranır (stable). `List<T>.Sort()` yerinde sıralama için varsayılan davranış performans odaklıdır; eşit anahtarların göreli sırası garanti edilmeyebilir. Eğer birden fazla anahtarla sıralama gerekiyorsa önce `ThenBy` veya `ThenByDescending` kullanın veya `Comparison` içinde çoklu anahtar karşılaştırması uygulayın.

- Performans ipuçları
	- Açıklama: Sıralama genelde O(n log n) maliyetlidir; büyük veri kümelerinde maliyeti göz önünde bulundurun. Sık sık yeniden sıralama gerekiyorsa farklı veri yapıları (örn. `SortedSet<T>`, `SortedDictionary`) veya önceden sıralı tutulmuş yapı kullanmayı düşünün.

- Örnek: Özelleştirilmiş sınıf ve sıralama
	- Örnek:
		- `class Item { public string Name; public int Price; }
		   var items = new List<Item>{...};
		   // Fiyata göre sırala:
		   items.Sort((a,b) => a.Price.CompareTo(b.Price));
		   // veya LINQ ile yeni liste:
		   var sorted = items.OrderBy(i => i.Price).ThenBy(i => i.Name).ToList();`

- Arama örneği: BinarySearch kullanımı
	- Örnek:
		- `var numbers = new List<int>{1,3,5,7}; int i = numbers.BinarySearch(5); // i == 2`

- Hata yapma eğilimleri / en iyi uygulamalar
	- Bir liste üzerinde BinarySearch çağırmadan önce mutlaka sıralayın.
	- Eğer öğelerin göreli sırasını korumak istiyorsanız `OrderBy` / `ThenBy` veya stabil bir algoritma kullanın.
	- Çoklu anahtar sıralama için `ThenBy` veya karşılaştırıcı içinde çoklu kontrol uygulayın.

Not: Örnekler C# içindir; gerekli namespace'ler: `System`, `System.Collections.Generic`, `System.Linq`. Bu doküman önceki bölümlerin kısa açıklamalar + örnekler stilinde hazırlanmıştır.

