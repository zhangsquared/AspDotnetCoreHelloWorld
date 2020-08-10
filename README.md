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
ChickenService and EggService is using contructor dependency injection
This will cause throwing runtime error: circular reference.
Question: How to create IoC container to enable other DI other than via constructor

## FailFast
How to fast return false if any of parallel running tasks failed, and cancel the remaining parallel tasks?
* Start(): wait every tasks finished and return a final result. not fail fast
* Start2() and Start2Async(): fast fail, but cannot cancel the remaining tasks
* Start3Async(): fast fail, and also cancel the remaining tasks (need to modify mock job function to pass in the cancellation token)
Question: how to cancel a non-cancellable task?
[Cancel asynchronous operations in C#](https://johnthiriet.com/cancel-asynchronous-operation-in-csharp/) 