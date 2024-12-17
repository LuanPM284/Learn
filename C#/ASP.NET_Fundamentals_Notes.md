# Learning Blazor on Pluralsight

## ASP.NET Core: Big Picture

### What is ASP.NET Core is, What you can do with it, Theoretical and technical

All content can be found at: <https://github.com/RolandGuijt/ps-aspnetcore-bp>

Web application (framework) = Website HTML/CSS + Functionality, db

ASP/NET: Allows Frontend(content to the browser, could logic to access db) and Backend(API, rules for db) applications.

### What to build with ASP.NET Core

- Frontend
  - MVC
  - Razor Pages
  - Blazor
- Backend
  - Web API
  - gRPC
- Supporting
  - SignalR

### Tools

- Visual Studio
- Rider
- Visual Studio Code + CLI

### With the simplest application

The first part of the app `Program.cs` is executed:

```cs
// Program.cs
var builder = WebApplication.CreateBuilder(args); // A build object is created

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build(); // Get an app object

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run(); // Commanded to run, the app object

/* 
* Once the run is executed, the CLI application becomes an ASP.NET application
*/
```

### The Built-in Kestrel Web Server

Allows us to run our app localy, without a configured webserver.

We can later run the app .NET CLI app by passing throuh IIS Express, we can even run our app using Visual Studio by selecting the IIS Express on the run menu.

### Dependency Injections

Register => Manages the lifetime of objects => Instance

```cs
...
// Add services to the container.
builder.Services.AddRazorPages();
...
// Allows the instantiation of any object anywhere in our application
```

Method calls on the app object. The Request Pipeline, all these resquests are called midleware.

All midleware in order will have the chance to do something with a request, forming the response.

Extension methods that setup the middleware in the pipeline:

- Authorization
- Routing
- Static Files

The order is important.

```cs
...
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Starts with word USE
app.UseHttpsRedirection();

// Only files on the wwwroot/ folder can be accessed by this midleware
app.UseStaticFiles();

// Enables a general routing feature
app.UseRouting();

app.UseAuthorization();
// Makes sure the URL is met with the corresponding razor page
app.MapRazorPages();
...
```

### Razor is HTML with C\#

Example:

```cs
// Error.cshtml
@page
@model ErrorModel
@{
    ViewData["Title"] = "Error";
}

// HTML and CSS
<h1 class="text-danger">Error.</h1>
<h2 class="text-danger">An error occurred while processing your request.</h2>

// C# code
@if (Model.ShowRequestId)
{
    <p>
        <strong>Request ID:</strong> <code>@Model.RequestId</code>
    </p>
}

<h3>Development Mode</h3>
<p>
    Swapping to the <strong>Development</strong> environment displays detailed information about the error that occurred.
</p>
<p>
    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>
    It can result in displaying sensitive information from exceptions to end users.
    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>
    and restarting the app.
</p>
```

### Server-rendered Frontend Applications

On the github repos, we can find the same application built in the different wys ASP.NET Core allows.

On ASP.NET Core, we have *attributes* applied to the *propeties*.

These are called *Data Annotations*, they are used to do validation.

```cs
// Product.cs

using System.ComponentModel.DataAnnotations;

namespace CarvedRock_RazorPages.Data
{
    public class Product
    {
        public int Id { get; set; }

        // This is an attibute
        [Required, StringLength(50)]
        // This is a property
        public string Name { get; set; } = string.Empty;

        [Range(0.0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public string PhotoFileName { get; set; } = string.Empty;
    }
}
```

We can register classes on the dependency injection container:

```cs
// Program.cs

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IProductRepository, ProductRepository>();
/* Whenever there's an ask for IProductRepository provide an instance of ProductRepository
*  Using a singleton lifetime to register the type
*  it means only one instance will the created by the dependency injection container
*  for the total running time of the application
*/
```

Other types of Object Lifetimes

- Singleton: Create a sigle instance
- Transient: Create a new instance everytime there's an ask
- Scoped: Create an instance per incoming request

#### Razor Pages

Browser => GET carverock.eu/index: Server, Page named Index => HTML to the Browser

*index* is the first page rendered. File `Pages/Index.cshtml`

```cs
// Index.cshtml
@page // This makes it a razor page
@using CarvedRock_RazorPages.Data
@model IndexModel // model declared

<div class="row">
    <h4 class="mb-3 ml-5">Today's specials:</h4>
</div>

// Model here is used to render the products
// foreach iterating over a property on hte object callet Procduct
@foreach (var product in Model.Products)
{
    <div class="row mb-4">
        <div class="col-2 text-center"><img height="80" 
            src="Images/@product.PhotoFileName" alt="Product image" /></div>
        <div class="col-2 my-auto">@product.Name</div>
        <div class="col-2 my-auto">$@product.Price</div>
        <div class="col-2 my-auto">@product.Stock in stock</div>
    </div>
}

<div class="row">
    <div class="ml-5 mt-3">
        // Here we can see a tag helper *asp-page*, this attribute is processed by ASP.NET Core
        // when the page is rendered, takes the name of a page and turns it into an URL
        <a asp-page="Create">New product</a>
    </div>
</div>
```

We are missing some parts of the whole HTML page.

These are localted on the `_Layout.cshtml` file, that contains the surrounding HTML structure.

```cs
// _Layout.cshtml
<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Carved Rock</title>
    <link href="/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <header class="row">
            <div class="col-md-5 mb-4">
                <img height="150" src="/Images/carved-rock-logo.png" alt="logo" />
            </div>
            <div class="col-md-7 mt-5">
                For outdoorsy types
            </div>
        </header>
        @RenderBody() // The index page is rendered from here
    </div>
</body>
</html>
```

The Create page, by the tag helper.

```cs
// Create.cshtml
@page
@model CarvedRock_RazorPages.Pages.CreateModel

<h4>Add a product</h4>

<form method="post"> // Generates a POST request
    // asp-validation-summary: will display a list of all validation errors
    // as soon as they are present
    <div asp-validation-summary="All" class="text-danger"></div>

    <div class="row mb-2 form-group">
        <div class="col-3">
            // asp-for: references a property in a Model called NewProduct
            <label asp-for="NewProduct.Name"></label>
        </div>
        <div class="col-9">
            <input class="form-control" type="text" asp-for="NewProduct.Name"/>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <label asp-for="NewProduct.Price"></label>
        </div>
        <div class="col-9">
            <input class="form-control" type="text" asp-for="NewProduct.Price"/>
        </div>
    </div>
    <button type="submit" class="btn btn-primary">Add</button>
</form>
```

#### Data Binding

Bind values to an object.

Using the *name* attibute on the input tag. Once we have a POST request, ASP.NET will try and bind the values corresponding to the *name* to an object with a BindProperty attribute.

Here first we find *NewProduct* object and then the *.Name* property.

|Server| request |Browser|
|---|---|---|
|[BindProperty]<br> Product NewProduct { get; set;}|<= POST|<input name="NewProduct.Name" value = "Backpack"/\> <br> <input name="NewProduct.Name" value = "Backpack"/\>|
||||

#### MVC

Model - View - Controler

When GET request: redirected to a method (the action) of a Class (Controler), the URL *carverock.eu/product.index* will map to the controler *ProductController* with an *action* called Index.

Action will do the processing work(retrieve data). The data is then put into a Model object which is meant to the View to consume.

The view will then use the model (an instance of the object ?) to render the data, send HTML to Browser.

On the `Program.cs` we have most of the same code:

```cs
// Program.cs
...
// Add services to the container.
builder.Services.ADdControllersWithViews();
// Here we add this to the dependecy injection container
...
// We calll this, to define the routing rules
// the way url is mapped to controlers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}"
)
```

#### When to choose what

MVC vc Razor Pages

- Complexity: MVC > RP
- Routing: MVC > RP
- Separation: MVC < RP
- Changeability: MVC < RP
- Reusability: MVC > RP

### Client-rendered Frontend Applications

When a user access an URL of a client-rendered application, the request is handled by the server.

The server will send all frontend assets and logic. Single app apliactions 'SPAs', since everything is sent on the go.

Once all is recieved the browser logic will look at the URL determine which page has to be displayed.

All redirect will be handled by the browser itself, not the server.

In case of nedded data, the browser will reach out for the server and only ask for the data, no page HTML for the UI.

Blazor is the framework to use for a client based application.

Types of Blazor apps:

- Blazor WebAssembly
- Blazor Server

#### Blazor WebAssembly

A client-rendered, component-based single-page application frameword using .NET and C#.

Creating Blazor Applications == Writing components

Components can be reused.

Blazor WebAssembly: The server sends back a response in Assemblies + .NET runtime

WebAssembly: A language the browser can understand just like JavaScript. Lower level, binary. Code is compiled to WabAssembly.

Each component is translated into a Class in Blazor.

```cs
// Program.cs
using CarvedRock_BlazorWebAssembly;
using CarvedRock_BlazorWebAssembly.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

// Here we have our builder object
var builder = WebAssemblyHostBuilder.CreateDefault(args);
// Starting point of the application
builder.RootComponents.Add<App>("#app"); // App can then be referenced, since it's a Class

builder.Services.AddSingleton<IProductRepository, ProductRepository>();

await builder.Build().RunAsync();
```

The HTML is in the `wwwroot/index.html` folder.

```html
// index.html
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <title>CarvedRock-BlazorWebAssembly</title>
    <base href="/" />
    <link href="/bootstrap.min.css" rel="stylesheet" />
    <link href="/carvedrock.css" rel="stylesheet" />
</head>

<body>
    <div id="app">Loading...</div>

    <div id="blazor-error-ui">
        An unhandled error has occurred.
        <a href="" class="reload">Reload</a>
        <a class="dismiss">🗙</a>
    </div>
    <!-- Loading of a Blazor JavaScript file, loads the runtime and initializing the application-->
    <script src="_framework/blazor.webassembly.js"></script>
</body>

</html>
```

Inside the `App.razor`

```cs
// App.razor
// The attributes used on the component are properties in the class behind the component
<Router AppAssembly="@typeof(App).Assembly"> // A component on BLazor
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
    <NotFound>
        <PageTitle>Not found</PageTitle>
        <LayoutView Layout="@typeof(MainLayout)">
            <p role="alert">Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```

Inside the `index.razor` file:

```cs
// Index.razor
@page "/" // this will route the website, replace on the initial URL
@using CarvedRock_BlazorWebAssembly.Data
// this line will allow the injection of data into the class
@inject IProductRepository productRepository 

<div class="row">
    <h4 class="mb-3 ml-5">Today's specials:</h4>
</div>

@foreach (var product in Products)
{
    <div class="row mb-4">
        <div class="col-2 text-center"><img height="80" src="Images/@product.PhotoFileName" alt="Product image" /></div>
        <div class="col-2 my-auto">@product.Name</div>
        <div class="col-2 my-auto">$@product.Price</div>
        <div class="col-2 my-auto">@product.Stock in stock</div>
    </div>
}

<div class="row">
    <div class="ml-5 mt-3">
        <NavLink href="create">New product</NavLink>
    </div>
</div>

@code {
    private IEnumerable<Product> Products { get; set; } = 
        Enumerable.Empty<Product>();

    protected override async Task OnInitializedAsync()
    {
        Products = await productRepository.GetAll();
    }
}
```

For example, let's create a component that renders the logo using a certain height:

```cs
// Components/Logo.razor
// simple html, notice we reference a propertie called Height
<img height="@Height" src="/Images/carved-rock-logo.png" alt="logo" />

@code {
    // the parameter attribute it indicates that it can be set by another component
    [Parameter]
    public string Height { get; set; } = "200";
}

/*
* Here we see it being used in the Shared/MainLayout.razor
*/

﻿@inherits LayoutComponentBase

<PageTitle>CarvedRock-BlazorServer</PageTitle>

<div class="page">
    <div class="container">
        <header class="row">
            <div class="col-md-5 mb-4">
                // HERE, we provide a value for the height property
                <Logo Height="150" />
            </div>
            <div class="col-md-7 mt-5">
                For outdoorsy types
            </div>
        </header>
        @Body
    </div>
</div>
```

Now the logo component is created we can used it anywhere else on the project with different height if needed.

#### Blazor Server

Once an application starts it will establish a two-way connection (SignalR) between the Server and the Browser.

The landing page is rendered by the server and the browser gets the resulting HTML. The server will be notified of all user activities, process it and send back the new rendered HTML.

The differences are as follow:

```cs
// Program.cs
...
// uses the builder for a server rendered application
var builder = WebApplication.CreateBuilder(args);
// adds a RazorPages classs to the depedency injection container to render the pages
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IProductRepository, ProductRepository()>;
...

// here we have some midleware
app.UseExceptionHandler("/Error");
app.UseRouting();
// makes sure the SignalR(class that enables the two-way connection) hub is mapped to a URL
app.MapBlazorHub();
// when a non-SignalR request comes in, such as the very first root request the _Host will be rendered
app.MapFallbackToPage("/_Host");

app.Run();

/*
* _Host.cshtml
*/

@page "/"
@namespace CarvedRock_BlazorServer.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@{
    Layout = "_Layout";
}
// renders the app root component using a tag helper
<component type="typeof(App)" render-mode="ServerPrerendered" />
// after the App.razor is rendered and it's the same as for the Blazor WebAssembly
```

One difference is that the `_Layout.cshtml` now cointains the outer HTML structure and loads a javascript called "blazor.server.js" which will maintain the SignalR connection.

#### Comparing Both Versions

|Blazor WebAssembly |Blazor Server|
|---|---|
|Minimizes sever load|Server is a work horse|
|Scaling is cost effective|Potentially more scalling costs|
|Longer initial loading times|Normal initial loading times|
|Option to work offline|Requires connection|
|Retricted to browser capabilities| Can use most .NET APIs|

Both options: in .NET 8 and later: Full stack Blazor applications

We can start one on Visual Studio with a Blazor Web App.

Default Rendering Mode: Static, it switches to WebAssembly once all is loaded.

### Discoverin Backend API Applications

#### Backend API app

Backend
    - Web API
    - gRPC

An API has to be able to send and recieve data. We use serialization for that.

We transform C# objects into a format that can be sent over the wire.

An example: JSON

```json
{
    "id":1,
    "name":"Moutain Walkers",
    "price":219.5,
    "stock":12
}
```

APIs with Server-rendered Frontends

Server: API => Server: Razor Pages OR MVC => Browser: HTML

#### REST APIs with Web API

- Leverage HTTP protocol
- Each piece of data is available at a unique location (/products /product/1, ...)
- HTTP method are mapped to actions (GET get new data, POST introduce new data, PUT update data)
- HTTP status code are used to determine outcomes (200a all good, 404 not found, ...)
- Response can also contain pointers on what to do next

#### Web API

Example solution has 3 projects:

- CarveRock-BlazorWebAssembly
- CarveRock-Shared: A class library
- CarveRock-WebApi

```cs
// CarveRock-WebApi/Program.cs
using CarvedRock_WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();// add controler support to the dependency inject container
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

var app = builder.Build();

// support for Swagger, a support for OpenAPI a standard that describes a REST API
app.UseSwagger();
// also support for the UI, we can find it by: localhost:port/swagger/index.html
app.UseSwaggerUI();
// swagger acts as documentation for this API

app.UseHttpsRedirection();

app.UseCors(b => { 
    b.WithOrigins("https://localhost:7220"); 
    b.AllowAnyHeader(); 
    b.AllowAnyMethod(); 
});

app.UseAuthorization();

app.MapControllers(); // we map the controllers, without a routing table

app.Run();
```

The heart of the API

```cs
// CarveRock-WebApi/Controllers/ProductControllers.cs
using CarvedRock_Shared.Data;
using CarvedRock_WebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock_WebApi.Controllers
{
    [ApiController] // attribute allows API feature on the controller
    [Route("[controller]")]
    public class ProductController : ControllerBase // derives
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet] // allows routing
        public async Task<IActionResult> GetAll()
        {
            var products = await productRepository.GetAll();
            if (products.Count() == 0)
                return NoContent();

            return Ok(products);
        }

        [HttpGet("{id:int}")] // expects an int id on the URL
        public async Task<IActionResult> GetOne(int id)
        {
            var product = await productRepository.GetOne(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);
                
            await productRepository.Add(product);
            return CreatedAtAction(nameof(GetOne), new { id = product.Id }, product);
        }
    }
}
```

We can test it out by using the browser and url: *localhost:port/product*, we should see the JSON values.
And we can test further with an id *localhost:port/product/1*

Now for the Client part

```cs
// CarveRock-BlazorWebAssembly/Program.cs
using CarvedRock_BlazorWebAssembly;
using CarvedRock_BlazorWebAssembly.ApiServices;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// dependecy injector container
// HtppClient is the class to use to do HTTP requests, configures to send requests to the API
builder.Services.AddScoped(sp => // a lambda syntax is another way to register a type 
    new HttpClient { BaseAddress = new Uri("https://localhost:7273") });
builder.Services.AddScoped<IProductApiService, ProductApiService>();

await builder.Build().RunAsync();
```

#### Web API: Minimal APIs

We call another method `AddEndPointsApiExplorer()` that gives us the ability to specify endpoints directly in the pipeline by using MapGet method

```cs
// CarvedRock-WebApi/Program.cs
using CarveRock_webApi.Data;

var builder = WebApplication.CreateBuilder();

builder.Services.AddEndPointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddSingleton<IProductRepository, ProductRepository()>;

var app = builder.Build();
...
/* using the MapGet method on the app object
*  first parameter: endpoint name
*  second parameter: delicate type for which we have to specify a function
*/
app.MapGet("/product", async (IProductRepository productRepository)=>
{
    var products = await productRepository.GetAll();
    if (products.Count == 0)
        return Results.NoContent(); 
        // still return action result object, 
        // are now contained in the Results static class
    return Results.Ok(products);
});

app.MapGet("/products/{id:int}", async (int id, IProductRepository productRepository)=>{
    var product = await productRepository.GetOne(id);
    if(product == null)
        return Results.Notfound();
    return Results.Ok(product);
})
    .WithName("GetOne");

app.MapPost("/product", async (Product product, IProductRepository productRepository)=>{
    //no validation, we need to write our own

    wait productRepository.add(product);
    return Results.CreteAtRoute("GetOne", new { id = product.Id}, product);
});

...
```

#### gRPC API

RPC: Remote Procedure (a method) Call

The contract or the proto file, is shared between the actual API and the application that uses it called the client here.

Both have tooling that can take a proto file and generate code from it.
Example:

```cs
// .proto
Proto
{
    Foo();
}
/*
*  Classes are generated
*/ 
// API/ Server
virtual Foo()
{}
    "ProtoBuf"
// Client
Client.Foo()
```

For our gRPC example:

```cs
// Program.cs
using CarvedRock_gRPC.Data;
using CarvedRock_gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

var app = builder.Build();

app.MaprpcService<ProductService>();

app.Run();
```

#### Web API and gRPC Compared

|REST with Web API|gRPC|
|---|---|
|Content first (URLs, HTTP verb, JSON)| Contract first (proto file)|
|Message content is human reasable| Contract is human readable|
|Utilizes HTTP| Hides remoting complexity using RPC|
|suitable to external applications, public APIs| suitable to internal applicationsn, same organization, when contract changes it must be |

We can always use both depending on the use.

#### SignalR

A technique mainly used to call methods on clients from a server application.(For a list or page update for example, without a refresh).

The server application could be server rendered such as an MVC or Razor applications. Or API, gRPC.

The class present on the server that facilitates this is called a *hub*.

Using the `Hub` class, messages can be sent fto all/one/group clients.

SignalR: uses Remote Prodecute Call

Note recommended on most applications, only to send messages to update the UI.

### What to do Next

Pick a category\
Pick one technology from the category\
Watch a fundamentals course\
Check out Microsoft [documentation](https://learn.microsoft.com/en-us/aspnet/core/)\
Code along with sample application\
Start from scratch (create my own applicition)\
Choose other technology from category
Next category\
signalR last

- Frontend: Server-rendered
  - MVC
  - Razor Pages
- Frontend: Client-rendered
  - Blazor WebAssembly
  - Blazor Server
- Backend
  - Web API
  - gRPC
- Supporting
  - SignalR

Testinf Backend Applications:

- Web API: Swagger
- gRPC: Test client (console application)
