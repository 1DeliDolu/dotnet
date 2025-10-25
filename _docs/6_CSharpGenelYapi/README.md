# C# Programlarının Genel Yapısı

Bu not, TODO listesindeki "General Structure of a C# Program" kaynağının öne çıkardığı kavramları Türkçe özetler:

## Dosya, ad alanı ve tür hiyerarşisi
- Bir C# projesi birden fazla `.cs` dosyasından oluşabilir; her dosyada sıfır veya daha fazla `namespace` tanımı bulunabilir.
- Bir namespace içerisinde sınıf (`class`), yapı (`struct`), arayüz (`interface`), temsilci (`delegate`) ve sabit değer kümeleri (`enum`) gibi türler yer alır; namespace tanımları iç içe yazılabilir.
- Giriş noktasını sağlamak için iki seçenek vardır:
  1. **Üst düzey ifadeler (top-level statements)**: Dosyanın başındaki ilk ifade (`Console.WriteLine(...)` gibi) uygulamayı başlatır ve yalnızca tek bir dosyada kullanılabilir.
  2. **`static void Main`**: Geleneksel yaklaşımda `Program` gibi bir sınıf içinde `static void Main(string[] args)` metodu yer alır ve uygulama bu metodun açılış süslü parantezinde başlar.

## Derleme ve çalıştırma
- Tipik iş akışı `dotnet build` ile derleyip `dotnet run` ile çalıştırmaktır; `dotnet run` ihtiyaç halinde otomatik derleme yapar.
- .NET 10 ile gelen **dosya tabanlı uygulamalar**, tek bir `.cs` dosyasını doğrudan `dotnet run <dosya.cs>` komutuyla veya Unix ortamında yürütülebilir (`chmod +x`) hale getirip `./dosya.cs` şeklinde çalıştırmanıza izin verir.
- Dosya tabanlı script’lerde ilk satıra `#!/usr/local/share/dotnet/dotnet run` (veya dağıtımınıza uygun yol) eklenerek “shebang” davranışı sağlanır.

## İfade (expression) ve deyim (statement) farkı
- **İfadeler** (`x + y`, `Math.Max(a, b)`, `new Person("Ada")` gibi) tek bir değer üretir ve başka ifadeler içinde kullanılabilir.
- **Deyimler** (`int x = 42;`, `if (koşul) { ... }`, `return değer;`) kontrol akışını veya yan etkileri temsil eder; değer döndürmezler.
- Bazı yapılar her iki rolü de oynayabilir: `Console.WriteLine("Hello")` ifadesi tek başına yazıldığında bir ifade deyimidir, fakat interpolasyon içinde değer üreten bir ifadeye dönüşebilir.

## Daha fazla okuma
- MSDN Fundamentals: *Classes*, *Structs*, *Namespaces*, *Interfaces*, *Enums*, *Delegates* bölümleri.
- C# Language Specification: "Basic concepts" bölümü yapının resmi tanımını içerir.
- Programlama konseptleri belgesi; özellikle üst düzey ifadeler ve ifade-gövdesi üyeler (expression-bodied members) konuları, modern C# sürümlerini takip etmek için önemlidir.
