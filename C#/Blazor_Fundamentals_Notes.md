# Learning Blazor on Pluralsight

## Blazor Fundamentals

ASP.NET Core Blazor == Blazor => Framework to build fullstack applications with HTML and C#

### Understanding the Hosting Models and Render Modes

- Describes how Blazor components are rendered
- Hosting models point to how code is hosted
- Changed with .NET 8

The Blazor Render Modes

- Static Server-side renderin (SSR): Rendering of static HTML content
  - HTML is generated on the server by components
  - Fast and lightweight, no code run on client
  - Same model as MVC or Razor Pages (stateless)
- Interactive Modes:
  - Interactive Server
    - Adds interactivity
    - Code executes on the server as Blazor Server
    - Backed by SignalR connection
    - Application instance is created per user ~ circuit
  - Interactive WebAssembly
    - Based on WebAssembly
    - Client-side execution in browser
    - Compiled application is downloaded, along with .NET runtime
  - Interactive Auto
    - Combines Interactive Server and Interactive WebAssembly
    - Component will render first as Server while application is downloaded
    - Subsequent runs will (tipically) run in Interactive WebAssembly

Blazor Hybrid: Can build native applications for descktop or mobile app with Maui

### Blazor App Template

- Blazor Web apps
- Blazor WebAssembly Standalone App
- .NET MAUI Blazor Hybrid App

Blazor Web App Template

- One tempalte for all your Blazor needs
- SSR-first but configurable for server and client interactivity

We created a Blazor Web app, server render.

Overview of the files generated:

#### Razor Components

- Main building block in Blazor applications
  - Component-based architecture
- *.razor files
- Razor syntax (C# and HTML)
- Contain UI and logic
  - Logic typically in a component class
- Server-de and client-side
- Often nested
- Reused across the application or in a library
- Partial class generated upon compilation
- By default, place in Components folder
  - Pages contains the routable components
  - Layout contains the layout components

Component names must start with **uppercase**!

```cs
// Home.razor
@page "/"
<PageTitle>Home</PageTitle>

<h1>Hello, world</h1>µ

Welcome to your new app.

<SampleComponent></SampleComponent>
```

- `App.razor`: root component containing the HTML
- `Routes.razor`: sets up the routing using Router
- `_Imports.razor`: brings in common Razor directives
- `wwwroot/`: static files
- `Program.cs`: entry point for the application

```cs
// Program.cs
...
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents(); // dependency injection

var app = builder.Build();

app.MapRazorComponents<App>(); // discover the razor components
...
app.Run();
```

Demo for a BlazorApp1, none for render type, so server static generated

Here are some of it's components and comments explaining some of it's parts:

```cs
// Program.razor
using BlazorApp1.Components;

/* setup of application host */
var builder = WebApplication.CreateBuilder(args);

/* service registration */
  // Add services to the container.
  builder.Services.AddRazorComponents();
/* service registration end */

var app = builder.Build();

/* middleware pipeline*/
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

  app.MapRazorComponents<App>(); // specify the root component

/* middleware pipeline end*/

/* run the app*/
app.Run();
```

For the `App.razor` file, our root component.

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
    <HeadOutlet /> // instantiating a component
</head>

<body>
    <Routes /> // instantiating a component
    <script src="_framework/blazor.web.js"></script>
</body>

</html>

```

Next the `Routes.razor` where the routing will be done, also the where we specify the dafault layouts.

```cs
// Routes.razor
<Router AppAssembly="typeof(Program).Assembly">
    <Found Context="routeData">
        // notice the "DefaultLayout" attribute, mapping to the "MainLayout" file inside Layout folder
        <RouteView RouteData="routeData" DefaultLayout="typeof(Layout.MainLayout)" />
        <FocusOnNavigate RouteData="routeData" Selector="h1" />
    </Found>
</Router>

```

Now for the layout component and the nav menu, all inside `Layout/` folder.

```cs
// Layout/ 
// MainLayout.razor
@inherits LayoutComponentBase

<div class="page">
    <div class="sidebar">
        <NavMenu /> // an instance of a component
    </div>

    <main>
        <div class="top-row px-4">
            <a href="https://learn.microsoft.com/aspnet/core/" target="_blank">About</a>
        </div>

        <article class="content px-4">
            @Body // a placeholder for the other components
        </article>
    </main>
</div>

// NavMenu.razor
<div class="top-row ps-3 navbar navbar-dark">
    <div class="container-fluid">
        <a class="navbar-brand" href="">BlazorApp1</a>
    </div>
</div>

<input type="checkbox" title="Navigation menu" class="navbar-toggler" />

<div class="nav-scrollable" onclick="document.querySelector('.navbar-toggler').click()">
    <nav class="flex-column">
        <div class="nav-item px-3">
            // Here we have another instance of a component the "NavLink" with some attributes 
            <NavLink class="nav-link" href="" Match="NavLinkMatch.All">
                <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true"></span> Home
            </NavLink>
        </div>

        <div class="nav-item px-3">
            // for example here when the button is clicked we are routed, href,  to /weather page
            <NavLink class="nav-link" href="weather">
                <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Weather
            </NavLink>
        </div>
    </nav>
</div>
```

For the `wwwroot/` folder we have files that will be downloaded by the client, HTML, CSS, images and JavaScript.

And a `appsettings.json` will allow for other things such as connection string to databases.

#### Interactive Render Modes

- None
  - All code will be executed on the server
- Interactive Server
  - Process .NET events with C#
  - Processed on the server

For an interactive render mode, type server we get another component, the `Counter.razor`. When we click on the button a message is sent to the server that responds thanks to the SignalR connection, updating the page DOM.

```cs
// Counter.razor
@page "/counter"
@rendermode InteractiveServer

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p> // razor syntax, '@' means that code is coming

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button> // @onclick is an event handler

// this is C# code, not JS
@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

We see a difference for a Server rendered app on our `Program.cs`

```cs
// Program.cs
...
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // here we see the interactive components
...

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // here interactive with the server
...
```

### Creating Your First Blazor Application

```cs
```

```cs
```
