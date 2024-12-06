# Blazor dotnet Youtube

[Source](https://www.youtube.com/watch?v=CpbRAWgFBRQ)

## What is Blazer

Component based, Server and Client-side Rendering. Not limited to web applications but also mobile and desktop apps.

## Project Structure

We use Visual Studio 2022 to create a Blazor Project, server side rendering, name `BlazorApp1`.

We start at `BlazorApp1/` where define:

- the .NET version we the app will use
- Nullables
- EmplicitUsings, allowing us to use C# classes and methods everywhere

Followed by `program.cs`:

- Where we will build and allow the use of Blazor Components
- Configure the HTTP request pipeline
- Use redirection from HTTP
- Use static files, those downloaded by the client
- Use antiforgery a Blazor securty system
- Add interactive server render mode, allow a live change of the app
- Run the app

Followed by `wwwroot/`:

- Where the files downloaded are stored, such as styles and icon images. (HTML, CSS, JS)

Followed by `Properties/`:

- `launchSettings.json` where we can find ports or different dev environments, such as variables

Followed by `appSettings.json`:

- Loggins values, default parameter or third-party certifications such as azure
- `appSettings.Development.json`, we can create files for specific environments, staging and production

Followed by `Components/`:

- `App.razor`, the root HTML document, router and Blazor script tag
- `Router.razor`, mapping between URL
- `_Imports.razor`, using directives and namespaces for our BLazor components
- `Pages/`
  - `Counter.razor`
  - `Error.razor`
  - `Home.razor`
  - `Weather.razor`
- `Layout/`
  - `MainLayout.razor`, overall structure of the application
  - `NavMenu.razor`, navbar

## Blazor Components

A component file is a blend of HTML and C#. As an example for the `Home.razor`.

```cs
// Home.razor

@page "/" // Routes to this URL

<PageTitle>Home</PageTitle> // Adds a title, what we see as tab name

<h1>Hello, world!</h1>

Welcome to your new app.
```

Another example is the `Counter.razor`.

```cs
// Counter.razor
@page "/counter"
@rendermode InteractiveServer // A rendermode, allows live interaction with UI

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p> // Notice the field/variable @currentCount syntax

// Here, we have an event @onclick that runs the method 
<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

// Here, a code block for `.razor` files
@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

We can interact with the components by simply adding a HTML type tag to the page. Like this example, where the Counter component will be reused on the home page.

```cs
// Home.razor
@page "/"

<PageTitle>Home</PageTitle>

<h1>Hello, world!</h1>

Welcome to your new app.

<Counter /> // This here will load all the code on the `Counter.razor` component
```

Component can also have parameters, we can add them with a puclic C# property.

```cs
// Counter.razor
@page "/counter"
@rendermode InteractiveServer

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;
    
    [Parameter]
    // HERE,  we have our propety that will give us a .razor parameter
    public int IncrementAmount { get; set; } = 1; // initial value to 1

    private void IncrementCount()
    {
        currentCount+= IncrementAmount;
    }
}

// Home.razor
@page "/"

<PageTitle>Home</PageTitle>

<h1>Hello, world!</h1>

Welcome to your new app.

// HERE, the parameter is given to the property of the component
<Counter IncrementAmount="10"/> 
```

## Event Handling

Web UI events allow an interaction with the page. Here is a [source](https://developer.mozilla.org/en-US/docs/Web/API/UI_Events) of those.

Event handlers in Blazor are attached to HTML elements or Blazor components using special attributes.
As an example, let us use an event that reacts to the user input.

```cs
// Counter.razor
@page "/counter"
@rendermode InteractiveServer

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

<div class="m-3">
    <input type="text" @oninput="HandleInput"/>
    <p>@text</p>
</div>

@code {
    private int currentCount = 0;
    [Parameter]
    public int IncrementAmount { get; set; } = 1;
    string text = "";
    private void IncrementCount()
    {
        currentCount+= IncrementAmount;
    }
    /** 
    *   ChangeEnventArgs is an object, so we need to convert to string since text
    *   is a string type field for that we have a property for this object called Value.
    *   To avoid a compiler error of Null we add ! at the end.
    *   Other properties exist and allow other behaviours.
    */ 
    private void HandleInput(ChangeEventArgs e)
    {
        text = (string)e.Value!;
    }
}
```

Other events exist and they work on the same principles, `@onmouseover`, `@onkeydown`, @onfocus, @onblur, etc.

## Data Binding

We can use `@bind` to bind element attributes to a field or a property. For the example of a text type field binded to an input element, `@bind = "text"`, once we write and click away we can make it so it displays the binded text.

The same would work for an event, the syntax being `@bind:event = "eventName"`.

For a method is the same idea, for example run method after a binding happens, `@bind:after = "methodName"`

```cs
// Counter.razor

...
<div class="m-3">
    <input type="text" @bind ="text"/>
    <p>@text</p>
</div>

@code
{
  ...
  string text = "";
}
```

### Render Modes

---

Most of the seen here was covered on the dotnet videos.
Maybe explained in another way, but the core ideas are the same.
