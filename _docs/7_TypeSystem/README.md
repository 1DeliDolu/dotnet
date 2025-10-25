# C# Tip Sistemi Özeti

Bu doküman, "The C# type system" makalesindeki ana başlıkları kısa ve Türkçe bir bakışla özetler. Kod örneği yerine kavramsal açıklamalara odaklanır.

## Güçlü tip güvenliği
- C# derleyicisi her değişkenin, sabitin ve ifadenin türünü bilir; yapılan işlemlerin tip açısından güvenli olmasını sağlar.
- Derlenen uygulamanın meta verilerine tip bilgisi de gömülür; CLR çalışma anında bu meta verileri kullanarak güvenliği sürdürür.

## Tipi belirtme ve çıkarım
- Değişken/sabit tanımlarken açıkça tür belirtmeli ya da `var` ile derleyiciye bırakmalısınız. `var`, yalnızca yerel değişkenlerde çalışır ve derleme sırasında somut bir tipe çözülür.
- Metot imzaları parametre ve dönüş türünü net biçimde gösterir; bir değişken başka bir tipe dönüştürülmedikçe yeni tip ataması yapılamaz.
- Veri kaybı olmayan dönüşümler otomatik yapılır; potansiyel kayıplar için açık `cast` gerekir.

## Yerleşik tipler
- Tamsayı, kayan nokta, `bool`, `char`, `decimal`, `string` ve `object` gibi temel tipler tüm projelerde hazırdır.
- Bu tiplerin kapsamlarını, alt/üst sınırlarını ve kullanım senaryolarını MSDN’deki *Built-in types* başlığından inceleyebilirsiniz.

## Özel tipler
- `struct`, `class`, `interface`, `enum` ve `record` ile alanınıza özel tipler tanımlarsınız.
- Karar verirken boyut, değişmezlik, eşitlik semantiği ve kalıtım gereksinimleri gibi kriterleri değerlendirin (örneğin küçük ve immutable veri taşıyıcıları için `record struct`).

## Ortak Tip Sistemi (CTS)
- .NET çalışma zamanı tüm diller arasında uyumlu bir CTS sunar; değer tipleri (stack üzerinde kopyalanan) ve başvuru tipleri (heap üzerinde saklanan) arasında ayrım yapar.
- Literal değerlerin (`42`, `"text"`, `true`) her birinin varsayılan bir tipi vardır; gerekirse sonuna eklenen soneklerle (`42u`, `12.3m`) türü belirginleştirebilirsiniz.

## Generic tipler ve güçlü koleksiyonlar
- Tip parametreleri (`List<T>`, `Dictionary<TKey, TValue>` vb.) aynı sınıfı farklı öğe tipleriyle yeniden kullanmayı sağlar ve derleme zamanı tip güvenliği sunar.
- Yanlış tipte öğe eklemeye çalıştığınızda hata, uygulama çalışmadan önce ortaya çıkar.

## Çeşitli dil özellikleri
- **Anonim tipler** kısa ömürlü, biçimi derleyici tarafından üretilen veri taşıyıcılarıdır.
- **Nullable değer tipleri** (`int?`, `decimal?`) veri tabanı gibi ortamlarda `null` tutmak için kullanılır ve `System.Nullable<T>` tarafından temsil edilir.
- **Implicit tipler** (`var`) ve **anonymous types** birlikte sorgu ifadelerinde (LINQ) sıkça kullanılır.

## Derleme zamanı vs çalışma zamanı tipi
- Bir değişkenin kaynak kodda görülen tipi *derleme zamanı*, referans verdiği gerçek nesnenin tipi *çalışma zamanı* tipidir.
- Derleyicinin yaptığı aşamalar (metot çözümü, overload seçimi, izin verilen dönüşümler) derleme zamanı tipine bakar; `virtual` çağrılar, `is` ve `switch` pattern’leri ise çalışma zamanı tipini değerlendirir.

## İlgili kaynaklar
- *Value Types*, *Reference Types*, *Built-in types* ve *Casting and Type Conversions* makaleleri.
- *Generics* ve *Nullable value types* bölümleri, tip sistemini daha derin anlamak için önerilir.
- Resmî C# dil spesifikasyonu, tip sözleşmelerinin nihai kaynağıdır.
