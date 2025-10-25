## 🔷 C# LINQ — Verileri Sıralama (Sorting Data)

LINQ’ta sıralama işlemleri, koleksiyon içindeki elemanları **bir veya birden fazla kritere göre** düzenlemek için kullanılır.
Örneğin: birincil olarak **şehir adına**, ikincil olarak **soyadına** göre sıralama yapılabilir.

---

### 🧩 Kullanılan LINQ Metotları

| Metot                 | Açıklama                    | C# Query Söz Dizimi           |
| --------------------- | --------------------------- | ----------------------------- |
| `OrderBy()`           | Artan sırada sıralar        | `orderby`                     |
| `OrderByDescending()` | Azalan sırada sıralar       | `orderby ... descending`      |
| `ThenBy()`            | İkincil artan sıralama      | `orderby ..., ...`            |
| `ThenByDescending()`  | İkincil azalan sıralama     | `orderby ..., ... descending` |
| `Reverse()`           | Koleksiyonu tersine çevirir | Yok                           |

---

### 🔹 Tüm Sıralama Türlerini Gösteren Kapsayıcı Örnek Kod

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public enum GradeLevel
{
    FirstYear = 1,
    SecondYear,
    ThirdYear,
    FourthYear
};

public class Teacher
{
    public required string First { get; init; }
    public required string Last { get; init; }
    public required int ID { get; init; }
    public required string City { get; init; }
}

class Program
{
    static void Main()
    {
        // 🔸 Örnek veri kümesi
        var teachers = new List<Teacher>
        {
            new() { First = "Ali", Last = "Kaya", ID = 901, City = "Ankara" },
            new() { First = "Ayşe", Last = "Demir", ID = 965, City = "İzmir" },
            new() { First = "Fatma", Last = "Yılmaz", ID = 932, City = "İstanbul" },
            new() { First = "Mehmet", Last = "Çelik", ID = 945, City = "Bursa" },
            new() { First = "Ahmet", Last = "Koç", ID = 987, City = "Ankara" },
            new() { First = "Zeynep", Last = "Arslan", ID = 910, City = "Bursa" }
        };

        // 🟩 1. Birincil Artan Sıralama (OrderBy)
        Console.WriteLine("=== 🔹 OrderBy (Soyada göre artan) ===");
        var orderByLast = teachers
            .OrderBy(t => t.Last)
            .Select(t => t.Last);

        foreach (var last in orderByLast)
            Console.WriteLine(last);

        // 🟥 2. Birincil Azalan Sıralama (OrderByDescending)
        Console.WriteLine("\n=== 🔹 OrderByDescending (Soyada göre azalan) ===");
        var orderByDesc = teachers
            .OrderByDescending(t => t.Last)
            .Select(t => t.Last);

        foreach (var last in orderByDesc)
            Console.WriteLine(last);

        // 🟦 3. İkincil Artan Sıralama (OrderBy + ThenBy)
        Console.WriteLine("\n=== 🔹 ThenBy (Şehre göre, sonra soyada göre artan) ===");
        var thenByQuery = teachers
            .OrderBy(t => t.City)
            .ThenBy(t => t.Last)
            .Select(t => (t.City, t.Last));

        foreach (var item in thenByQuery)
            Console.WriteLine($"City: {item.City}, Last: {item.Last}");

        // 🟨 4. İkincil Azalan Sıralama (OrderBy + ThenByDescending)
        Console.WriteLine("\n=== 🔹 ThenByDescending (Şehre göre artan, soyada göre azalan) ===");
        var thenByDescQuery = teachers
            .OrderBy(t => t.City)
            .ThenByDescending(t => t.Last)
            .Select(t => (t.City, t.Last));

        foreach (var item in thenByDescQuery)
            Console.WriteLine($"City: {item.City}, Last: {item.Last}");

        // 🟪 5. Reverse (Ters çevirme)
        Console.WriteLine("\n=== 🔹 Reverse (Listeyi ters çevir) ===");
        var reversed = teachers
            .Select(t => $"{t.First} {t.Last}")
            .Reverse();

        foreach (var name in reversed)
            Console.WriteLine(name);
    }
}
```

---

### 🧠 Açıklamalar

| Kod Bölümü                       | Ne Yapar                                                              |
| -------------------------------- | --------------------------------------------------------------------- |
| `OrderBy(t => t.Last)`           | Öğretmenleri soyadına göre **artan** sıraya dizer.                    |
| `OrderByDescending(t => t.Last)` | Öğretmenleri soyadına göre **azalan** sıraya dizer.                   |
| `ThenBy(t => t.Last)`            | Birincil sıralamadan sonra (örneğin şehir) **ikinci sıralama** yapar. |
| `ThenByDescending(t => t.Last)`  | İkincil sıralamayı **azalan** yapar.                                  |
| `Reverse()`                      | Koleksiyondaki sıralamayı tamamen ters çevirir.                       |

---

### 📤 Örnek Çıktı (kısaltılmış)

```
=== 🔹 OrderBy (Soyada göre artan) ===
Arslan
Çelik
Demir
Kaya
Koç
Yılmaz

=== 🔹 OrderByDescending (Soyada göre azalan) ===
Yılmaz
Koç
Kaya
Demir
Çelik
Arslan

=== 🔹 ThenBy (Şehre göre, sonra soyada göre artan) ===
City: Ankara, Last: Kaya
City: Ankara, Last: Koç
City: Bursa, Last: Arslan
City: Bursa, Last: Çelik
City: İstanbul, Last: Yılmaz
City: İzmir, Last: Demir
```

---

💡 **Özet:**
LINQ’ta sıralama yapmak için `OrderBy`, `ThenBy`, `Descending` ve `Reverse` metotlarını kullanırız.
Bu metotlar, koleksiyonları SQL’deki `ORDER BY` yapısına benzer şekilde işler.

✨ Böylece verileri hem **birincil** hem **ikincil** kriterlere göre güçlü bir şekilde sıralayabilirsin.
