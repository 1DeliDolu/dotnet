### 🌸 **Projeksiyon İşlemleri (Projection Operations) – LINQ (C#)**

Projeksiyon, bir nesneyi **yeni bir biçime dönüştürme** işlemidir. Genellikle bu yeni biçim, nesnenin yalnızca kullanılacak özelliklerini içerir.
LINQ’de projeksiyon işlemleri; `Select`, `SelectMany` ve `Zip` metodlarıyla yapılır.

---

## 🧩 **1. Select – Temel Dönüştürme (Projection)**

Bir koleksiyondaki her öğeden belirli bir değeri seçmek için `select` kullanılır.
Aşağıdaki örnekte her kelimenin ilk harfi alınır 👇

```csharp
List<string> words = ["an", "apple", "a", "day"];

var query = from word in words
            select word.Substring(0, 1);

foreach (string s in query)
{
    Console.WriteLine(s);
}
```

🟢 **Çıktı:**

```
a
a
a
d
```

Aynı sorgu **method syntax** ile:

```csharp
List<string> words = ["an", "apple", "a", "day"];

var query = words.Select(word => word.Substring(0, 1));

foreach (string s in query)
{
    Console.WriteLine(s);
}
```

---

## 🪄 **2. SelectMany – Çoklu Koleksiyonları Düzleştirme**

`SelectMany`, birden fazla alt diziyi **tek bir düz listeye** dönüştürür.
Aşağıdaki örnek her cümledeki kelimeleri ayırır 👇

```csharp
List<string> phrases = ["an apple a day", "the quick brown fox"];

var query = from phrase in phrases
            from word in phrase.Split(' ')
            select word;

foreach (string s in query)
{
    Console.WriteLine(s);
}
```

🟢 **Çıktı:**

```
an
apple
a
day
the
quick
brown
fox
```

Method syntax ile eşdeğeri:

```csharp
List<string> phrases = ["an apple a day", "the quick brown fox"];

var query = phrases.SelectMany(phrase => phrase.Split(' '));

foreach (string s in query)
{
    Console.WriteLine(s);
}
```

---

## 🔗 **3. Zip – Koleksiyonları Eşleştirme**

`Zip`, iki veya üç koleksiyonu **eşleştirerek tuple** (çiftler) oluşturur.

```csharp
IEnumerable<int> numbers = [1, 2, 3, 4, 5, 6, 7];
IEnumerable<char> letters = ['A', 'B', 'C', 'D', 'E', 'F'];

foreach ((int number, char letter) in numbers.Zip(letters))
{
    Console.WriteLine($"Number: {number} zipped with letter: '{letter}'");
}
```

🟢 **Çıktı:**

```
Number: 1 zipped with letter: 'A'
Number: 2 zipped with letter: 'B'
Number: 3 zipped with letter: 'C'
Number: 4 zipped with letter: 'D'
Number: 5 zipped with letter: 'E'
Number: 6 zipped with letter: 'F'
```

> ⚠️ Zip sonucu, **en kısa koleksiyonun uzunluğuyla** sınırlıdır.

---

3 koleksiyonla örnek (emoji ekleyelim 😎):

```csharp
IEnumerable<int> numbers = [1, 2, 3, 4, 5, 6, 7];
IEnumerable<char> letters = ['A', 'B', 'C', 'D', 'E', 'F'];
IEnumerable<string> emoji = ["🤓", "🔥", "🎉", "👀", "⭐", "💜", "✔", "💯"];

foreach ((int number, char letter, string em) in numbers.Zip(letters, emoji))
{
    Console.WriteLine($"Number: {number} is zipped with letter: '{letter}' and emoji: {em}");
}
```

🟢 **Çıktı:**

```
Number: 1 is zipped with letter: 'A' and emoji: 🤓
Number: 2 is zipped with letter: 'B' and emoji: 🔥
Number: 3 is zipped with letter: 'C' and emoji: 🎉
Number: 4 is zipped with letter: 'D' and emoji: 👀
Number: 5 is zipped with letter: 'E' and emoji: ⭐
Number: 6 is zipped with letter: 'F' and emoji: 💜
```

---

## 🌺 **4. Select vs SelectMany Farkı**

🔹 `Select`: Her öğe için **tek sonuç** döndürür.
🔹 `SelectMany`: Her öğe için **birden fazla sonuç** döndürüp tümünü **birleştirir**.

```csharp
class Bouquet
{
    public required List<string> Flowers { get; init; }
}

static void SelectVsSelectMany()
{
    List<Bouquet> bouquets =
    [
        new Bouquet { Flowers = ["sunflower", "daisy", "daffodil", "larkspur"] },
        new Bouquet { Flowers = ["tulip", "rose", "orchid"] },
        new Bouquet { Flowers = ["gladiolis", "lily", "snapdragon", "aster", "protea"] },
        new Bouquet { Flowers = ["larkspur", "lilac", "iris", "dahlia"] }
    ];

    IEnumerable<List<string>> query1 = bouquets.Select(bq => bq.Flowers);
    IEnumerable<string> query2 = bouquets.SelectMany(bq => bq.Flowers);

    Console.WriteLine("Results by using Select():");
    foreach (IEnumerable<string> collection in query1)
    {
        foreach (string item in collection)
        {
            Console.WriteLine(item);
        }
    }

    Console.WriteLine("\nResults by using SelectMany():");
    foreach (string item in query2)
    {
        Console.WriteLine(item);
    }
}
```

🟢 **Çıktı:**

```
Results by using Select():
sunflower
daisy
daffodil
larkspur
tulip
rose
orchid
gladiolis
lily
snapdragon
aster
protea
larkspur
lilac
iris
dahlia

Results by using SelectMany():
sunflower
daisy
daffodil
larkspur
tulip
rose
orchid
gladiolis
lily
snapdragon
aster
protea
larkspur
lilac
iris
dahlia
```

---

✅ **Özetle:**

| Metot        | Amaç                              | Dönüş Tipi                  | Özellik                  |
| :----------- | :-------------------------------- | :-------------------------- | :----------------------- |
| `Select`     | Her elemandan yeni değer üretir   | Koleksiyon (aynı uzunlukta) | Tek katman               |
| `SelectMany` | İç içe koleksiyonları düzleştirir | Tek liste                   | Çok katmanı tekleştirir  |
| `Zip`        | Koleksiyonları eşleştirir         | Tuple dizisi                | En kısa dizi kadar sonuç |

---

🧠 **Kısaca:**
Projeksiyon = **Veriyi yeniden şekillendirmek.**
LINQ bunu `Select`, `SelectMany`, `Zip` gibi operatörlerle sağlar.
Bu sayede hem okunabilir hem güçlü veri dönüşümleri yapılabilir.
