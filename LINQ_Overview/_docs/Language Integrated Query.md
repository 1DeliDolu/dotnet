## 🔍 LINQ (Language Integrated Query)

📅 **08/08/2025**

**LINQ (Language-Integrated Query)**, sorgu yeteneklerinin doğrudan **C# diline entegre edilmesi** temeline dayanan bir teknoloji grubudur.
Geleneksel olarak, veriye yönelik sorgular derleme zamanında **tür denetimi (type checking)** veya **IntelliSense desteği** olmadan basit dizgiler (string) olarak ifade edilirdi. Ayrıca, her veri kaynağı türü (SQL veritabanı, XML belgeleri, web servisleri vb.) için **farklı bir sorgu dili** öğrenmek gerekirdi.

LINQ ile birlikte sorgular, **sınıflar, metotlar ve olaylar (events)** gibi **birinci sınıf dil öğeleri** hâline gelir.

---

### 💬 Sorgu İfadeleri (Query Expressions)

Sorgular yazarken LINQ’un en belirgin “dil ile bütünleşik” kısmı **sorgu ifadesidir (query expression)**.
Bu ifadeler, **bildirimsel (declarative)** sorgu sözdizimiyle yazılır.
Bu sayede veri kaynakları üzerinde **filtreleme, sıralama ve gruplama** işlemleri minimum kodla yapılabilir.
Aynı sorgu kalıpları, farklı veri kaynakları üzerinde (ör. SQL, XML, koleksiyonlar) kullanılabilir.

---

### 🧩 Örnek Uygulama

```csharp
// Veri kaynağını belirt
int[] scores = [97, 92, 81, 60];

// Sorgu ifadesini tanımla
IEnumerable<int> scoreQuery =
    from score in scores
    where score > 80
    select score;

// Sorguyu çalıştır
foreach (var i in scoreQuery)
{
    Console.Write(i + " ");
}

// Çıktı: 97 92 81
```

> 💡 Bu örneğin derlenebilmesi için `using System.Linq;` yönergesini eklemen gerekebilir.
> Yeni .NET sürümlerinde bu yönerge genellikle **implicit global using** olarak otomatik eklenir.

---

### 🧠 Sorgu İfadelerine Genel Bakış

* **LINQ destekli** her veri kaynağından sorgu yapılabilir.
* Sorgular **tanıdık C# yapıları** kullandığı için okunması kolaydır.
* Tüm sorgu değişkenleri **güçlü biçimde türlendirilmiştir (strongly typed)**.
* Sorgular, yalnızca **üzerinde döngü (ör. `foreach`) çalıştırıldığında** yürütülür.
* Derleme zamanında sorgular, **standart sorgu işleçleri (standard query operators)** çağrılarına dönüştürülür.
* Her sorgu ifadesi, **metot sözdizimi (method syntax)** ile de yazılabilir.
* Bazı işlemler (ör. `Count`, `Max`) yalnızca metot sözdizimiyle yapılabilir.
* Sorgular, türüne göre **delegeye (delegate)** veya **ifade ağaçlarına (expression trees)** derlenir:

  * `IEnumerable<T>` → Delegate
  * `IQueryable<T>` → Expression Tree

---

### ⚙️ LINQ Sorgulamasını Etkinleştirme

#### 🧠 Bellek İçi Veriler (In-Memory Data)

* Veri `IEnumerable<T>` türünü uyguluyorsa, **LINQ to Objects** ile sorgulanabilir.
* Eğer `IEnumerable<T>` uygulanmıyorsa, LINQ standart sorgu işleçlerini ya doğrudan türün içinde ya da **extension metotlar** olarak tanımlamak gerekir.
* Bu tür özel işleçler **ertelemeli yürütme (deferred execution)** kullanmalıdır.

#### 🌐 Uzak Veriler (Remote Data)

* Uzak veri kaynaklarını sorgulamak için en iyi yöntem, **`IQueryable<T>` arayüzünü** uygulamaktır.

---

### 🧩 IQueryable LINQ Sağlayıcıları

#### 🔹 Basit Sağlayıcı (Simple Provider)

* Bir web servisindeki tek bir metoda erişebilir.
* Belirli bir veri kaynağına özeldir.
* Genellikle yalnızca bir tür sonucu döndürür.
* Sorgunun çoğu kısmı **yerel olarak (locally)** yürütülür.

#### 🔸 Orta Karmaşıklıkta Sağlayıcı (Medium Complexity)

* Kısmen ifade gücü olan bir sorgu dilini hedefler.
* Birden fazla web servisi metoduna erişebilir.
* Sabit bir tür sistemi sunar (ör. birden-çoğa ilişkiler).
* Kullanıcı tanımlı türleri haritalama (mapping) yeteneği yoktur.

#### 🔺 Karmaşık Sağlayıcı (Complex Provider)

* Örneğin **Entity Framework Core**, tam LINQ sorgularını **SQL**’e dönüştürür.
* Açık (open) tür sistemine sahiptir.
* Kullanıcı tanımlı türleri eşlemek için kapsamlı altyapı gerektirir.
* Geliştirilmesi oldukça zahmetlidir.

---

✨ **Kısacası:**
LINQ, C# içinde **veri sorgulama gücünü** doğrudan dilin bir parçası hâline getirir.
Farklı veri kaynaklarını **tek, tutarlı bir sözdizimiyle** sorgulamanı sağlar.
