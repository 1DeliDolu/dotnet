# Verzweigung, Ifs und bedingte Logik (Teil 9 von 19) | C# für Anfänger

Bu bölümde C#'ta koşullu ifadeler (if/else), çoklu dallanma (`switch`), kısa ifadeler (ternary), mantıksal operatörler ve null ile ilgili yardımcı operatörler kısa açıklama ve örneklerle verilmektedir.
- Temel `if` yapısı
	- Açıklama: Belirli bir koşul true ise bir blok çalışır; değilse opsiyonel `else` bloğu çalışır.
	- Örnek:
	- `if (x > 0) { Console.WriteLine("pozitif"); } else { Console.WriteLine("pozitif değil"); }`

- `else if` ile çoklu durum kontrolü
    - Açıklama: Birden fazla koşulu zincirlemek için kullanılır.
	- Örnek:
		- `if (score >= 90) { grade = 'A'; } else if (score >= 80) { grade = 'B'; } else { grade = 'F'; }`

- Kısa not: tek satırlık bloklar
	- Açıklama: Tek satırlık blokları süslü parantez olmadan yazabilirsiniz, ancak okunabilirlik ve hata yapma riskini azaltmak için süslü parantez önerilir.
	- Örnek:
		- `if (x == 0) Console.WriteLine("sıfır");` (tercih edilen: `{ }` kullanmak)

- Mantıksal operatörler
	- Açıklama: `&&` (AND - kısa devre eder), `||` (OR - kısa devre eder), `!` (NOT). Kısa devre (short-circuit) önemli: sol operand false ise `&&` sağa bakmaz.
	- Örnekler:
		- `if (x != 0 && 10 / x > 1) { ... } // x==0 ise bölme yapılmaz`
		- `if (isAdmin || isOwner) { ... }`

- Null kontrolü ve null-conditional (`?.`) / null-coalescing (`??`)
	- Açıklama: Null referanslarını güvenli şekilde kontrol etmek için kullanılır.
	- Örnekler:
		- `var len = s?.Length; // s null ise len null olur (int?)`
		- `var name = possiblyNullName ?? "Anonim"; // null ise varsayılan atar`

- Ternary (koşul operatörü) `?:`
	- Açıklama: Basit if-else ifadelerini tek satırda yazmak için kullanılır.
	- Örnek:
		- `var result = (x % 2 == 0) ? "çift" : "tek";`

- `switch` ifadeleri (modern kullanım)
	- Açıklama: Çoklu sabit veya pattern-matching durumlarını yönetir. C# 8+ ve sonrası ile switch daha güçlü pattern matching yetenekleri aldı.
	- Basit `switch` örneği:
		- `switch (day) { case 1: Console.WriteLine("Pazartesi"); break; case 2: ... default: break; }`
	- Expression-style `switch` (kısa):
	- `var name = day switch { 1 => "Pazartesi", 2 => "Salı", _ => "Bilinmiyor" };`

- Pattern matching ile `switch`
    - Açıklama: Tür ve özellik bazlı eşleme sağlar.
	- Örnekler:
		- `if (obj is string s) { Console.WriteLine(s.Length); }`
		- `switch (shape) { case Circle c: ...; case Rectangle r when r.Width == r.Height: ...; }`

- `switch` performans ve fall-through
	- Açıklama: Geleneksel `case`'lerde `break` unutulursa derleyici hata vermezse bile beklenmedik sonuç olur; C#'ta labels arası fall-through yalnızca boş `case` etiketleriyle mümkündür. Expression-style `switch` daha güvenlidir.
- Null ve koşullar: `is null` kullanımı
	- Açıklama: `== null` yerine `is null` tercih edilebilir; `is` daha açık niyet gösterir ve bazı durumlarda pattern matching ile birleşir.
	- Örnek: `if (obj is null) { ... }`

- Kısa devre örnekleri ve yan etkiler
	- Açıklama: Kısa devre davranışı, yan etkili fonksiyon çağrıları ile birleştirildiğinde önem kazanır.
	- Örnek:
		- `if (user != null && user.IsActive()) { ... } // user null ise IsActive çağrılmaz`

- Hata yapma eğilimleri / en iyi uygulamalar
	- Her `if` bloğu için süslü parantez kullanın; bu gelecekte ek satırlar eklerken hataları azaltır.
	- Null kontrolünü mümkün olduğunca erken yapın (guard clauses): `if (arg is null) throw new ArgumentNullException(nameof(arg));`
	- `switch`'te çok sayıda `case` varsa `switch` expression veya dictionary tabanlı dispatch düşünülebilir.
	- Karmaşık koşulları açıklayıcı boolean değişkenlere bölün: `bool isValidUser = user != null && user.IsActive && user.HasPermission; if (isValidUser) ...`

- Örnek: Guard clause ve temiz kod
	- Örnek:
	- `void Process(Order order) { if (order is null) throw new ArgumentNullException(nameof(order)); if (!order.IsPaid) return; // devam eden işlem }`

- Örnek: switch expression ile basit mapping
    - Örnek:
	- `var label = status switch { Status.Ok => "Tamam", Status.Error => "Hata", _ => "Bilinmiyor" };`

Not: Örnekler C# içindir; gerekli namespace'ler: `System` ve gerektiğinde `System.Linq`. Bu doküman `Teil-4-von-19.md` ve önceki bölümlerin üslubunda kısa açıklamalar + örnekler formatındadır.

