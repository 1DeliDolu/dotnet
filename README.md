# Lernpfad: Einfache .NET-Anwendung

1. [Record-Typen in C#](1_RecordTypes/README.md)
2. [String ve Text](2_StringVeText/README.md)
3. [Sayılar ve Numerik Türler](3_NumericTypes/README.md)

## WSL 2 ile çalıştırma

Visual Studio'da WSL üzerinden hata ayıklayabilmek için `TODO.md` dosyasındaki adımları takip edin. Özetle:
- Visual Studio'da **.NET Debugging with WSL** bileşeninin yüklü olduğundan emin olun ve WSL dağıtımınızı hazırlayın.
- `Readme.sln` çözümünü açtıktan sonra `DotnetPlayground` projesi için `WSL` profillerinden birini seçin; `Properties/launchSettings.json` içerisinde varsayılan, Ubuntu 20.04 ve Debian profilleri hazır.
- Konsol uygulaması kullanıcı girdisi gerektiriyorsa, WSL terminalinde `dotnet run --project DotnetPlayground.csproj` komutunu çalıştırarak giriş akışına (stdin) erişebilirsiniz.

### WSL içinde Windows'taki `dotnet`'i kullanmak

WSL Ubuntu ortamında ek paket kurmadan Windows tarafındaki .NET SDK'yı kullanmak için:
1. WSL terminalinizde proje kökünde `scripts/wsl/enable-windows-dotnet.sh` çalıştırın.
2. Sonrasında `source ~/.bashrc` komutuyla güncel ortam değişkenlerini yükleyin (veya yeni bir shell açın).
3. Artık WSL içinde doğrudan `dotnet run` komutunu kullanabilirsiniz; çağrı, Windows'taki `/mnt/c/Program Files/dotnet/dotnet.exe` üzerinden çalışır.
