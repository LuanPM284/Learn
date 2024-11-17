# Personal Notes on learing C#
There are my notes, a way to save information while on my journey to learn `C#`.

I will be using *pluralsight* course for an introduction.

## C# Fundamentals
### Setting up environment
Course uses: .NET 8, C# 12. For beginners *what-is-programming* recommended.

For this course the exercices can be found at *c-sharp-10-fundamentals-exercises*.

It's Object-oriented and type-safe. Backwards compatible.

Uses for the language:
- Console applications
- Descktop applications
- Web applications
- Mobile applications
- Services

IDE recommended: Visual Studio 2022; (Rider, .NET VsCode).

I will be using Visual Studio 2022.

### Projects

Container for code files => Compiled into exe file => Different templates

We can create a project sing the GUI, give a name and path. To start I will use a console application.

Once inside I can execute the file by using a button ▶ at the top, or click `F5`.

---

To print on screen we do:

```cs
Console.WriteLine("texte");
```
Where `texte` is surronded by `""` and all lines must end with a semi-colon `;`

For an exemple we have an input for the console:

```cs
// accepts an input
string name = Console.ReadLine();
// prints the input on console
Console.WriteLine("Hello " + name);
```
The file structure is the following:

```
c-sharp-10-fundamentals-exercises/
c-sharp-10-fundamentals-exercises.zip
Projects/
├── .vs/    (hidden file, for visual studio)
├── HelloFromCSharp/
│   ├── bin/
│   ├── obj/
│   ├── HelloFromCSharp.csproj      (project file)
│   └── Program.cs          (the program file, where code is written)
├── HelloFromCSharp.sln     (solution, a grouping of projects, organization)
```

For our application we can find it on the bin folder :

```
...
HelloFromCSharp/
├── bin/
│   └── Debug/
│   │   └── net8.0/
│   │   │   └── HelloFromCSharp.json 
│   │   │   └── HelloFromCSharp.dll 
│   │   │   └── HelloFromCSharp.exe     (our executable file) 
│   │   │   └── HelloFromCSharp.pdb 
...
```


```cs
```
```cs
```
```cs
```
```cs
```
```cs
```