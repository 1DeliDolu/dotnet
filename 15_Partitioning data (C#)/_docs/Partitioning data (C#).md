### 🔹 LINQ’te **Veri Bölümlendirme (Partitioning Data)** — Türkçe Açıklama 🇹🇷

LINQ’te **partitioning (bölümlendirme)** işlemi, bir veri dizisini (sequence) **iki bölüme ayırmak**, ama elemanların sırasını **bozmamak** anlamına gelir.
Bu işlem sonunda genellikle bölümlerden **birini** geri döndürürüz.

---

### 🧩 Temel Metotlar

| Metot         | Açıklama                                              | Açıklama (Türkçe)                                        |
| ------------- | ----------------------------------------------------- | -------------------------------------------------------- |
| **Take**      | Belirtilen sayıya kadar olan elemanları alır.         | Listenin **ilk n elemanını** döndürür.                   |
| **Skip**      | Belirtilen sayıya kadar olan elemanları atlar.        | Listenin **ilk n elemanını atlayıp** kalanları döndürür. |
| **TakeWhile** | Belirli bir koşul sağlanana kadar elemanları alır.    | **Koşul doğru olduğu sürece** elemanları alır.           |
| **SkipWhile** | Belirli bir koşul sağlandığı sürece elemanları atlar. | **Koşul bozulana kadar** elemanları atlar.               |
| **Chunk**     | Diziyi belirtilen boyutta parçalara ayırır.           | **Alt dizilere (chunk)** böler.                          |

---

### ⚙️ Örnek Kodlar ve Çıktılar

#### 🧮 **Take()** – İlk 3 elemanı al

```csharp
foreach (int number in Enumerable.Range(0, 8).Take(3))
{
    Console.WriteLine(number);
}
```

📤 **Çıktı:**

```
0
1
2
```

---

#### 🧮 **Skip()** – İlk 3 elemanı atla

```csharp
foreach (int number in Enumerable.Range(0, 8).Skip(3))
{
    Console.WriteLine(number);
}
```

📤 **Çıktı:**

```
3
4
5
6
7
```

---

#### 🧮 **TakeWhile()** – Koşul doğru olduğu sürece elemanları al

```csharp
foreach (int number in Enumerable.Range(0, 8).TakeWhile(n => n < 5))
{
    Console.WriteLine(number);
}
```

📤 **Çıktı:**

```
0
1
2
3
4
```

---

#### 🧮 **SkipWhile()** – Koşul doğru olduğu sürece elemanları atla

```csharp
foreach (int number in Enumerable.Range(0, 8).SkipWhile(n => n < 5))
{
    Console.WriteLine(number);
}
```

📤 **Çıktı:**

```
5
6
7
```

---

#### 🧮 **Chunk()** – Diziyi parçalara (chunk’lara) ayır

```csharp
int chunkNumber = 1;
foreach (int[] chunk in Enumerable.Range(0, 8).Chunk(3))
{
    Console.WriteLine($"Chunk {chunkNumber++}:");
    foreach (int item in chunk)
    {
        Console.WriteLine($"    {item}");
    }
    Console.WriteLine();
}
```

📤 **Çıktı:**

```
Chunk 1:
    0
    1
    2

Chunk 2:
    3
    4
    5

Chunk 3:
    6
    7
```

---

### 💡 Özet

* 🔸 `Take` → İlk n eleman
* 🔸 `Skip` → İlk n elemanı atla
* 🔸 `TakeWhile` → Koşul **doğru olduğu sürece** al
* 🔸 `SkipWhile` → Koşul **doğru olduğu sürece** atla
* 🔸 `Chunk` → Listeyi **küçük alt listelere** böl

---


