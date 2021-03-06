# :gb: Coders Academy Bootcamp
> :brazil: [Veja em Português](./README-br.md)

[![License](https://img.shields.io/github/license/LucasRosinelli/training-coders-academy-bootcamp-class-1-backend)](./LICENSE)
[![.NET Core](https://github.com/LucasRosinelli/training-coders-academy-bootcamp-class-1-backend/workflows/.NET%20Core/badge.svg)](./.github/workflows/backend-dotnet-core.yml)

This repository is based on **Developer Expert *(Class 1)*** training by [Coders Academy](https://codersacademy.tech/).
- Instructor: [Rafael Cruz](https://github.com/rafaelcruz-net)
- Visit the [original repository](https://github.com/rafaelcruz-net/coders-academy-bootcamp-turma-1)

> :warning: **IMPORTANT**: Before running the application, make sure you have your database up and running.
> * There is a *[Docker Compose](./docker-compose.yml)* file with a **SQL Server Express** service.
>   1. Run the *Docker Compose* command `docker-compose up -d` in the solution folder.
>   1. Update your database using *.NET Core CLI for Entity Framework Core* command `dotnet ef database update` in the API folder.

## Tools
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/community/) *v16.8+*
- [.NET 5.0 SDK](https://dotnet.microsoft.com/download)
- [.NET Core CLI for Entity Framework Core](https://docs.microsoft.com/ef/core/cli/dotnet) *v5.0.0*

### Packages (dependencies)
- [Swashbuckle - Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Microsoft - Entity Framework Core](https://docs.microsoft.com/ef/core/)
  - EF Core Design
  - EF Core Relational
  - EF Core SQLite
  - EF Core SQL Server
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)
  - Dependency Injection
- [Microsoft - Logging](https://docs.microsoft.com/dotnet/core/extensions/logging)
  - Console Logging

## Useful links
- HTTP Status Code
  - [Mozilla](https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status)
  - [Specification IETF RFC 7231 - HTTP/1.1](https://tools.ietf.org/html/rfc7231#section-6)
- [Specification OpenAPI 3.0.3](http://spec.openapis.org/oas/v3.0.3)
- Cross-Origin Requests (CORS)
  - [Especificação CORS](https://www.w3.org/TR/cors/)
  - [Enable CORS in ASP.NET Core](https://docs.microsoft.com/pt-br/aspnet/core/security/cors?view=aspnetcore-5.0)

## Author
- [Lucas Rosinelli da Rocha](https://lucasrosinelli.com/)
- [LinkedIn](https://www.linkedin.com/in/lucasrosinelli/)
