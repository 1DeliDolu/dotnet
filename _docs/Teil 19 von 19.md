 # OOP: Abstrakte & Abgeleitete Klassen, Überschreibungen (override) und `IEnumerable` (Teil 19 von 19) | C# für Anfänger

Bu bölüm, önceki `Person`/`Pet` örneğini genişleterek soyut (abstract) sınıflar, türemiş (derived) sınıflar, `virtual`/`override` mekanizması ve `IEnumerable` uygulamasını gösterir. Scott Hanselman ve David Fowler'ın videolarındaki adımları Türkçe özetler.

## Abstrakt sınıflar ve türetme
- `abstract` sınıflar, kendilerinden örnek (instance) oluşturulmayacak, ancak ortak davranışı ve imzaları tanımlayacak sınıflardır.
- `abstract` metotlar alt sınıflarda `override` edilmelidir.

```csharp
public abstract class Animal
{
	public string Name { get; }
	protected Animal(string name) => Name = name;

	// Tüm hayvanlar konuşabilir, fakat detay alt sınıfa bırakılıyor
	public abstract void Speak();

	// Sanal (virtual) bir metot; alt sınıflar isteğe bağlı olarak ezebilir
	public virtual void Describe() => Console.WriteLine($"Ben bir hayvanım: {Name}");
}

public class Dog : Animal
{
	public Dog(string name) : base(name) { }

	public override void Speak() => Console.WriteLine("Hav!");

	// Base sınıftaki Describe'i genişletme
	public override void Describe()
	{
		base.Describe(); // üst sınıf davranışını çağır
		Console.WriteLine("Ben sadık bir köpeğim.");
	}
}

public sealed class RobotDog : Dog
{
	// sealed sınıf artık daha fazla türetilemez
	public RobotDog(string name) : base(name) { }
	public override void Speak() => Console.WriteLine("Elektronik hav sesi");
}
```

## `virtual`, `override`, `sealed` ve `base` kısa hatırlatma
- `virtual` bir metot alt sınıflarda isteğe bağlı olarak ezilebilir (override edilebilir).
- `abstract` bir metot üst sınıfta gövdesi yoktur ve alt sınıflar tarafından zorunlu olarak override edilmelidir.
- `override` alt sınıfın metodu ile üst sınıf davranışını değiştirir.
- `sealed` anahtar sözcüğü bir sınıfın daha fazla türetilmesini veya bir metodun daha fazla override edilmesini engeller.
- `base.Method()` ile üst sınıf davranışı çağrılabilir.

## `Person` içinde `IEnumerable<Pet>` uygulaması — `yield return`
`Person` sınıfı genelde sahip olduğu `Pet` koleksiyonunu dışarıya `IReadOnlyList<Pet>` olarak verir. Alternatif olarak `Person`'a `IEnumerable<Pet>` uygulayarak `foreach` ile doğrudan `Person` üzerinden dönülebilir.

```csharp
using System;
using System.Collections;
using System.Collections.Generic;

public class Pet
{
	public string Name { get; }
	public string Type { get; }
	public Pet(string name, string type) { Name = name; Type = type; }
}

public class Person : IEnumerable<Pet>
{
	private readonly List<Pet> _pets = new();
	public string Name { get; }

	public Person(string name) => Name = name;

	public void AddPet(Pet pet)
	{
		if (pet == null) throw new ArgumentNullException(nameof(pet));
		_pets.Add(pet);
	}

	// Basit, güvenli bir enumerator sağlayan yield-return örneği
	public IEnumerator<Pet> GetEnumerator()
	{
		foreach (var p in _pets)
			yield return p; // her bir öğeyi döndürür
	}

	// Non-generic IEnumerable uygulaması için gereklidir
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// Kullanım örneği
class Program
{
	static void Main()
	{
		var person = new Person("Mehmet");
		person.AddPet(new Pet("Boncuk", "Kedi"));
		person.AddPet(new Pet("Pati", "Köpek"));

		// Person artık doğrudan foreach ile iterate edilebilir
		foreach (var pet in person)
			Console.WriteLine($"{person.Name} adlı kişinin hayvanı: {pet.Name} ({pet.Type})");
	}
}
```

`yield return` kullanmak, tüm koleksiyonu belleğe kopyalamadan öğeleri isteğe bağlı olarak üretmenizi sağlar (deferred streaming). Basit koleksiyonlar için doğrudan `_pets`'i döndürmek (`return _pets.GetEnumerator()`) da mümkündür; `yield` daha karmaşık üretim mantıkları için kullanışlıdır.

## Enumerable davranışı ve eşzamanlılık (thread-safety)
- `IEnumerable` uygulayan sınıflar, normalde dışarıdan koleksiyon değiştirilmediği sürece güvenlidir. Eğer çoklu thread'ler koleksiyonu değiştirecekse ek senkronizasyon veya kopyalama (`ToList()`) düşünün.

## Override örneği — davranışı genişletme

```csharp
public class AnimalPrinter
{
	public virtual void Print(Animal a)
	{
		Console.WriteLine($"Hayvan: {a.Name}");
	}
}

public class FancyPrinter : AnimalPrinter
{
	public override void Print(Animal a)
	{
		Console.WriteLine("*** BEGIN ***");
		base.Print(a); // üst sınıfın Print'ini çağır
		Console.WriteLine("*** END ***");
	}
}
```

## En iyi uygulamalar ve dikkat noktaları
- Abstrakt sınıflar ortak davranışı tanımlamak için iyi, fakat fazla derin kalıtım hiyerarşileri karmaşıklığı artırır.
- Arayüzleri (`interface`), birden fazla türetmeyi desteklediği için bazen abstract sınıflardan daha esnektir.
- `IEnumerable` uygularken mutable koleksiyonlarda enumerasyon sırasında değişiklik hatalarına dikkat edin (InvalidOperationException).
- `yield return` ile oluşturulan enumeratorlar, çağrıldıkları anda yürütmeyi durdurup gerektiğinde devam eder — side-effect içeren kodlarda dikkatli olun.

---
Bu dokümanı isterseniz çalıştırılabilir hale getiririm ve `Program.cs` içinde örnekleri `dotnet run` ile test ederek beklenen çıktıları eklerim. Hangi örnekleri çalıştırmamı istersiniz? (abstract/override, sealed, IEnumerable/yield)

