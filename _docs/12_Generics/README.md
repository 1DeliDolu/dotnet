# C# Generic Sınıf ve Metotlarına Giriş

Bu özet, "Generic classes and methods" makalesinin temel noktalarını açıklar. Kod listeleri yalnızca kavramsal örneklerdir, depo içinde yeni .cs dosyaları yoktur.

## Generics fikri
- Tip parametreleri (`<T>`, `<TKey, TValue>`) sayesinde sınıf veya metotların **hangi türle çalışacağı** kullanım anında belirlenir.
- Derleyici, generics kullanan türü oluştururken her `T` ifadesini verilen somut tipe çevirir; böylece boxing/unboxing ya da `object` dönüşümlerine ihtiyaç kalmaz.
- Örnek: `GenericList<int>` ve `GenericList<string>` aynı sınıf tanımını paylaşırken tip güvenliği korunur.

## Generic sınıf ve iç üyeler
```csharp
public class GenericList<T>
{
    private class Node(T value)
    {
        public T Data { get; set; } = value;
        public Node? Next { get; set; }
    }

    private Node? head;

    public void AddHead(T value)
    {
        Node node = new(value);
        node.Next = head;
        head = node;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (Node? current = head; current is not null; current = current.Next)
        {
            yield return current.Data;
        }
    }
}
```
- Tip parametresi `T` sınıf içinde alan, özellik, parametre ve dönüş tipi olarak yeniden kullanılır; iç içe sınıflar (`Node`) da aynı tip parametresini görebilir.

## Kullanım örneği
```csharp
GenericList<int> numbers = new();
for (int i = 0; i < 10; i++)
{
    numbers.AddHead(i);
}
foreach (int value in numbers)
{
    Console.WriteLine(value);
}
```
- Tip argümanını değiştirerek (`GenericList<string>`, `GenericList<MyType>`) aynı davranışı başka veri tipleri için kullanabilirsiniz.

## Avantajlar
- **Kod tekrarını azaltır**: Aynı mantığı her veri tipi için yeniden yazmanız gerekmez.
- **Tip güvenliği**: Yanlış tip eklemeye çalışmak derleme aşamasında hata verir.
- **Performans**: `object` tabanlı koleksiyonlara göre daha az kutulama ve runtime cast içerir.

## CLR ve sınıf kitaplığı
- `System.Collections.Generic` içindeki `List<T>`, `Dictionary<TKey,TValue>`, `Queue<T>` gibi sınıflar generics tabanlıdır; eski `ArrayList` gibi nongeneric koleksiyonlar yalnızca geriye dönük uyumluluk için tutulur.
- Generics yalnızca sınıflarla sınırlı değildir; interface, struct, record, delegate ve metotlarda da kullanılabilir.

## Tasarım ipuçları
- Tip parametreleri için **kısıtlamalar** (`where T : struct`, `class`, `new()` vb.) belirleyerek belirli üyelerin mevcut olmasını garanti edebilirsiniz.
- Yansıma (reflection) aracılığıyla çalışma zamanında bir generic türün hangi tip argümanlarını aldığını inceleyebilirsiniz.

## Daha fazla bilgi
- [Generics in .NET](https://learn.microsoft.com/dotnet/standard/generics/)
- [Constraints on type parameters](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/where-clause)
