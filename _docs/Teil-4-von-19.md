# Einführung in Zeichenfolgen

Aşağıda C#'ta string ile sık kullanılan özellik ve metotların kısa açıklamaları ve örnekleri var.

- Length  
    - Açıklama: Dizgenin uzunluğunu (karakter sayısını) döner (özellik).  
    - Örnek: `int len = "hello".Length; // 5`

- Trim / TrimStart / TrimEnd  
    - Açıklama: Başındaki ve/veya sonundaki boşlukları veya belirtilen karakterleri kaldırır.  
    - Örnek: `"  abc  ".Trim(); // "abc"`

- ToUpper / ToLower  
    - Açıklama: Tüm karakterleri büyük / küçük harfe çevirir.  
    - Örnek: `"Abc".ToUpper(); // "ABC"`

- İndeksleme / char kodu  
    - Açıklama: Bir karaktere indeks ile erişilir; karakter kodu için char'ı int'e çevir.  
    - Örnek: `char c = "abc"[1]; // 'b'`  
                        `int code = (int)"a"[0]; // 97`

- IndexOf / LastIndexOf  
    - Açıklama: Bir alt dizgenin ilk / son geçtiği indisi döner, bulunmazsa -1.  
    - Örnek: `"banana".IndexOf("a"); // 1`  
                        `"banana".LastIndexOf("a"); // 5`

- Contains / StartsWith / EndsWith  
    - Açıklama: Alt dizgenin varlığını veya başlangıç/son ile eşleşmesini boolean olarak döner.  
    - Örnek: `"hello".Contains("ell"); // true`  
                        `"hi".StartsWith("h"); // true`

- Substring / Range (^ operator)  
    - Açıklama: Dizgenin belirtilen aralığını döner. C#'ta negatif indeks yok, ancak ^ ve Range ile sondan seçilebilir.  
    - Örnek: `"hello".Substring(1,3); // "ell"`  
                        `var s = "hello"; var tail = s[^3..]; // "llo"`

- Split  
    - Açıklama: Dizgeyi ayırıp string[] döner.  
    - Örnek: `"a,b,c".Split(','); // ["a","b","c"]`

- Replace  
    - Açıklama: Tüm eşleşmeleri değiştirir (C# Replace tüm occurenceleri değiştirir).  
    - Örnek: `"aba".Replace("a","x"); // "xbx"`

- Regex: Matches / Match / IsMatch / Replace (System.Text.RegularExpressions)  
    - Açıklama: Düzenli ifadelerle eşleşme arama/manipülasyon.  
    - Örnek: `Regex.Matches("a1b2", @"\d"); // MatchCollection ["1","2"]`  
                        `Regex.Replace("a1b2", @"\d", "X"); // "aXbX"`

- Concat / +  
    - Açıklama: Dizgeleri birleştirir.  
    - Örnek: `string.Concat("a","b"); // "ab"`  
                        `"a" + "b"; // "ab"`

- Tekrar (repeat)  
    - Açıklama: Karakterleri ya da dizgeleri tekrar etmek için farklı yollar.  
    - Örnek: `new string('a', 3); // "aaa"`  
                        `string.Concat(Enumerable.Repeat("ha", 3)); // "hahaha" (using System.Linq)`

- PadLeft / PadRight  
    - Açıklama: Dizgenin başına veya sonuna dolgu ekler, belirli uzunluğa tamamlar.  
    - Örnek: `"5".PadLeft(3, '0'); // "005"`

- Compare / CompareTo (kültüre duyarlı karşılaştırma)  
    - Açıklama: Dizgeleri karşılaştırır; negatif/0/pozitif döner; kültür ve karşılaştırma seçenekleri verilebilir.  
    - Örnek: `string.Compare("a", "b", StringComparison.CurrentCulture); // < 0`  
                        `"a".CompareTo("b"); // < 0`

Not: Örnekler C# içindir; gerekli namespace'ler: System, System.Linq (gerektiğinde) ve System.Text.RegularExpressions.