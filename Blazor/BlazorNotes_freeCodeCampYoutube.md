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
- `Pages/`
  - `Counter.razor`
  - `Error.razor`
  - `Home.razor`
  - `Weather.razor`
