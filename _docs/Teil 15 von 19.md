# Language Integrated Query (LINQ) und IEnumerable (Teil 15 von 19) | C# für Anfänger

Bu bölümde LINQ'un ne olduğu, `IEnumerable`/`IQueryable` farkları, sorgu (query) ifadesi vs fluent (method) sözdizimi, gecikmeli (deferred) ve hemen (immediate) yürütme, sık kullanılan LINQ operatörleri ve küçük örneklerle açıklamalar yer almaktadır. İçerik Scott Hanselman & David Fowler videosunun ana noktalarını özetler.

- LINQ nedir?
	- Açıklama: LINQ (Language Integrated Query) C# içinde koleksiyonlara, veri kaynaklarına ve sorgulamalara ortak bir sözdizimi sağlar. Hem query-expression (SQL-benzeri) hem de method-chain (Where/Select) biçimleri vardır.
	- Örnek (method syntax): `var evens = numbers.Where(n => n % 2 == 0).Select(n => n * 2);`
	- Örnek (query syntax): `var q = from n in numbers where n % 2 == 0 select n * 2;`

- `IEnumerable<T>` vs `IQueryable<T>`
	- Açıklama: `IEnumerable<T>` genellikle bellekteki koleksiyonlar (LINQ-to-Objects) için; sorgu C# tarafında yürütülür. `IQueryable<T>` sorguyu sağlayıcıya (ör. EF Core) dönüştürür ve sorgu genelde veri kaynağında (örn. SQL) çalıştırılır.
	- Not: `IQueryable` ile yapılan sorguların veritabanı tarafında verimli çalışması için dönüşüm (translation) önemlidir.

- Gecikmeli (deferred) vs hemen (immediate) yürütme
	- Açıklama: Çoğu LINQ operatörü (Where, Select, OrderBy) gecikmeli çalışır; yani enumerasyonu gerçekleştirdiğinizde (`foreach`, `ToList()`, `Count()`) sorgu yürütülür. `ToList()`, `ToArray()`, `Count()`, `First()` gibi çağrılar hemen yürütür.
	- Örnek:
		- `var q = items.Where(...); // henüz çalışmadı
		   var list = q.ToList(); // burada yürütme yapılır` 

- Yaygın LINQ operatörleri (kısa)
	- Filter: `Where(predicate)`
	- Projection: `Select(selector)`
	- Ordering: `OrderBy`, `OrderByDescending`, `ThenBy`
	- Grouping: `GroupBy(key)`
	- Joining: `Join` / `GroupJoin`
	- Quantifiers: `Any`, `All`
	- Element: `First`, `FirstOrDefault`, `Single`, `SingleOrDefault`, `Last`
	- Aggregation: `Count`, `Sum`, `Min`, `Max`, `Average`, `Aggregate`
	- Partitioning: `Skip`, `Take`, `TakeWhile`, `SkipWhile`

    
| Standard query operator | Return type | Immediate execution | Deferred streaming execution | Deferred nonstreaming execution |
|------------------------|-------------|---------------------|------------------------------|---------------------------------|
| Aggregate              | TSource     | ✓                   |                              |                                 |
| All                    | Boolean     | ✓                   |                              |                                 |
| Any                    | Boolean     | ✓                   |                              |                                 |
| AsEnumerable           | IEnumerable<T> |                   | ✓                            |                                 |
| Average                | Single numeric value | ✓          |                              |                                 |
| Cast                   | IEnumerable<T> |                   | ✓                            |                                 |
| Concat                 | IEnumerable<T> |                   | ✓                            |                                 |
| Contains               | Boolean     | ✓                   |                              |                                 |
| Count                  | Int32       | ✓                   |                              |                                 |
| DefaultIfEmpty         | IEnumerable<T> |                   | ✓                            |                                 |
| Distinct               | IEnumerable<T> |                   | ✓                            |                                 |
| ElementAt              | TSource     | ✓                   |                              |                                 |
| ElementAtOrDefault     | TSource?    | ✓                   |                              |                                 |
| Empty                  | IEnumerable<T> | ✓                 |                              |                                 |
| Except                 | IEnumerable<T> |                   | ✓                            | ✓                               |
| First                  | TSource     | ✓                   |                              |                                 |
| FirstOrDefault         | TSource?    | ✓                   |                              |                                 |
| GroupBy                | IEnumerable<T> |                   |                              | ✓                               |
| GroupJoin              | IEnumerable<T> |                   | ✓                            | ✓                               |
| Intersect              | IEnumerable<T> |                   | ✓                            | ✓                               |
| Join                   | IEnumerable<T> |                   | ✓                            | ✓                               |
| Last                   | TSource     | ✓                   |                              |                                 |
| LastOrDefault          | TSource?    | ✓                   |                              |                                 |
| LongCount              | Int64       | ✓                   |                              |                                 |
| Max                    | Single numeric value, TSource, or TResult? | ✓ |                 |                                 |
| Min                    | Single numeric value, TSource, or TResult? | ✓ |                 |                                 |
| OfType                 | IEnumerable<T> |                   | ✓                            |                                 |
| OrderBy                | IOrderedEnumerable<TElement> |       |                              | ✓                               |
| OrderByDescending      | IOrderedEnumerable<TElement> |       |                              | ✓                               |
| Range                  | IEnumerable<T> |                   | ✓                            |                                 |
| Repeat                 | IEnumerable<T> |                   | ✓                            |                                 |
| Reverse                | IEnumerable<T> |                   |                              | ✓                               |
| Select                 | IEnumerable<T> |                   | ✓                            |                                 |
| SelectMany             | IEnumerable<T> |                   | ✓                            |                                 |
| SequenceEqual          | Boolean     | ✓                   |                              |                                 |
| Single                 | TSource     | ✓                   |                              |                                 |
| SingleOrDefault        | TSource?    | ✓                   |                              |                                 |
| Skip                   | IEnumerable<T> |                   | ✓                            |                                 |
| SkipWhile              | IEnumerable<T> |                   | ✓                            |                                 |
| Sum                    | Single numeric value | ✓           |                              |                                 |
| Take                   | IEnumerable<T> |                   | ✓                            |                                 |
| TakeWhile              | IEnumerable<T> |                   | ✓                            |                                 |
| ThenBy                 | IOrderedEnumerable<TElement> |      |                              | ✓                               |
| ThenByDescending       | IOrderedEnumerable<TElement> |      |                              | ✓                               |
| ToArray                | TSource[] array | ✓               |                              |                                 |
| ToDictionary           | Dictionary<TKey,TValue> | ✓        |                              |                                 |
| ToList                 | IList<T>    | ✓                   |                              |                                 |
| ToLookup               | ILookup<TKey,TElement> | ✓         |                              |                                 |
| Union                  | IEnumerable<T> |                   | ✓                            |                                 |
| Where                  | IEnumerable<T> |                   | ✓                            |                                 |

- Query expression vs method chain
	- Açıklama: İkisi aynı işi yapar; query syntax bazı karmaşık grup ve join işlemlerinde daha okunaklı olabilir, method syntax ise extension metodlarla daha sık kullanılır.
	- Örnek (aynı işi yapan iki yazım):
		- `var q1 = from p in people where p.Age > 18 select p.Name;`
		- `var q2 = people.Where(p => p.Age > 18).Select(p => p.Name);`

- Örnek: deferred execution ve yan etkiler
	- Açıklama: Sorgu oluşturup sonra veri değişirse yürütme zamanında yeni veri kullanılır; bu bazı durumlarda beklenmeyen sonuçlara yol açar.
	- Örnek:
		- `var q = nums.Where(n => n % 2 == 0);
		   nums.Add(6);
		   foreach(var n in q) Console.WriteLine(n); // 6 da dahil olabilir` 

- Performans & bellek notları
	- Açıklama: LINQ temiz ve kısa kod sağlar ancak bazı karmaşık LINQ zincirleri gereksiz ara koleksiyonlar veya tekrar enumerasyonlar üretebilir. Büyük verilerde `ToList()` ile ara sonuç almak, `IQueryable` ile veritabanında filtreleyip sadece gerekli alanları çekmek önemlidir.

- Defered multiple enumeration (çoklu enumerasyon)
	- Açıklama: Aynı `IEnumerable`'i birden çok kez enumerate etmek maliyetli olabilir; gerekiyorsa `ToList()` ile sonuçları önbelleğe alın.

- Yield return: özelleştirilmiş iteratorlar
	- Açıklama: `yield return` ile kolayca `IEnumerable<T>` döndüren iterator metotları yazabilirsiniz; bu da yine gecikmeli yürütme sağlar.
	- Örnek:
		- `IEnumerable<int> Range(int n) { for(int i=0;i<n;i++) yield return i; }`

- LINQ to Objects vs LINQ to Entities
	- Açıklama: LINQ to Objects tüm .NET API'lerini kullanırken, LINQ to Entities (EF Core) sorguları veri kaynağına çevirir—bu yüzden bazı .NET fonksiyonları translate edilemeyebilir (örn. custom method) ve runtime hata alabilirsiniz.

- Hızlı örnekler
	- Filtre + proje:
		- `var names = people.Where(p => p.IsActive).Select(p => p.Name).ToList();`
	- Grup ve sayma:
		- `var byCity = people.GroupBy(p => p.City).Select(g => new { City = g.Key, Count = g.Count() });`
	- Join örneği (method syntax):
		- `var q = orders.Join(customers, o => o.CustomerId, c => c.Id, (o,c) => new { o.Id, c.Name });`

- Hata yapma eğilimleri / en iyi uygulamalar
	- Veritabanı sorgularında (IQueryable) lokal fonksiyonları kullanmayın—çünkü translate edilemeyebilir.
	- Gerektiğinde `ToList()` ile ara sonuç alarak çoklu enumerasyonu önleyin.
	- Büyük koleksiyonlarda `Count()` yerine `Any()` kullanarak varlık kontrolü yapın (`Any()` kısa devre eder).

Not: Örnekler C# içindir; gerekli namespace'ler: `System`, `System.Linq`, `System.Collections.Generic`. Bu doküman önceki bölümlerin kısa açıklamalar + örnekler stilinde hazırlanmıştır.

