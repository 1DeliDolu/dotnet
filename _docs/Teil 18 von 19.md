 # Nesne Yönelimli Programlama (OOP) (Teil 18 von 19) | C# für Anfänger

Bu bölüm C# ile nesneleri ve sınıfları modellemeyi anlatır. Scott Hanselman ve David Fowler'ın videosunun temel fikirlerine dayanır. Aşağıda kısa tanımlar, en iyi uygulamalar ve `Person`/`Pet` örnekleri (Türkçe) bulunmaktadır.

## Temel kavramlar
- Sınıf (class): Bir nesnenin (object) türünü tanımlar. İçinde alanlar (fields), özellikler (properties), yapıcılar (constructors) ve yöntemler (methods) bulunur.
- Nesne (object): Sınıfın bir örneği (instance).
- Encapsulation (kapsülleme): Veri ve davranışları sınırlandırmak için erişim belirteçleri (public, private, protected, internal) kullanılır.
- Inheritance (kalıtım): Bir sınıf başka bir sınıftan türeyebilir; kod tekrarını azaltır ve davranışı genişletir.
- Polymorphism (çok biçimlilik): Bir üst tür referansının alt tür örneklerini çalıştırabilmesi. `virtual`/`override` veya arayüzler (interfaces) ile sağlanır.

## Basit `Person` ve `Pet` örneği

```csharp
using System;
using System.Collections.Generic;

public class Person
{
	// Alan (field) - genelde private tercih edilir
	private readonly List<Pet> _pets = new();

	// Özellik (property)
	public string Name { get; private set; }
	public int Age { get; set; }

	// Yapıcı (constructor)
	public Person(string name, int age)
	{
		Name = name;
		Age = age;
	}

	// Davranış (method)
	public void AddPet(Pet pet)
	{
		if (pet == null) throw new ArgumentNullException(nameof(pet));
		_pets.Add(pet);
		pet.Owner = this; // ilişki kurma (composition)
	}

	public IReadOnlyList<Pet> Pets => _pets.AsReadOnly();
}

public class Pet
{
	public string Name { get; }
	public string Type { get; }

	// Sahip referansı (nullable başta)
	public Person? Owner { get; internal set; }

	public Pet(string name, string type)
	{
		Name = name;
		Type = type;
	}
}

// Kullanım
class Program
{
	static void Main()
	{
		var alice = new Person("Ayşe", 30);
		var dog = new Pet("Karabaş", "Köpek");

		alice.AddPet(dog);

		Console.WriteLine($"{alice.Name} adlı kişinin {alice.Pets.Count} tane hayvanı var: {alice.Pets[0].Name}");
	}
}
```

## Kalıtım ve çok biçimlilik

```csharp
public abstract class Animal
{
	public string Name { get; }
	protected Animal(string name) => Name = name;
	public abstract void Speak();
}

public class Dog : Animal
{
	public Dog(string name) : base(name) { }
	public override void Speak() => Console.WriteLine("Hav!");
}

public class Cat : Animal
{
	public Cat(string name) : base(name) { }
	public override void Speak() => Console.WriteLine("Miyav!");
}

// Kullanım örneği
Animal a = new Dog("Karabaş");
a.Speak(); // Dog.Speak çağrılır — "Hav!"
```

## Arayüzler (Interfaces)

```csharp
public interface IWalkable
{
	void Walk();
}

public class PersonWithWalk : Person, IWalkable
{
	public PersonWithWalk(string name, int age) : base(name, age) {}
	public void Walk() => Console.WriteLine($"{Name} yürüyor.");
}
```

## En iyi uygulamalar (best practices)
- Alanları doğrudan public yapmayın; bunun yerine özellikler (property) kullanın.
- Immutable (değişmez) veriler için readonly alanlar ve yalnızca get özelliği kullanın.
- Sınıfları küçük ve tek sorumluluklu tutun (Single Responsibility Principle).
- Public API dostu isimlendirme ve XML açıklamalarıyla (///) dokümantasyon ekleyin.
- `internal` ve `private` erişim belirteçlerini kullanarak kapsüllemeyi uygulayın.

## Notlar
- Örnekler basittir; gerçek dünyada hata yönetimi, null kontrolleri ve validation önemlidir.
- İsterseniz bu örnekleri çalıştırılabilir hale getirip `Program.cs` içine taşıyıp testlerini ekleyebilirim (örneğin `dotnet run` ile). Ayrıca, örneğe `record` tipleri ekleyerek immutable veri modelleri gösterebilirim.

