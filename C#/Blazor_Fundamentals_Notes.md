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

###
