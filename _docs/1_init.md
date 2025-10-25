# C# 

## Konsol ile uygulama gelistirme

````bash
dotnet new console -o LibraryApp
````

````bash
cd LibraryApp
````
## MVC Olusturma

````bash
mkdir Models Controllers Views
````

```bash

## Dotnet 

````bash
dotnet
````

## Konsol Komut Bilgileri
````bash
PS D:\LibraryApp> dotnet

Usage: dotnet [options]
Usage: dotnet [path-to-application]

Options:
  -h|--help         Display help.
  --info            Display .NET information.
  --list-sdks       Display the installed SDKs.
  --list-runtimes   Display the installed runtimes.

path-to-application:
  The path to an application .dll file to execute.
  ````

## Konsol ile yapilabilcek komutlar bilgisi

  ````bash
  dotnet new
  ````

  ````
  PS D:\LibraryApp> dotnet new
Mit dem Befehl "dotnet new" wird ein NET-Projekt basierend auf einer Vorlage erstellt.

Allgemeine Vorlagen:
Vorlagenname       Kurzname  Sprache     Tags
-----------------  --------  ----------  ----------------------
Blazor-Web-App     blazor    [C#]        Web/Blazor/WebAssembly
Klassenbibliothek  classlib  [C#],F#,VB  Common/Library        
Konsolen-App       console   [C#],F#,VB  Common/Console        
Windows Forms-App  winforms  [C#],VB     Common/WinForms       
WPF-Anwendung      wpf       [C#],VB     Common/WPF

Beispiel:
   dotnet new console

Vorlagenoptionen anzeigen mit:
   dotnet new console -h
Alle installierte Vorlagen anzeigen mit:
   dotnet new list
Auf NuGet.org verfügbare Vorlagen anzeigen mit:
   dotnet new search web
````

## Konsol App gelistirme 

````bash
dotnet new console --force 
````

## Konsole App

````bash
PS D:\LibraryApp> dotnet new console --force 
Die Vorlage "Konsolen-App" wurde erfolgreich erstellt.

Aktionen nach der Erstellung werden verarbeitet...
Wiederherstellung D:\LibraryApp\LibraryApp.csproj:
Wiederherstellung erfolgreich.

````

## Konsole App Dosyalrini görme 

````bash 
dir
````

## Konsole App

`````bash
PS D:\LibraryApp> dir 


    ````bash
    PS D:\LibraryApp> dir

        Verzeichnis: D:\LibraryApp

    Mode                 LastWriteTime         Length Name                         For What
    ----                 -------------         ------ ----                         --------
    d-----        25.10.2025     11:30                bin                           Binary code (compiled output)
    d-----        25.10.2025     11:30                obj                           Build artifacts / intermediate files
    d-----        25.10.2025     09:57                _docs                         Project documentation
    -a----        25.10.2025     11:43            252 LibraryApp.csproj           Project file (MSBuild)
    -a----        25.10.2025     11:43            105 Program.cs                  Application source code
    ````
````

## Kode calistirma

````bash
dotnet run
````

## Cikti 

````bash
PS D:\LibraryApp> dotnet run 
Hello, World!
PS D:\LibraryApp> 
````

## VS code Acma 

````bash
code .
````

````bash 
dotnet new console -o TestProject

````
