### 📘 LINQ Sorgu İşlemlerinde Tür (Type) İlişkileri (C#)

LINQ sorgularını etkili bir şekilde yazmak için, bir sorgu işleminin tüm değişken türlerinin birbiriyle nasıl ilişkili olduğunu anlamak önemlidir. Bu ilişkileri anladığınızda, LINQ örneklerini ve belgelerdeki kodları daha kolay kavrayabilir, ayrıca **`var`** kullanıldığında nelerin olup bittiğini daha iyi anlayabilirsiniz.

---

### 🔒 Güçlü (Strong) Tür Bağlantısı

LINQ sorguları; **veri kaynağında**, **sorgunun kendisinde** ve **sorgu yürütülmesinde** güçlü bir şekilde türlendirilmiştir.
Yani:

* Veri kaynağındaki öğe türü ile sorgu değişkenlerinin türü **uyumlu** olmalıdır.
* Bu, **derleme zamanında tür hatalarını** yakalayarak hataların erken düzeltilmesini sağlar.

---

### 🧩 Veri Dönüştürmeyen Sorgular

Bu tür sorgularda veri tipi değişmez.
Örneğin, kaynak bir **string dizisi** ise, sonuç da **string dizisidir**.

> **İlişkiler:**
>
> * Veri kaynağının tür argümanı, aralık (range) değişkeninin türünü belirler.
> * `select` ifadesindeki nesne türü, sorgu değişkeninin türünü belirler.
> * `foreach` içindeki döngü değişkeni de bu türe uygun olmalıdır.

---

### 🔄 Veriyi Dönüştüren Sorgular

Bir sorgu, örneğin bir `Customer` nesnesinin yalnızca `Name` özelliğini seçiyorsa:

* Veri kaynağının türü: `Customer`
* Sorgu sonucu: `string`
* `foreach` değişkeni: `string`

---

### 🧱 Daha Karmaşık Dönüşümler

Eğer `select` ifadesi, `Customer` nesnesinin sadece iki özelliğini (örneğin `Name` ve `City`) seçip **anonim bir tür** oluşturuyorsa:

* Veri kaynağı türü: `Customer`
* Sorgu sonucu türü: anonim tip
* Bu durumda hem sorgu değişkeni hem de döngü değişkeni `var` ile tanımlanmalıdır.

---

### 🧠 Tür Çıkarımı (Type Inference) ile `var` Kullanımı

C# derleyicisi, `var` ile tanımlanan değişkenin türünü **otomatik olarak çıkarabilir**.
Bu, özellikle karmaşık jenerik türlerde kodu okunabilir kılar.

---

### ⚙️ LINQ ve Generic Türler

LINQ sorguları **generic türler** üzerine kuruludur.

Örneğin:

```csharp
List<string> names = new List<string>();
List<Customer> customers = new List<Customer>();
```

* `List<T>` içinde `T`, listedeki öğe türünü belirtir.
* `IEnumerable<T>` arayüzü, koleksiyonların `foreach` ile yinelenmesini sağlar.

---

### 💡 `IEnumerable<T>` Kullanımı

Bir LINQ sorgusunun sonucu genellikle **`IEnumerable<T>`** veya türevi **`IQueryable<T>`** türündedir.

```csharp
IEnumerable<Customer> customerQuery =
    from cust in customers
    where cust.City == "London"
    select cust;

foreach (Customer customer in customerQuery)
{
    Console.WriteLine($"{customer.LastName}, {customer.FirstName}");
}
```

---

### ✨ `var` ile Tip Belirtimini Basitleştirme

Aşağıdaki örnek, yukarıdakiyle **aynı sonucu** verir ancak türler derleyici tarafından çıkarılır:

```csharp
var customerQuery2 =
    from cust in customers
    where cust.City == "London"
    select cust;

foreach (var customer in customerQuery2)
{
    Console.WriteLine($"{customer.LastName}, {customer.FirstName}");
}
```

> 🔹 `var`, özellikle karmaşık veya açıkça görünen türlerde faydalıdır,
> ancak **aşırı kullanımı** kodun okunabilirliğini azaltabilir.

---

### 💬 Özet

* LINQ sorguları **tür açısından sıkı bağlıdır**.
* `IEnumerable<T>` ve `IQueryable<T>` temelinde çalışır.
* `var`, türleri otomatik çıkarır ama **dikkatli** kullanılmalıdır.
* Tür dönüşümü yapan `select` ifadelerinde `var` genellikle zorunludur.
