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

#### Browsing the Docs
[C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)

### Learning the C# Syntax
Types, operators, date and time

#### Essentials C# Building Blocks
**Statements**

Actions => Flow of the program => End with semicolon, no spaces or line changes. 

We can denfine identifiers (sart with a letter or underscore and can contain letters, digits and underscores)

**Comments**

// For a comment line

/*
    Block comment
*/

**Variables**

A variable hodls value. They must be of a type ( Integer, string, date...).
We create a variable by declarating.

```cs
// these are different for C#, a =! A
int age;
int Age;
```
CamelCase is a convention.

Assigning a variable.

```cs
int age;
// '=' is an Assignement operator
age = 25;
```
#### Demo

We create a new project name BethanysPieShopHRM.

We can move lines by holdinh *alt + arrow keys*

Or Comment a line or multiple selected with *CTRL + K + C* and unComment with *CTRL + K + U*

**Types**

C# is a strongly typed language.

Size and location in memory, Data range and supported operations.

Data types in C#: Predefined, Created

Predefined (primitive data types):
- bool
- int
- float
- double
- deciman
- char

- byte (sbyte) - short bute, numbers from 0 - 255
- short (ushort)
- object
- string

Creating an Integer Value
```cs
int a = 2;
int b = a + 3; // an expression, types must be the same on both sides
```
Types are immutable.

An exemple from the demo project:
```cs
// an int type, so numerical
int monthlyWage = 1234;
// we can addign in the same line, same types
int months = 12, bonus = 1000;
// bool true or false
bool isActive = true;
// a real type number, decimal
double rating = 99.25;

// byte only acepts up to 255
//byte numberOfEmplyees = 300; // too big a number

// varaible created, not assign any value
int hoursWorked;

// I can assign a value without the type if already exists
hoursWorked = 125;

hoursWorked = 148; //  I can change the value by reassigning

montlyWage = true; // I get an error, since the var is an intn this is type dafety
```
**Using a const Value**

A variable that does not change.
```cs
const double interestRate = 0.07;

interestRate = 0.08; // error
```

**Strings**

A list of characters. Stored as list of char objects.

```cs
string s1 = "Hello World";
string s2 = string.empty;
```
Exemple:
```cs
string firstName = "Bethany";
string lastName = "smith";

string emptyString = "";

Console.WriteLine("Please enter your name");
string name = Console.ReadLine();
```

**Operators**

Aritmetic, Equality, Logical and Assigment operators.
(+,-,*,/,++,--)

Exemple:
```cs

double ratePerHour = 12.34;
int numberOfHoursWorked = 165;
// here we use + and *
double currentMonthWage = ratePerHour * numberOfHoursWorked + bonus;
Console.WriteLine(currentMonthWage);

ratePerHour += 3; // same as ratePerHour = ratePerHour + 3
Console.WriteLine(ratePerHour);

// not yet seen, a condition
if (currentMonthWage > 2000)
    Console.WriteLine("Top paid employee!");

int numberOfEmployees = 15;
numberOfEmployees--; // -1 to the variable

bool a; // false by default, or nor assigned
int b; // 0 by default
```
**Build-in types**

[Documentation](https://learn.microsoft.com/en-us/dotnet/api/system.int32?view=net-8.0)

Members on Primitive Types:
```cs
int intMaxValue = int.MaxValue;
int intMinValue = int.MinValue;
double doubleMaxValue = double.MaxValue;

// for char; used to store single UNIcode characters, and require single quotes ''
char myChar = 'a';
bool isWhiteSpace = char.IsWhiteSpave(myChar);
bool isDigit = char.IsDigit(myChar);
bool isPunctuaction = char.IsPunctuaction(myChar);
```
Exemple:
```cs
// we can use the deggub mode, and hover the mouse pointer over to see the values stored

int intMaxValue = int.MaxValue; // 21,474,883,647 for an int
int intMinValue = int.MinValue; // -21,474,883,647

char userSelection = 'a'; // 97 on unicode
char uppperVersion = char.ToUpper(userSelection); // A: 65 on unicode 

bool isDigit = char.IsDigit(userSelection); // false

bool isLetter = char.IsLetter(userSelection); // true

Console.ReadLine(); // this is used just to stop the debbug here 
```
```cs
```
```cs
```
