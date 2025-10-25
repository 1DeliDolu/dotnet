### ⚡ C# — `async` ve `await` ile Asenkron Programlama

---

Asenkron programlama, işlemlerin birbirini **beklemeden** aynı anda yürütülmesini sağlar. C#’ta bu yaklaşım **`Task` Asynchronous Programming (TAP)** modeliyle gerçekleştirilir. `async` ve `await` anahtar sözcükleri bu modeli kolayca uygulamamıza olanak tanır.

---

#### 🍳 **Kahvaltı örneği ile asenkron düşünme**

Aşağıdaki örnek, bir kahvaltı hazırlama sürecini simüle eder. Burada aynı anda yumurta, patates ve tost hazırlanır. Kod, sırayla okunmasına rağmen işlemler eşzamanlı olarak yürür.

---

### 🔹 **Tam Asenkron Kahvaltı Örneği**

```csharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    internal class HashBrown { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("☕ Kahve hazır!");

            var eggsTask = FryEggsAsync(2);
            var hashBrownTask = FryHashBrownsAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, hashBrownTask, toastTask };

            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                    Console.WriteLine("🍳 Yumurta hazır!");
                else if (finishedTask == hashBrownTask)
                    Console.WriteLine("🥔 Hash browns hazır!");
                else if (finishedTask == toastTask)
                    Console.WriteLine("🍞 Tost hazır!");

                await finishedTask;
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("🍊 Portakal suyu hazır!");
            Console.WriteLine("✅ Kahvaltı hazır!");
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Portakal suyu dolduruluyor...");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Tosta reçel sürülüyor...");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Tosta tereyağı sürülüyor...");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int i = 0; i < slices; i++)
                Console.WriteLine("Bir dilim ekmek tost makinesine konuyor...");
            Console.WriteLine("Tost yapılıyor...");
            await Task.Delay(3000);
            Console.WriteLine("Tost çıkarıldı.");
            return new Toast();
        }

        private static async Task<HashBrown> FryHashBrownsAsync(int patties)
        {
            Console.WriteLine($"{patties} adet hash brown tavaya konuyor...");
            Console.WriteLine("İlk yüz pişiriliyor...");
            await Task.Delay(3000);
            Console.WriteLine("Hash brown çevriliyor...");
            await Task.Delay(3000);
            Console.WriteLine("Hash brown tabağa alındı.");
            return new HashBrown();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Yumurta tavası ısıtılıyor...");
            await Task.Delay(3000);
            Console.WriteLine($"{howMany} yumurta kırılıyor...");
            Console.WriteLine("Yumurtalar pişiyor...");
            await Task.Delay(3000);
            Console.WriteLine("Yumurtalar tabağa alındı.");
            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Kahve dolduruluyor...");
            return new Coffee();
        }
    }
}
```

---

### 💡 **Açıklama**

* `async` — Metodun asenkron çalışacağını belirtir.
* `await` — Asenkron işlemin tamamlanmasını bekler, **ana thread’i kilitlemeden**.
* `Task` — Devam eden işlemi temsil eder (örneğin `Task<Egg>` = Yumurtalar pişiyor).
* `Task.WhenAny()` — İlk tamamlanan görevi döndürür.
* `Task.WhenAll()` — Tüm görevler tamamlandığında çalışır.

---

### ⚖️ **Karşılaştırma: `ContinueWith` vs `async/await`**

| Özellik          | ContinueWith                    | async/await                     |
| ---------------- | ------------------------------- | ------------------------------- |
| 🧠 Okunabilirlik | Düşük (iç içe callback zinciri) | Yüksek, adım adım okunur        |
| 🧩 Hata Yönetimi | Karmaşık                        | `try/catch` ile doğal           |
| 🧰 Bakım         | Zor                             | Kolay                           |
| 🔍 Debug         | Karışık stack trace             | Daha temiz                      |
| 🚀 Performans    | Ortalama                        | Optimize edilmiş derleyici kodu |

---

### 🎯 **Sonuç**

`async` ve `await`, C# programlarında **okunabilir, ölçeklenebilir ve kullanıcı dostu** asenkron yapı kurmanın en kolay yoludur.
Bu özellikler sayesinde hem **UI uygulamaları donmaz**, hem de **sunucu uygulamaları** daha verimli hale gelir.
