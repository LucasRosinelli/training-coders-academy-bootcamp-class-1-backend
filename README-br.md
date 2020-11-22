# :brazil: Coders Academy Bootcamp
> :gb: [See in English](./README.md)

[![License](https://img.shields.io/github/license/LucasRosinelli/training-coders-academy-bootcamp-class-1-backend)](./LICENSE)

Este repositório é baseado no treinamento **Developer Expert *(Turma 1)*** da [Coders Academy](https://codersacademy.tech/).
- Instrutor: [Rafael Cruz](https://github.com/rafaelcruz-net)
- Visite o [repositório original](https://github.com/rafaelcruz-net/coders-academy-bootcamp-turma-1)

> :warning: **IMPORTANTE**: Antes de rodar a aplicação, tenha certeza que o banco de dados está em execução.
> * Há um arquivo *[Docker Compose](./docker-compose.yml)* com um serviço **SQL Server Express**.
>   1. Execute o comando *Docker Compose* `docker-compose up -d` na pasta da solução.
>   1. Atualize seu banco de dados usando o comando *.NET Core CLI for Entity Framework Core* `dotnet ef database update` na pasta da API.

## Ferramentas
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/community/) *v16.8+*
- [.NET 5.0 SDK](https://dotnet.microsoft.com/download)
- [.NET Core CLI para Entity Framework Core](https://docs.microsoft.com/ef/core/cli/dotnet) *v5.0.0*

### Pacotes (dependências)
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

## Links úteis
- HTTP Status Code
  - [Mozilla](https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status)
  - [Especificação IETF RFC 7231 - HTTP/1.1](https://tools.ietf.org/html/rfc7231#section-6)
- [Especificação OpenAPI 3.0.3](http://spec.openapis.org/oas/v3.0.3)
- Cross-Origin Requests (CORS)
  - [Specification CORS](https://www.w3.org/TR/cors/)
  - [Enable CORS in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-5.0)

## Autor
- [Lucas Rosinelli da Rocha](https://lucasrosinelli.com/)
- [LinkedIn](https://www.linkedin.com/in/lucasrosinelli/)
