# Personal Notes on learing C#
There are my notes, a way to save information while on my journey to learn `C#`.

I will be using *pluralsight* course for an introduction to the language and environment.

## C# Fundamentals
### Getting Started with C# and .NET
#### Setting up environment
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

#### Projects

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
│   │   │   ├──  HelloFromCSharp.json 
│   │   │   ├──  HelloFromCSharp.dll 
│   │   │   ├──  HelloFromCSharp.exe     (our executable file) 
│   │   │   └── HelloFromCSharp.pdb 
...
```
#### Debugging

Visual Studio has a degugger. It used Breakpoints: pause the running code, inspect and see different code lines.

We use the *green arrow* when running the program, the debugger is active.

For the breack point we can click on the left most side of the line, a grey circle
(red once clicked) is the indication. Can also see the memory space, by hovering mouse over variables. We can click continue next.

Once on debugging mode, we can run the application step by step (line by line) using the step over arrow on the top middle part of the screen, or click F10.

#### Building application using VScode and the CLI

CLI: commmand-line interface => for windows we use powershell

`dotnet` for running .net applications.

Creating a New project:

`dotnet new` for a  new application\
`dotnet run` to execute an application\
`dotnet build` to build the project

```bash
dotnet new console -n "FirstProgram"
# dotnet new: create new app
# console: type of app
# -n "FirstProgram": name of app
```
Here VScode will be used for the demo project.

First, install the SDk: https://dotnet.microsoft.com/en-us/download/dotnet/8.0 

On PowerShell:
```sh
cd to project Directory, my case Learn/C#/Projects

dotnet # gives us some information

dotnet new # gives us some types of applications I can create

dotnet new console -n "HelloWorldFromCLI" # creates new app and names the directory with flag -n

```
File structure of new project:
```
...
HelloFromCSharp/
HelloFromCLI/
├── obj/
│   ├──  HelloWorldFromCLI.csproj.nuget.dgspec.json
│   ├──  HelloWorldFromCLI.csproj.nuget.g.props
│   ├──  HelloWorldFromCLI.csproj.nuget.g.targets
│   ├──  project.assets.json
│   └── project.assets.cache
├── HelloWorldFromCLI.csproj
├── Program.cs
...
```

To run an app we write on terminal or powershell: `dotnet run Program.cs`

But from VScode we can use an extension (C# dev kit) that helps us run the app and the debbug.

Using Vscode we can do: 
- `CTRL + SHIft + P` to open a project manager
- write `.NET new project` to create new
- choose the kind of project, this case `console`
- select a folder, by files manager
- define name of the Program.cs
- accept, VScode will open the folder

VScode gives us a Solution Explorer just under the internal normal files manager. Like we have on visual studio.

We can than build the application by right clicking the project folder and selecting build.

Once a project is running we can debbug using breakpoints. We initiate a debbug by clicking F5 or right clicking the window.

The tutorial will use Visual Studio, but all can be done using the terminal or VScode.

#### Broswing the Docs
[C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)

### Learning the C# Syntax


```cs

```
```cs
```
```cs
```