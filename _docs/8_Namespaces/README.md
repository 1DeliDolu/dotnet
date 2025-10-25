# Namespaceleri Kullanarak Türleri Düzenleme

Bu not, "Declare namespaces to organize types" makalesinin ana fikirlerini özetler ve yalnızca açıklayıcı örneklerden oluşur.

## Neden namespace?
- .NET temel kitaplığı `System`, `System.Collections.Generic` gibi ad alanlarıyla düzenlenir; `System.Console.WriteLine("Hello World!")` çağrısında `System` namespace, `Console` ise o isim alanındaki sınıftır.
- `using System;` gibi yönergeler, tam nitelikli adı her seferinde yazma ihtiyacını ortadan kaldırır. Ayrıca `using ProjectApi = MyCompany.Project.Api;` biçiminde alias tanımlayabilir veya karmaşık durumlarda `extern alias` ile farklı assembly’lerdeki aynı isimli türleri ayırabilirsiniz.
- .NET 6 şablonları üst düzey ifadeler ve **implicit global using** desteğiyle gelir; SDK, web veya worker projeleri için sık kullanılan namespace’ler otomatik eklenir.

## Kendi namespace’ini tanımlamak
Küçük projelerde gerekmez, ancak geniş kod tabanlarında tür isimlerini çakışmadan yönetmek ve mantıksal gruplar oluşturmak için namespace oluşturmak önemlidir.

```csharp
namespace SampleNamespace
{
    class SampleClass
    {
        public void SampleMethod()
        {
            System.Console.WriteLine("SampleMethod inside SampleNamespace");
        }
    }
}
```

- Namespace ismi geçerli bir C# tanımlayıcısı olmalıdır.
- Yukarıdaki blok yapısı dışında, C# 10 ile gelen **dosya kapsamlı namespace** sözdizimi de kullanılabilir:

```csharp
namespace SampleNamespace;

class AnotherSampleClass
{
    public void AnotherSampleMethod()
    {
        System.Console.WriteLine("SampleMethod inside SampleNamespace");
    }
}
```

Bu biçim gereksiz süslü parantezleri kaldırarak dosyanın üst kısmını sadeleştirir.

## Namespace kavramının özellikleri
- Büyük projeleri hiyerarşik olarak düzenler; `.` operatörü ile alt alanlara ayrılır (`MyCompany.Data.Repositories`).
- `using` direktifi, her sınıf önüne namespace yazma zorunluluğunu kaldırır; ancak global namespace her zaman `global::` önekiyle erişilebilir (`global::System`).
- `extern alias` gibi ileri teknikler, farklı derlemelerdeki aynı adlarla başa çıkmayı sağlar.

## Daha fazla okuma
- [using directive](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/using-directive)
- [Implicit using directives](https://learn.microsoft.com/dotnet/core/project-sdk/overview#implicit-using-directives)
- C# dil spesifikasyonu: *Namespaces* bölümü
