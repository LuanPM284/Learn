# Blazor dotnet Youtube

[Source](https://www.youtube.com/watch?v=sbXzifvMKXE&list=PLdo4fOcmZ0oXNZX1Q8rB-5xgTSKR8qA5k&index=4)

Blazor uses razor syntax that allows us to write code using C# directly into HTML. It also allows us to create components that can be reused in other parts of the file. The IDE gives us the option to separate both parts with the fales names: `.razor` => `.razor.cs`

Or even style type code, with `.css`.

We can add comments using `@*`.

In order to introduce code to the file we can use `@code` for a block of code, as seen here:

```cs
// Weather.razor
...

@code {
    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        // Simulate asynchronous loading to demonstrate streaming rendering
        await Task.Delay(500);

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        }).ToArray();
    }

    private class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
```

But we also can access other syntac like loops, `@for` or conditionals, `@if`, or even inside a table, `@foreach`.

In the same way variables are also called with a at `@` symbol.

Passing parameters to components, comes from the C# properties:

```cs
// Counter.razor

@code
{
    // new field, initialized at 0
 private int currentCount2 = 0;
    
 [Parameter] // This is what shows Blazor that the following protpertie is a parameter
 public int IncrementAmount { get; set; } = 1; // a new propertie in C#

 public void IncrementCount() // a method
 {
  currentCount2 += IncrementAmount;
 }
}
```

Once we have our [Parameter] we call can it on other components like the following:

```cs
// Home.razor

<Counter IncrementAmount = "2" />
```

We can create inline code blocks

```cs
@
{
    var amount = 1+1
}

<Counter IncrementAmount = "amount" />
```

## Pages, Routing and Layout

We can route, assign where the webpage will lead to, using `@page "/routeName"`. And we are not limited to one route.

```cs
// Counter.razor

@page "/counter"
@page "/counter2"
// Same page but accessible with 2 different routes
```

Passing parameters to a component using route:

```cs
// Counter.razor
@page "/counter/{initialCount}"
@page "/counter2"
// `/counter` no longer works since it must have a parameter

// We can make the parameter optional if we add a ?
@page "/counter/{initialCount?}"

// With this configuration nothind stops us to padd a strinf like "abc"
// We need to add constraints like the following
@page "/counter/{initialCount:int?}"

...;

<p>
@code
{
 private int currentCount = 0;

 [Parameter]
 public string InitialCount{get; set;}// routes from an URL are strings

 // Once the constraint is in place we can cahange the type to int
    public int InitialCount{get; set;}// routes from an URL are strings

 public void IncrementCount()
 {
  currentCount++;
 }
}
```

Doing something else, using a special Blazor component lifecycle method

```cs
@code
{
 // private int currentCount = 0;

    /*
    The override modifier is required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.
    */
    protected override void OnInitialized() // Here is the Blazor Component
    {
        currentCount = InitialCount;
    }


    /*
 [Parameter]
 public string InitialCount{get; set;}// routes from an URL are strings

 // Once the constraint is in place we can cahange the type to int
    public int InitialCount{get; set;}// routes from an URL are strings

 public void IncrementCount()
 {
  currentCount++;
 }
    */
}
```

The routes is handled by a component, the `Routes.razor`.

```cs
// Routes.razor

<Router AppAssembly="typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="routeData" DefaultLayout="typeof(Layout.MainLayout)" />
        <FocusOnNavigate RouteData="routeData" Selector="h1" />
    </Found>
</Router>
```

The `Routes.razor` are being used by `App.razor` the roots component. First component to render.

```cs
// App.razor

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="bootstrap/bootstrap.min.css" />
    <link rel="stylesheet" href="app.css" />
    <link rel="stylesheet" href="BlazorApp1.styles.css" />
    <link rel="icon" type="image/png" href="favicon.png" />
    <HeadOutlet />
</head>

<body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>
</body>

</html>
```

Blazor suppors Layouts, a common content that wraps all pages. We have Layout components. We can find them on the Loyouts directory.

```cs
// MainLayout.razor

@inherits LayoutComponentBase // Like a class, it inherits
// This allows us to use the @Body property to say wheret the page content should go
// the rest wraps around the content

<div class="page">
    <div class="sidebar">
        <NavMenu /> // Here is another component the `NavMenu.razor`
    </div>

    <main>
        <div class="top-row px-4">
            <a href="https://learn.microsoft.com/aspnet/core/" target="_blank">About</a>
        </div>

        <article class="content px-4">
            @Body
        </article>
    </main>
</div>

<div id="blazor-error-ui">
    An unhandled error has occurred.
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

The `NavMenu.razor` adds a new tag `<NavLink>` that created an anchor tag with the active state, type of animation.

Thr Router is the one applying the layout to all pages.

```cs
<Router AppAssembly="typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="routeData" DefaultLayout="typeof(Layout.MainLayout)" /> // Here Layout.MainLayout
        <FocusOnNavigate RouteData="routeData" Selector="h1" />
    </Found>
</Router>
```

We can add other layouts to different pages, using `@layout Layout.FileName` at the top.

```cs
// Home.razor

@page "/"
@layout Layout.FileName
...
```

## Blazor Web App Project Structure

Every project on C# has as `.csproj` project file.

- Here are settings and propeties on how our project will be built.
Also where dependdencies are specified.
- Entry point: `Program.cs`

```cs
// Program.cs

using BlazorApp1.Components;

var builder = WebApplication.CreateBuilder(args); // A method

// Nedded by Blazor to be able to use the components

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Building the App instance

var app = builder.Build();

// Setting up the midleware

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Call to the config on Blazor that routes the end points to the web application

app.MapRazorComponents<App>() // Route component of the`App.razor`
    .AddInteractiveServerRenderMode();

app.Run();
```

On `wwwroot/` folder is where all the static files that we want to be downloadable. Stylesheets, images, js files. Webaddressable.

On `Properties/` folder we have a `.json` type configuration file. `launchSettings.json` the settings and properties that run during development.

The `appSettings.json` here goes configuration data that I can use as part of my app. We have different files, that can be environment specific.

And the `Components/` folder with all the components, with the root being `App.razor`.

Special file, the `Imports.razor`, that contain razor directives that we can make available/import to all other razor files. Like a general area for the `using` in the razor files.

## Handling UI Events

Allows code to run once a certain event is triggered. Generally HTML events.

As seen before, an exemple would be the `@onclick` inside the tag, that will run the method. We can add other types of expressions like an async method or a lambda expression.

```cs
// Counter.razor

@page "/counter/{initialCount:int?}"
@page "/counter2"

@rendermode InteractiveServer

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

<p>InitialCount = @InitialCount</p>

@code
{

 private int currentCount = 0;
    
 protected override void OnInitialized()
 {
  currentCount = InitialCount;
 }

 [Parameter]
 public int InitialCount {get; set;}

    // a sync type event
 public void IncrementCount()
 {
  currentCount++;
 }

    // async method, delays the count for 1000 milliseconds so 1 second
    async Task IncrementCountAync()
    {
        await Task.Delay(1000);
        currentCount++;
    }

    // a lambda expression would be to change the following
    <button class="btn btn-primary" @onclick="() => currentCount++">Click me</button>
    // increment by 2 for exemple
    <button class="btn btn-primary" @onclick="() => currentCount+=2">Click me</button>

}
```

For an UI event such as `@onchange`, that will do something once the focus changes. An Event handler.

```cs
// Counter.razor
...

<div class="mt-3">
 <input @onchange ="OnChange"> // @onchange handler, Onchange method
 <p>@text</p> // show the text on screen once focus changes, after a tab for exemple
</div>

@code
{
    string text = "";
    ...
     private void OnChange(ChangeEventArgs e) // This was automaticly generated once choice was made, e for event
 {
  text = (string)e.Value!;    // convert the .Value that gives an object to string; the ! is to say no null
 }
}
```

Another hanfler can be `@oninput` that will change on input. The text value will be updated with every keystroke

Extra: We can rename by clicking F2.

```cs
<div class="mt-3">
 <input @oninput ="OnInput"> // @onchange handler, Onchange method
 <p>@text</p> // show the text on screen once focus changes, after a tab for exemple
</div>

@code
{
    string text = "";
    ...
     private void OnInput(ChangeEventArgs e) // This was automaticly generated once choice was made, e for event
 {
  text = (string)e.Value!;    // convert the .Value that gives an object to string; the ! is to say no null
 }
}
```

Another event handler, `@onmouseover` and `@onmouseout`. We will also use expression body for the methods. This will change the color and text when the mouse hovers over or it's outside the div.

```cs
// Counter.razor
...
<div style="background-color:pink" @onmouseover="MouseOver" @onmouseout="MouseOut">@divText</div>

@code
{
    string divText = "";
    ...
    // This:
        private void MouseOver(MouseEventArgs e)
        {
            divText = "Mouse over";
        }
    // Smae as this:
    private void MouseOver(MouseEventArgs e) => divText = "Mouse over";
    // This is expression body, IDE can transform it if we choose to
    private void MouseOut(MouseEventArgs e) => divText = "Mouse out";

}
```

Handle events from a component.

First let us create a new component. Called `MyButton.razor`

```cs
// MyButton.razor

<button @onclick="OnButtonClick">Click me!</button>

@code {
 [Parameter] // Define a Parameter for my component
    // property getter and setter
    // type EventCallBack a readonly struct
    // MouseeventArgs a class, suplies events 
 public EventCallBack<MouseeventArgs> OnClick{ get; set; }

    // an async method
     private Task OnButtonClick(MouseEventArgs e)
 {
  return OnClick.InvokeAsync(e);
 }
}

// But we notice that our @onclick can take a EventCallBack as the attribute so we can simplify by doing
<button @onclick="OnClick">Click me!</button>

@code {
 [Parameter] 
 public EventCallBack<MouseeventArgs> OnClick{ get; set; }

}
```

Now if we want to pass another HTML element to the button we can do the following:

```cs
// MyButton.razor

// we create another parameter
<button @onclick="OnClick">@ChildContent</button> // ChildContent will be rendered

@code {
    /*
 [Parameter]
 public EventCallback<MouseEventArgs> OnClick { get; set; }
    */

 [Parameter]
    // RenderFragment tells Blazor that will capture the content of the button component
 public RenderFragment ChildContent { get; set; }
}

// Counter.razor

<MyButton OnClick ="IncrementCount" >MyButton</MyButton> 
// Now we can capture the childcontent, in between tags, and display as button text
```

Now we want to style our button by writting on the class. But since we don't have a parameter as attribute Blazor throws us an error.

We will create a catch all type propery this case a Dictionary.

```cs
// MyButton.razor

// notice the razor directive @attributes, that will render 
<button @onclick="OnClick" @attributes = "AdditionalAttributes">@ChildContent</button>

@code {
    /*
 [Parameter]
 public EventCallback<MouseEventArgs> OnClick { get; set; }

 [Parameter]
 public RenderFragment ChildContent { get; set; }
    */

    // for any extra stuff that the user decides to put on MyButton
 [Parameter(CaptureUnmatchedValues = true)]
 public Dictionary<string, object> AdditionalAttributes { get; set; }
    // the type sent is string or objects, the type Bootstrap has prepared
}

// Counter.razor

<MyButton OnClick ="IncrementCount" class="btn btn-danger">MyButton</MyButton>
// now the class using Bootstrap should be alowed since we do have a catch all parameter
```

## Data Binding in Blazor

Get and update a value from inputs.

```cs
//Counter.razor
...

<div class="mt-3">
 <input value="@text" @onchange = "OnChange"> // value is an attibute present on input element
 <button @onclick = "OnClick">Clear</button> // onclick is an event handler from HTML events
 <p>@text</p>
</div>

@code
{
...
    // ChangeEventArgs, this is part of C# events
    // a method that will handle an event when the event provides data 
    private void OnChange(ChangeEventArgs e)// void since no return value
    {
        text = (string)e.Value!; // Value is an attribute from input element, convert the type object to string
    }

    private void OnClick(MouseEventArgs e)
    {
        text = ""; // We empty the string
    }

}
```

The way above works. But there is a simple way, using databinds. We are binding the input to the text value by usnig `@bind = "text"`. If one changes, the other will also change, we can also remove the `OnChange` event handler.

```cs
//Counter.razor
...

<div class="mt-3">
 <input @bind= "text">
 <button @onclick = "OnClick">Clear</button> // onclick is an event handler from HTML events
 <p>@text</p>
</div>

@code
{
...
    // ChangeEventArgs, this is part of C# events
    // a method that will handle an event when the event provides data 
    @*
    private void OnChange(ChangeEventArgs e)// void since no return value
    {
        text = (string)e.Value!; // Value is an attribute from input element, convert the type object to string
    }
    *@

    private void OnClick(MouseEventArgs e)
    {
        text = ""; // We empty the string
    }

}
```

We can also bind events, for example if we want the event to change with the input.

```cs
<div class="mt-3">
 <input @bind= "text" @bind:event= "oninput"> // We use ':' for an event bind
 <button @onclick = "OnClick">Clear</button> 
 <p>@text</p>
</div>
```

We can also have methods running after another event or in realtime. For example a search, while we are writting the search is happening.

```cs
<div class="mt-3">
 <input @bind= "text" @bind:event= "oninput" @bind:after= "search" > // We use ':' for an event bind
 <button @onclick = "OnClick">Clear</button> 
 <p>@text</p>
</div>

@code
{
    string searchResult;
    ...

    async Task Search() // Async function, so we need to wait for a response
    {
        searchResult = "Searching ..." // inital text, showing we are starting something
        await Task.Delay(2000) // we await 2 seconds
        searchResult = $"{Random.Shared.Next()} results!"
    }
}
```

Now let's try to use what we have seen until now. Creating a new page `Todo.razor`, don't forget to add it to the `NavMenu.razor`.

```cs
// NavMenu.razor
...
// Our own button on the navbar, just a copy of another
<div class="nav-item px-3">
    <NavLink class="nav-link" href="todo">
        <span class="bi bi-plus-square-fill-nav-menu" aria-hidden="true"></span> Todo
    </NavLink>
</div>

// Todo.razor
@page "/todo" // Routes to the todo when clicked
@rendermode InteractiveServer // Allows live interaction with the page, necessary for response 

// A text area where we display the checkboxes where the propertie IsDone is true 
<h3>Todo (@todos.Count(t => !t.IsDone))</h3>

// A list to display every todo item as an element
<ul>
 @foreach(var todo in todos) // A loop for every element on the list
 {
  <li> // Creates a list element
   @* @todo.Title *@ // Just the Title of the element on the list
   <input type="checkbox" @bind="todo.IsDone"> // An input binded to the IsDone property
   <input @bind="todo.Title"> // An input binded to the Title property
   </li>
            // Binded in the sense that it changes with input
 }
</ul>

<input @bind ="newTodo"> // A input binded with newTodo string, reacts to it's change
<button @onclick = "AddTodo">AddTodo</button> // A button with an event that runs AddTodo method

@code {
    // A list type that recieves objects of TodoItem that have a Title and a IsDone fields
 List<TodoItem> todos = new List<TodoItem>(); // A new instance of a list

 string newTodo = ""; // An empty string for the input
 public class TodoItem // A class to be able to create a TodoItem object
 {
  public string Title { get; set; } // A field that is able to get and set values, property

  public bool IsDone { get; set; } // A field that is able to get and set values, property
 }
 private void AddTodo(MouseEventArgs e) // A method for the TodoItem Class
 {
  if(!string.IsNullOrWhiteSpace(newTodo)) // A string method to check if not a spave or null
  {
            // A list type method to add into the list
            // we add a new object of the type TodoItem and assign the newTodo input to the Title field
   todos.Add(new TodoItem { Title = newTodo }); 
   newTodo = ""; // We empty the input, to be reused
  }
 }
}

// An object is needed to store the values of the todo list items. 
// So we create a class that can instantiate objects.
// We bind the correct inputs and buttons to recieve and display data
```

## Component Render Modes

SSR (Static server-side rendering)
    - Enchance navigation & form handling: only what is fetched is downloaded
    - Streaming rendering: GET for data retrieval stream updates
Add client interactivity:

- Server: ASP.NET Core, real time with WebSocket
- WebAssembly: localy built
- both: Auto select render mode at runtime

For a new project we can choose the type of interactivity with the following:

```sh
#terminal
dotnet new blazor --interactivity
#OR -int
dotnet new blazor -int
# Options 
dotnet new blazor -int None|Server|WebAssembly|Auto
```

With this kind of webapp we have two projects, a server and a client:

```md
BlazorApp2
|-- BlazorApp2
|-- BlazorApp2.Client
```

The pages, like counter are on the `.client` project directory. No longer everything together.

In our `program.cs` we have the options:

```cs
...

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
...
```

Before we had to add the interactive rendermode so we could interact realtime with our code. We can also specify that when building the project.

```sh
dotnet new blazor -int Auto --all-interactive
#OR abreviation 
dotnet new blazor -int Auto -ai BlazorApp3 
```

The new solutions folder will contain two projects like before, but the component on the server project contain very little. Most of the pages are on the client side.

We can check that all components will be interactive, and can change the type of render, by looking at `App.razor`

```cs
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="@Assets["lib/bootstrap/dist/css/bootstrap.min.css"]" />
    <link rel="stylesheet" href="@Assets["app.css"]" />
    <link rel="stylesheet" href="@Assets["BlazorApp3.styles.css"]" />
    <ImportMap />
    <link rel="icon" type="image/png" href="favicon.png" />
    <HeadOutlet @rendermode="InteractiveAuto" />
</head>

<body>
    <Routes @rendermode="InteractiveAuto" /> // ---HERE---
    <script src="_framework/blazor.web.js"></script>
</body>

</html>
```

## Work with Data

We start a new project, name `BlazorMovieApp`.

We will try and do CRUD(Create Read Update Delete) operations.

A new class will be added:

```cs
// Movie.cs

using System.ComponentModel.DataAnnotations;

namespace BlazorMovieApp
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public string Price { get; set; }
    }
}
```

Following the load or write of the file we will add a scafolded Item: Razor Components using Entity Framework (CRUD) => CRUD => Movie => + sign and default => SQL Server

Now we get a new folder `MoviePages/` with all out CRUD default code

Before running the app we need to set up the database with the new database schema using Entity framework core. For that we need to add and apply a migration.

EFCore Migration

We will use the NuGet Packet Manager, we open the Package Manager Console:

```sh
# This will generate a migration file
Add-Migration Movies
# We will then update our database
Update-Database
```

Now we can run our application, no page is on the navMenu but we can go to "/movies". As we can see on the `index.razor` the route `@page "/movies"`.

This gives us access to a simple table and the option to create a new entry. We can do all the CRUD operations, it was created for us ussing the scaffold.

We can add addictional attributs. Such as 'Title', 'Format', 'Sortable'. Nothing will happen without an interactive rendermode so do no forget to add it.

```cs
// Index.razor
@page "/movies"
@using Microsoft.EntityFrameworkCore
@using Microsoft.AspNetCore.Components.QuickGrid
@using BlazorMovieApp
@using BlazorMovieApp.Data
@implements IAsyncDisposable
@inject IDbContextFactory<BlazorMovieApp.Data.BlazorMovieAppContext> DbFactory
// Here the interactive
@rendermode InteractiveServer
<PageTitle>Index</PageTitle>

<h1>Index</h1>

<p>
    <a href="movies/create">Create New</a>
</p>
// Here we changed Items from contect.Movie to FilteredMovies
<QuickGrid Class="table" Items="FilteredMovies" Pagination="State">
    // Pagination instance must be passed here
    <PropertyColumn Property="movie => movie.Title" Sortable="true">
        // Widget on the UI that we can attach to a column heading
        <ColumnOptions>
            <div>
            // Type seach, with bind to the variable that contains the search Query, autofocus for mouse stay
                <input type="search" @bind="titleFilter" @bind:event="oninput" autofocus/>
            </div>
        </ColumnOptions>
    </PropertyColumn>
    // Here we have attributes we can add
    <PropertyColumn Property="movie => movie.ReleaseDate" Title="Release Date" Format="dd/MM/yyyy"/>
    <PropertyColumn Property="movie => movie.Genre" />
    <PropertyColumn Property="movie => movie.Price" />

    <TemplateColumn Context="movie">
        <a href="@($"movies/edit?id={movie.Id}")">Edit</a> |
        <a href="@($"movies/details?id={movie.Id}")">Details</a> |
        <a href="@($"movies/delete?id={movie.Id}")">Delete</a>
    </TemplateColumn>
</QuickGrid>
// This is another built-in component like QuickGrid
// Asks for a state parameter, created on @code
<Paginator State ="State"/>

@code {
    // A state parameter instance
    PaginationState State = new PaginationState { ItemsPerPage = 2 }; // ItemsPerPage will limit the items per page displayed

    String titleFilter = "";
    // A property that returns a Query, here DB.Movie is context.Movie
    IQueryable<Movie> FilteredMovies => context.Movie.Where(m => m.Title.Contains(titleFilter));


    private BlazorMovieAppContext context = default!;

    protected override void OnInitialized()
    {
        context = DbFactory.CreateDbContext();
    }

    public async ValueTask DisposeAsync() => await context.DisposeAsync();
}
```

For more examples on quikgrid: <https://aspnet.github.io/quickgridsamples/>

## Forms & Validation

Way for users can submit data. We can see more of the bahaviour on `create.razor` on <\EditForm>, and <\InputText>, etc.

We can also add annotations to our data to chose validation types. As an example for our movie database.

```cs
using System.ComponentModel.DataAnnotations;

namespace BlazorMovieApp
{
    public class Movie
    {
        public int Id { get; set; }
        [Required] // This is makes it so Title is required, it creates a validation rule
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public string? Genre { get; set; }
        [Range(0,100)] // We can define a range, avoid negative
        public decimal Price { get; set; }
    }
}

// On create.razor, the component <DataAnnotationValidator> will look for the annotations 
// and determine the rules to run

// Other components also gives us errors when input no validated

// Notice that the components are not interactive since no rendermode is running, we can add that
// once that is active, the box becomes green showing the correct input was made
```
