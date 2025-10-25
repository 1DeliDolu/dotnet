## 🔍 C#’ta LINQ ile Verileri Filtreleme

Filtreleme (filtering), bir koleksiyondaki öğeleri **belirli bir koşulu** sağlayanlarla sınırlandırma işlemidir. Bu işlem sayesinde, örneğin belirli bir uzunluktaki kelimeleri ya da belirli bir koşula uyan kayıtları seçebilirsin.

> 💡 **Not:** Örneklerde `IEnumerable<T>` veri kaynağı kullanılmaktadır. EF Core gibi `IQueryable<T>` tabanlı kaynaklarda bazı sözdizimi kısıtlamaları olabilir.

---

### 🧩 Örnek: `where` ifadesiyle filtreleme (Sorgu sözdizimi)

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = { "the", "quick", "brown", "fox", "jumps" };

        IEnumerable<string> query =
            from word in words
            where word.Length == 3
            select word;

        foreach (string str in query)
        {
            Console.WriteLine(str);
        }

        // Çıktı:
        // the
        // fox
    }
}
```

---

### ⚙️ Aynı sorgunun **metot sözdizimiyle** (method syntax) yazılmış hali

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = { "the", "quick", "brown", "fox", "jumps" };

        IEnumerable<string> query =
            words.Where(word => word.Length == 3);

        foreach (string str in query)
        {
            Console.WriteLine(str);
        }

        // Çıktı:
        // the
        // fox
    }
}
```

---

✨ **Özetle:**

* `where` → belirli bir koşula uyan elemanları filtreler.
* `OfType<T>()` → belirtilen türdeki elemanları seçer.
* Sorgu (query) sözdizimi ve metot (method) sözdizimi aynı işlemi yapar, sadece yazım şekli farklıdır.
