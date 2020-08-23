# Hello world for ASP .NET Core web 
This is a project to reinvent the wheel in the key components of ASP .NET Core

### Related source code

* [.NET Core](https://github.com/dotnet/core) - a cross-platform, open-source .NET platform
* [ASP.NET Core](https://github.com/dotnet/aspnetcore) - a .NET Core framework for building web apps
* [Extensions](https://github.com/dotnet/extensions) - Logging, configuration, dependency injection, and more.
* [Documentation](https://github.com/aspnet/Docs) - documentation sources for https://docs.microsoft.com/aspnet/core/
* [Entity Framework Core](https://github.com/dotnet/efcore) - data access technology

## AspDotnetCoreHelloWorld
- Play With Kestrel Config

## ChainofResponsibilityHelloWorld
How to build middleware pipeline

## CircularReference
ChickenService and EggService is using constructor dependency injection
This will cause throwing runtime error: circular reference.

**Question**: How to create IoC container to enable other DI other than via constructor?

## MyIoC

**MyContainerV0**

0. create instance, with 1 layer of constuctor DI

**MyContainerV1**
1. multiple parameters in the constructor

2. multiple constructors (IServiceCollection will choose the super constructor, with the most parameters)

>Use Attribute to mark the desired constructor, e.g. BService

3. DI by Property, DI by method (IServiceCollection only support constructor DI)

>Property attribute or method attribute

4. how to deal with 1 interface with several implementations?

5. how to pass a const value to constructor?

**MyContainerV2**

6. life cycle support

>`AddTransient()`

>`AddSingleton()` --- singleton across all requests

>`AddScoped()` --- basically singlton per request, singleton in child container

>`AddPerThread()` --- (This is not well implemented.)
