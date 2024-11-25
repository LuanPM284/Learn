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

> fix no suggestions appearing: Tools -> Options -> Text Editor -> [Language] -> General and making sure that Auto list members and Parameter information are checked

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

Visual Studio has a degugger. It used Breakpoints (F9 do add): pause the running code, inspect and see different code lines.

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
**Working with Dates**

DateTime, someDateTime, TimeSpan

```cs
DateTime emplyeeStartDate = new DateTime(2025,03,28);
DateTime today = DateTime.Today;
DateTime TwoDaysTime = someDateTime.AddDays(2);
DayOfWeek day = someDateTime.DayOfWeek;
bool isDST = someDateTime.IsDaylightSavingTime();
```
Exemple:
```cs
// instanciate some dates, we choose
DateTime hireDate = new DateTime(2022,3,28,14,30,0);
Console.WriteLine(hireDate);

DateTime exitDate = new DateTime(2025,12,11);

// operations with dates
DateTime startDate = hireDate.AddDays(15);
Console.WriteLine(startDate);

// using a function to check if correct month
DateTime currentDate = DateTime.Now;
bool areWeInDst = currentDate.IsDaylightSavingTime();

// here we start wotking with time and not date
// three variables, the time now, a timespan and the end hour
DateTime startHour = DateTime.Now;
TimeSpan workTime = new TimeSpan(8, 35, 0);
DateTime endHour = startHour.Add(workTime);

Console.WriteLine(startHour);
Console.WriteLine(endHour);

Console.WriteLine(startHour.ToLongDateString());
Console.WriteLine(endHour.ToShortTimeString());
// output:
// mardi 19 novembre 2024
// 01:27
```

**Converting Between Types**

Implicit conversion\
`int a = 123456789;`\
`long l = a // converting int to a long, since long can tale larger integer numbers, not data is lost`

Casting (Explicit conversion)\
`double d = 123456789.0`\
`int a = (int) d // we do lose data, but we can force it`

Helpers

Exemple:
```cs
int numberOfhoursWorked = 165;
long veryLongMonth = numberOfhoursWorked;// ok

double d = 123456789.0;

//int x = d; // error
int x = (int) d; // ok

int intVeryLongMonth = (int) veryLongMonth;
```
**Implicit Typing**

|Explicit typing| Implicit typing|
|---|---|
|`int a = 123;` | `var a = 123 //a will be an integer;`|
|`bool b = true;`|`var b = true //b will be a boolean;`|
|`double d = 11.0;`|`var d = 11.0 //d will be a double;`|

Using `var` we can say the type is *inferred*. No always as readable. Can also be used with a `DateTime` type object.

We cant't create a `var` type without a value.

exe: `var employeeAge; // it will not compile`

#### Adding Decision and Iteration Statements in C#

*Boolean Values:*
- `True` or `false`
- `bool` type
- Boolean operators:

|Operator|Example|
|---|---|
|==|a == b|
|!=| a != b|
|> or <| a > 10|
|>= or <=| a <= 10|

|Boolean Logical Operators||
|---|---|
|&&|AND|
| \|\| |OR|

> Exemples can be found on the m4 file, inside c-sharp-10-fundamentals-exercises ( only on local, machine)
---
*if statements:*\
Structure:
```cs
if(some Boolean expression){
    //Other statements
}
else
{
    //Other statements
    // The else blok is optional
}
For one statement we can ommit the curly braces
```cs
if(some Boolean expression)
    //Other statements ;
else
    //Other statements ;
```
For multiple conditions
```cs
if(Boolean expression)
{
    //Statement
}
else if(Boolean expression)
{
    //Statement
}
else
{
    //Statement
}
```
---
*switch statement*\
Structure:
```cs
switch(expression)
{
    case constant expression 1:
        //Other statements
        break;
    case relational expression 2:
        //Other statements
        break;
    ...
    default:
        //Other statment
        break;
}

//We can group equal outputs with a same case
switch()
{
    case expression 1:
    case expression 2:
        //Output
    break;
    ...
    default:
        //Output
        break; 
}
```
Some rules:
- Works for most data types
but not float and double
adding interations
- Case labels use a pattern: constant or relational.
- Each case must be unique
- First "true" will get executes (top to bottom)
- Default can be placed wherever we cant, always evaluated last
---

*Iterations*
- Continue exexuting a task (looping)
- Often used in comination with a counter
- Ask inout until stop is reached
- Keep reading files from disk

Loop Options in C#:
- `while`
- `do-while`
- `for`

A while loop:
- Condition is tested before the loop runs
- Statement will get execuutes as long as the expression is true
- Braces are required if more than one statement must be executes
- We can create infite moops!
```cs
while (Boolean expression)
{
    //statements
}

//An exemple of a nested while loop
int i = 0;
int j = 0;

while (i < 10)
{
    while(j<10)
    {
        Console.WriteLine("i:" + i + "  j:"+ j);
    }
    j=0;
    i++;
}
//Output:
// 100 lines
// i:0 j:0
// i:0 j:1
// i:0 j:2
// ...
// i:0 j:9
// i:1 j:0
// i:1 j:1
// i:1 j:2
// ...
// i:9 j:8
// i:9 j:9

//An infinite loop
while(true)
{
    Console.WriteLine(DateTime.Now);
}
```
---
A do-while loop:
- The statement is executes at least once

Structure:
```cs
do {
    //statements
}
while(Boolean expression)
```
---
A for loop:
- less fragile

Structure:
```cs
for(initiatization;Bollean;iterator)
{
    //statements
}`
//The 'continue;' allows us to go back to the start of the loop and continue the iteraction
//We can add statements that will only be executes on a condition is met
//The opposite of 'break' I can think
//An exemple:
Console.WriteLine("Enter a value: ");
int max = int.Parse(Console.ReadLine());

for(int i =0;i < max;i++)
{
    if(i==5){
        Console.WriteLine("Bingo" + i +" was found!")
        continue;
    }
    Console.WriteLine(i);
}


```
#### Methods

A way to group and reuse code.

**Undestanding Methods**

~~ Function or subroutines
- Code block
- Receives parameters (arguments) and returns value 
- Readable code and code reuse
- Declared within a class or struct

Structure:
```cs
<access modifier><return type> Method_name(Paremeters)
{
    //method statements
}
exe:
```cs
//Since we have a return type (int) we need a return statement, else we will get an error
public int AddTwoNumbers(int a, int b){
    return a + b; //stops the execution
}
```
Method without a Return Value
```cs
public void DisplaySum(int a, int b){
    int sum = a + b;
    Console.WriteLine("The sum is " + sum);
}
```
Invoking a Method
```cs
//We can pass arguments: values for the parameter(s)
...
DisplaySum(3,52);
//For the method with int return we will assign a varialbe to store the result
int result = AddTwoNumbers(55,44);
...
```
Creating a Method

First on the same Program.cs 
```cs
int amount = 1234;
int months = 12;

//For the void version
CalculateYearlyWage(amount, months);

//For the int version
int yearlyWage = CalculateYearlyWage(amount, months);

Console.WriteLine($"Yealy wage: {yearlyWage}");

Console.ReadLine();

//Void does not return a value so we can call the method
static void CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked)
{
   Console.WriteLine($"Yearly wage: {monthlyWage * numberOfMonthsWorked}");
}

// Here the return must be a int type
static int CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked)
{
    //Console.WriteLine($"Yearly wage: {monthlyWage * numberOfMonthsWorked}");
    if (numberOfMonthsWorked == 12)//let's add a bonus month
    {
        return monthlyWage * (numberOfMonthsWorked + 1);
    }
    return monthlyWage * numberOfMonthsWorked;
}
```
---
Adding a Helper File\
We will refactor (organize, maintaining the overall functionality) or code, starting by creating a Class.

We will add a new file to our project, called *Utilities.cs*. Once created using Visual Studio we get this template:
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM
{
    internal class Utilities
    {
    }
}
```
Now we will start working with Classes that are not present on the same file.
```cs
//Utilities.cs
...
namespace BethanysPieShopHRM
{
    internal class Utilities
    {
        public static int CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked)
        {
            //Console.WriteLine($"Yearly wage: {monthlyWage * numberOfMonthsWorked}");
            //return monthlyWage * numberOfMonthsWorked;

            if (numberOfMonthsWorked == 12)//let's add a bonus month
            {
                return monthlyWage * (numberOfMonthsWorked + 1);
            }
            return monthlyWage * numberOfMonthsWorked;
        }
    }
}
```
Now we can invoke the created class, by using the correct syntax:
```cs
//This will allow access to the Class
using BethanysPieShopHRM;

int amount = 1234;
int months = 12;
//Notice the 'Utilisies.'
int yearlyWage = Utilities.CalculateYearlyWage(amount, months);

Console.WriteLine($"Yealy wage: {yearlyWage}");

Console.ReadLine();
```
---
Calling the Correct Method

- Method name
- Paremeter types and arguments
- Number of parameters

Method Overloading: When we have method with the same name, but with differet number or type of parameters.

exe:
```cs
DisplaySum()

public static void DisplaySum (int a, int b)
{ ... }

public static void DisplaySum (int a, int b, int c)
{ ... }

//Exemple:

public static int CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked)
{
    //Console.WriteLine($"Yearly wage: {monthlyWage * numberOfMonthsWorked}");
    //return monthlyWage * numberOfMonthsWorked;

    if (numberOfMonthsWorked == 12)//let's add a bonus month
    {
        return monthlyWage * (numberOfMonthsWorked + 1);
    }
    return monthlyWage * numberOfMonthsWorked;
}

public static int CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked, int bonus)
{
    Console.WriteLine($"This early wage is: {monthlyWage*numberOfMonthsWorked+bonus}");
    return monthlyWage * numberOfMonthsWorked + bonus;
}

public static double CalculateYearlyWage(double monthlyWage, double numberOfMonthsWorked, double bonus)
{
    Console.WriteLine($"This early wage is: {monthlyWage * numberOfMonthsWorked + bonus}");
    return monthlyWage * numberOfMonthsWorked + bonus;
}
```
---
Understanding Variable Scope

- Variables exist in a defined region where they can be called or modified.
- For a function, new variables created inside are called *local variable*
- Global variables are shared for all files

More options with Methods
- Optional parameters
    - Sepcify default values for one or more paremeters
    - Caller can omit the optional ones

    Method with optional parameters

    ```cs
    public int AddNumbers(int a, int b, int c = 100)
    {
        int sum = a + b + c;
        return sum;
    };
    ```
    Calling the method

    ```cs
    //no third parameter
    AddNumbers(10,20);
    AddNumbers(10,20,30);
    ```

- Named arguents
    - Not required to follow order of parameters
    - One or more parameters can have a name defined when invoking the method

    Method with parameters
    ```cs
    public static AddNumbers(int a, int b)
    {
        ...
    };
    ```
    Using named arguments
    ```cs
    AddNumbers(b:10,a:20);
    //We can also use variables when calling
    int x = 1;
    int y = 2;
    AddNums(a:x,b:y);
    ```

- Expression-bodied syntax // Or arrow function for JS
    - 

```cs
public static void UsingExpressionBodiedSyntax()
{
    int amount = 1234;
    int months = 12;
    int bonus = 500;

    int yearlyWageForEmplyee1 = CalculateYearlyWageExpressionBodied(int bonus,int monthlyWage,int numberOfMonthsWorked);

    Console.WriteLine($" Yearly wage for employee 1(Bethany): {yearlyWageForEmployee1}");
}

public static int CalculateYearlyWageExpressionBodied(int bonus,int monthlyWage,int numberOfMonthsWorked) => monthlyWage * numberOfMonthsWorked + bonus;
```
---
Introducing the Main Method (is unique)
- Entry method which gets called upon start of the app ( by convention called Program.cs)
- Gets created implicitly now
- Top-level statements is default way

Exemple from Current and pre-C#10
```cs
//Program.cs (current), has Top-Level statements
Console.WriteLine("Hello, world!");

//Program.cs (pre-C#10)
Using System

namespace ConsoleApp1
{
    internal class Program
    {
        statix void Main(string[] args){
            Console.WriteLine("Hello, world!");   
        }
    }
}
```
#### Working with strings

Recap for Strings:
```cs
string firstName = "Bethany"; // type
string lastName = "Smith";
string s;
s = fristName; // reassign variable
var userName = "Bethany$"; // implicit typing
userName = userName.ToLower();

userName = "";//identical to string.Empty
```
Some Methods for strings
|Syntax|Explanation|
|---|---|
|`int l = myString.Length;`| Get the length of the string|
|`string upper = myString.ToUpper();`|Set the string to uppercase|
|`string lower = myString.ToLowert();`|Set the string to lowercasse|
|`bool b = myString.Contains("Hello);`|Check if a string contains "Hello", return bool|
|`string s = myString.Replace("a","b");`|Replace "a" with "b" in the string|
|`strin sub = myString.Substring(1, 3);`|Get a part of a string(zero-based)|
|`myString.Trim();`|Removes blank spaces|
Concatenating Multiple Strings
```cs
string s1 = "Learning C# "; //notice the extra spacce at the end
string s2 = "is awesome";
string s3 = s1 + s2;
// other option
string s3 = String.Concat(s1,s2);
//Output: "Learning C# is awesome" 
```
Better readability
```cs
string employeeName = "Bethany";
int age = 34;
string greetingText = "Hello" + employeeName + ", you are" + age + "years";
//Output: Hello Bethany, you are 34 years

// String.Format()
string greetingText = 
    String.Format("Hello {0}, tou are {1} years", employeeName, age);
//Output: Hello Bethany, you are 34 years

// String Interpolation
string greetingText = $"Hello {employeeName}, you are {age} years";
```
---
Using Escape Characters
- Always start with a \
```cs
Console.WriteLine("Here are the employee details: \nBethany \tSmith");
// \n for a new line
// \t for a tab space
```
- Representing a File Path
```cs
// Use a backslash
string escapedFilePath = "C:\\Documents\\readme.txt"
//Using Verbatim Strings
string verbatimFilePath = @"C:\Documents\readme.txt"
```

Testing Strings for Equality
```cs
// C# is case sensitive
string firstName = "Bethany"
bool b1 = fristName == "Bethnay";//true
bool b1 = fristName == "bethnay";//false
bool b1 = fristName.Equals("Bethany");//true

//We can compare by putting all on the same level

bool b = firstName.ToUpper() == anotherString.ToUpper();

// OR ToLower();
```
Parsing from String to Other Types
```cs
//A read method avveprs strings
string w = Console.ReadLine();
double wage = double.Parse(x) //convert to double

bool active = bool.Parse("true")

//Sometimes we can't be sure if parsing is possible, we use
TryParse();
// exe:
string enteredText = "true";
if (bool.TryParse(enteredText, out bool b))// Input, Output
{
    Console.WriteLine($"The value is {b}")
}
```
#### Creating a Class and Objects

Typical models ( used several times)
- Employee
- Customer
- Message
- Transaction

Custom Types
- Class
- Struct
- Record

Classes in C#
- Blueprint of an object
- Denifes data and functionality to work on its data
- Created using class keyword
- Foundation of OO (Object-Oriented)

The Class Template:
```cs
public class MyClass // public access mosdifier
{
    public int a;
    public string b;

    public void MtMethod()
    {
        Console.WriteLine("Hello world");
    }
}
```
Contents of a Class
- Fields - Class level variables that contain data
- Methods - A functionality that will work on the data, perform actions a change in state
- Properties
- Events

*Creating the Employee Class*
What defines an employee:
- Indentity: Name
- Attributes: Age, Wage
- Behaviours: Get paid, Perfom work
```cs
public class Employee
{
    public string firstName;
    public int age;

    public void PerformWork
    {
        // method code goes here
    }
}
```
Access Modifiers
- `public` - available outside of the Class
- `private` - only accessible whit in the Class
- `protected` - available for the Class and it's inheritors

Demo:
- Create a new application, my case Console type
- Name it BethanysPieShopHRM2
- Add a new Class named Employee.cs

Exemple:
```cs
//Fields
public string firstName;
public string lastName;
public string email;

public int numberOfHoursWorked;
public double wage;
public double hourlyRate;

public DateTime birthDay;

const int minimalHoursWorkedUnit = 1;

//Methods
public void PerformWork()
{
    PerformWork(minimalHoursWorkedUnit);
    //numberOfHoursWorked++;
    //Console.WriteLine($"{firstName} {lastName} has worked for{numberOfHoursWorked} hour(s)!");
}

public void PerformWork(int numberOfHours)
{
    numberOfHoursWorked += numberOfHours;
    Console.WriteLine($"{firstName} {lastName} has worked for{numberOfHours} hour(s)!");
}

public double ReceiveWage(bool resetHours = true)
{
    wage = numberOfHoursWorked * hourlyRate;

    Console.WriteLine($"{firstName} {lastName} has received a wafe of {wage} for {numberOfHoursWorked} hour(s) of work.");
    if (resetHours)
        numberOfHoursWorked = 0;
    return wage;
}

public void DisplayEmployeeDetails()
{
    Console.WriteLine($"\nFirst name: \t{firstName}\nLast name: \t{lastName}\nEmail:  \t{email}\nBirthday: \t{birthDay.ToShortDateString()}\n");
}

```
---
Using Objects

We can picture a Class as a blueprint, where the color it's a field. An Object would be a copy of the blueprint with a different color.
```
Class
    |----Object1
    |    Color:orange
    |----Object2
    |    Color:blue
    |----Object3
    |    Color:green
```
Creating a New Object
```cs
Employee employee = new Employee();
```
|Left side|Rigth side|
|---|---|
|`Employee employee = new Employee();`|
|Employee employee|new Employee();|
| `=` Assignment operator|
|Create a variable: Variable type Varaible name|new Object of Class Employee()|

Constructors
- called when instatiating an object happens
- Default or custom
- Used to set initial valuesss

Adding a Constructor with Parameters
```cs
public class Employee
{
    public string fristName;
    public int age;

    //Doesn't have a return clause, and same name as the Class name
    public Employee(string name, int ageValue) //Parameters not required
    {
        firstName = name; //Initial values for the fields
        age = ageValue;
    }
}

//Here the "Bethnay", 35 are the Constructor arguments
Employee employee = new Employee("Bethnay", 35);
//Using new keyword to generate an object of the Employee type
```
The Default Constructor
```cs
public class Employee{
    public Employee()
    {}
}
//Created when not define no other constructors
```
Shorthand to Create an Instance
```cs
Employee employee = new ("Bethany",35);
```
Call methods
|Code|Meaning|
|---|---|
|`Employee employee = new Employee();`| Instantiating the object|
|`employee.PerfomWork();`|Invoking a method|
|`employee.firstName = "Bethany";`| Changing a field|
|`int wage = employee.RecieveWage();`|Returning a value from method|
---
Using Primary Constructors
```cs
/* A new way to write a constructor where we don't need to specify
*  and variables are already available
*/
public class Employee (string name, int ageValue)
{
}
```

Demo
```cs
//Employee.cs

//Our constructors

//An exemple of an overloaded constructor
//we need to add the ": this" keyword to make a call to the "original"
//and passing it the values
public Employee(string first, string last, string em, DateTime bd) : this(first,last, em, bd,0)// here a zero is passed since we don't have a value for the rate
{
}

public Employee(string first, string last, string em, DateTime bd, double rate)
{
    firstName = first;
    lastName = last;
    email = em;
    birthDay = bd;
    hourlyRate = rate;
}

//Program.cs
// This is namespace, a group of Classes, need to be called
using BethanysPieShopHRM2;

Console.WriteLine("Creating an employee");
Console.WriteLine("--------------------\n");

Employee bethany = new Employee("Bethany","Smith","bethany@snowball.be", new DateTime(1979,1,16),25);

bethany.DisplayEmployeeDetails();

bethany.PerformWork();
bethany.PerformWork();
bethany.PerformWork(5);
bethany.PerformWork();

double receivedWageBethany = bethany.ReceiveWage(true);
Console.WriteLine($"Wage paid (message from Program): {receivedWageBethany}");

//Output:
/*
Creating an employee
--------------------


First name:     Bethany
Last name:      Smith
Email:          bethany@snowball.be
Birthday:       16-01-79

Bethany Smith has worked for1 hour(s)!
Bethany Smith has worked for1 hour(s)!
Bethany Smith has worked for5 hour(s)!
Bethany Smith has worked for1 hour(s)!
Bethany Smith has received a wafe of 200 for 8 hour(s) of work.
Wage paid (message from Program): 200
*/
```
#### Value Types and Reference Types

- Value types
    - Int, float, double, char
    - Fixed size, llocated by compiler on stack
    - Value is copied to this memory location 
- Reference types
    - Allocated on heap
    - Stack contains just a pointer to the memory address
    - Classes re reference types

```cs
//Value types
int a = 42;
int aCopy = a;
Console.WriteLine($"a : {a} and aCopy : {aCopy}")
//Output: a : 42 and aCopy : 42
//We have the same value 42, saved in two different places a and aCopy
aCopy = 100;
Console.WriteLine($"a : {a} and aCopy : {aCopy}")
//Output: a : 42 and aCopy : 100
//No changes were made to a even if aCopy recieved it before
// so two different places on the sctak(memory)

//Reference type
//We start by creating a new object for the custom class Employee
Employee bethany = new Emplopyee("Bethany","Smith","eamil","new DateTime (...)");
//We assign the object to a new object with a different name
Employee testEmployee = bethany;
//We change the value of the field inside the Class, or the object thate it references
// change the heap memory
testEmployee.firstName = "Gill";
//We display the values, by calling the Display method
testEmployee.DisplayEmployeeDetails();
```
---
Passing Data to Methods

Passing Parameters
- By value: Default if nothing else is specified
    - A copy is created for the method
    - Value in caller stays the same
- By reference: Require use of the ref keyword on parameters
    - A reference to the value is passed
    - no copy is made
    - Changes made in method affect original values
    - ref keyword is used
As explanation if I have a `int b` and use `ref b` on a method, if the `b` changes the 'original' `b` also changes.

Allows methods to change original valeus of the parameters.

Before a `ref` is invoked all ref values must be initialized (given a value).
```cs
int a = 33;
int b == 44;
AddTwoNumbers(a, ref b);
// b is 44
public int AddTwoNumbers(int a, ref int b)
{
    b+= 10;
    int sum = a + b;
    return sum;
}
// b is now 54
// Since with red I changed the reference of b and not just copied it's value
```
As `ref` keyword we also have `out`
- Out values don't need to be initialized (given a value, outside the method)
- multiple values can be returned
```cs
int a = 33;
int b;
int c; // Created but not initialized

public int AddTwoNumbers(int a, out int b, out int c)
{
    b = 10;
    int sum = a + b;
    c = sum / 10;
    return sum;
}
```
---
Strings Are Reference Types Too
- They point to the actually string in memory, so on the heap
```cs
string a = "Hello";
string b;
b = a; 
b += " world"; //This created a new string thay b will point to, that takes reference from string a
Console.WriteLine(a);//Output: Hello
Console.WriteLine(b);//Output: Hello world
```
Strings are immutable.(when 'changed' a new is just created and we can point to it)

String immutability can have a perfomance impact! Solution:

`StringBuilder`
```cs
StringBuilder stringBuilder = new StringBuilder();
stringBuilder.Append("Employee list");
stringBuilder.AppendLine("Bethany Smith");
stringBuilder.AppendLine("George Jones");
stringBuilder.AppendLine("Gill Cleeren");
string list = stringBuilder.ToString();
```
Working with Custom Types (.NEt and C#)
- Value types
    - Enumeration
    - Struct
- Reference types
    - Class
    - Interface
    - Delegate

Organizing Types in Namespaces
```cs
// Exe
System
├── System.Web
├── System.Collections
├── System.windows
├── System.IO
│   ├── System.IO.FileSystem
│   ├── System.IO.Compression
```
The `using` keyword
- A `using` statement only brings the types within the specified namespace, not the ones in nested namespaces

Global Usings (commonly used)
```cs
// <auto-generated>
global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
```
Demo: (Visual Studio Code)
- Browsing for exixting types
- suing a custom type
- Understanding global 

Visual Studio Code -> View -> Object Browser -> RigthClick & Namespaces

Bringing packages to our Projects\
RigthClick on Project directory -> Manage NuGet Packages
- Browse the wanted package and intall
- It will be installed under Dependencies
- Must use ´using´ statement to bring it in to be used
---
Creating Enumerations
- Named constants for improved readability
- Value type (integer vammue with a name)
- Uses `enum` keyword
```cs
enum EmployeeType
{
    Sales,//0, behind the scenes C# assings default value starting from 0
    Manager,//1
    Research,//2
    StoreManager//3
}
```
Using enumeration (or a new custom type)
```cs
//EmployeeType.cs

namespace BethanysPieShopHRM2
{
    // internal class EmployeeType
    enum EmployeeType
    {
        Sales,//0
        Manager,//1
        Research,//2
        StoreManager//3
    }
}
//It can now be used in other classes or our program
```
---
Working with Struct
- Value type
- Represents a custom data structure
- Can be new'ed
- Can contain methods and other members
```cs
struct WorkTask
{
    //Fields
    public string description;
    public int hours;
    //Methods
    public void PerformWorkTask()
    {
        //Code to perform work
    }
}
```
Like `enum`, enumerate, we create it with a new Class file.
```cs
namespace BethanysPieShopHRM2
{
    // internal class EmployeeType
    internal struct WorkTask
    {
        public string description;
        public int hours;

        public void PerformWorkTask()
        {
            Console.WriteLine($"Task {description} of {hours} hour(s) has been performed.")
        }
    }
}
```
#### More with Classes and Custom Types

**Grouping Classes in Namespaces**

Namespaces
- Keep class names separate
- Used throughout .NET
- Organize out own classes in custom namespaces
- Make namespace available through `using` directive
```cs
namespace BethanysPieShop.HR // just a string; Rootnamespace.Custom_Namedspace
{
    public class Employee
    { }
}

//File)csoped Namespaces
namespace BethanysPieShop.HR; //All code on this file is part of the namespace

public class Employee
{ }
```
Working with namespaces
```cs
//If we create a folder inside out project and add a new class, 
// by convetion it takes the name concatenated

//When calling a new custom type we can do by their name or fully qualify the type
using Customer
Customer... ;

// OR

BethanysPieShopHRM2.Accounting.Customer customer = new BethanysPieShopHRM2.Accounting.Customer();
```
---
Static Data
- It's defined on the class level and not on the obj level, shared with all objs
- So I can use it without instantiating an object of this class
- Static methods can only work with static Data
```cs
public class Emplopyee
{
    //Satic field
    public static double bonusPercentage = 0.15;
    //Static method
    public static void IncreaseBonusPercentage(double newPercentage)
    {
        bonusPercentage = newPercentage;
    }
}

//exemple
static void Main(string[] args){ // on main file, program.cs
    Employee.IncreaseBonusPercentage(0.2); //Note the class name, not the object

    Employee.taxRate = 0.02; // It will change the value for all once it passes this point on code

}
```
A `region` is a way to collapse code:
```cs
#region Name of the region

Code
Code
Code
#endregion
```
By clicking F12 when cursor over method it brings us to their definition

---
Working with null
(Stack --- Heap)
```cs
Employee employee;
//employee is null, variable created on the stack but not instantiated
employee = new Emplopyee(); //now a new obj is created on the Heap 
// and the employee refrence is pointed to the actual obj on the heap

//When obj not created we get an error
Employee employee = null;
employee.PerformWork();//runtime error: NullReferenceException

//We can also break the reference to the obj by declaring the variable null
employee = null;
```
Nullable Value Type
- represents the actually underligning type + the null
- if we don't have a value but need an int type, int nullable value type
```cs
int? a = 10;
int? b = null;
if (b.hasValue)//check
{
    Console.WriteLine("We have a balue");
}
```
When We use Null values
- We can add `.Value` ather the variable to get the value of the nullable
- OR 
- we can use null coalescing operator
```cs
hourlyRate = rate;
hourlyRate = rate ?? 10; //If rate is null use the right hand-side
```
---
Garbage Collection
- When objects are created but lose their connections or references they stay on the heap memory
- Garbage Collctor will remove those objects that do not run on the application
- Cleaning up unreachable objects

Visual Studio - Diagnostic Tool

```cs
#region 
// Heavy memory code
// Heavy memory code
// Heavy memory code
#endregion 

GC.Collect(); // Will force a clear
```
---
Using a Class from an External Library
- .NET Class Lib
    - Console class
- Custom libs
    - WageCalculation class
- Out application
    - using NameSpace;

Visual Studio - 
Project - RigthClick -> Add -> Project Reference... -> Browse -> FilePath to the .dll
Under Dependencies we will add an extra node

To rewrite a same value we can do CTRL + R CTRL + R and apply

---
C# Records (C#12)
- New reference type
- Can replace class
- Aimed at "just" containing data, can contain other members though
- Come with additional functionality built-in (generated)
```cs
public record Account;
public record class Account;
public record struct Account; //A value type

//Primary Constructors
public record Account(string AccountNumber);//Positonal record

Account newAccount = new("123-456");
```
Why records?
- Passing around "just" data
- Used for data that shouldnt be changed after creation

- Immutability
- Value-based equality
- Concise

```cs
Employee emp1 = new Employee("Bethany");
emp1.FirstName = "Gill"; //error

//when == we check for same reference when objects
//for classes we get a false, for records we get a true
//way to verify if two objs have a same value
```
We change the class Acccount to a Record, we can since we "only" store data

Exe:
```cs
//Normal record
    public record Account
    {
       private string accountNumber;

       public string AccountNumber
       {
           get { return accountNumber; }
           set
           {
               accountNumber = value;
           }
       }
    }

    //Positional record
    public record Account(string AccountNumber);    
```
####
```cs
```