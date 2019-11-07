## Web Salão

# Passado para instalacão e configuracão do sistemas

## Basic Setup
1. [Install Node.js](https://nodejs.org/)
1. [Install .NET Core 2.2](https://dotnet.microsoft.com/download/)
2. npm install --save-dev @angular-devkit/bild-angular

The Summary is:

  01. Introdução .NET Core
  02. Asp.NET Core - API
  03. Angular
  04. Angular - Interpolação, Diretivas e Binding
  05. .NET Core & EF Core - Organizar em Camadas
  06. Angular - Organizando Projeto
  07. Angular - Reactive Forms
  08. AutoMapper & Data Annotations
  09. Angular - Rotas, Alertas e Mais
  10. Upload de Imagens
  11. Asp.NET Core Identity - (TOKEN e JWT)
  12. Angular + JWT + .NET Core Identity
  13. Eventos, Lotes e Redes Sociais
  14. Deployment e Publish
  15. SQL Server no Docker

## Basic packages.
  
  01. AutoMapper.Extensions.Microsoft.DependencyInjection
  02. Microsoft.EntityFrameworkCore
  03. Microsoft.EntityFrameworkCore.SQLITE(Api/Repositoy)
  04. Microsoft.AspNetCore.Identity.EntityFrameworkCore(Repository/Domain)
  05. Microsoft.AspNetCore.Http
  06. System.IdentityModel.Tokens.Jwt(Api)
  07. Microsoft.AspNetCore.Identity(Api)
  08. Microsoft.WebApplication.targets(Repositoy)

## User Settings

```
# Site settings
title: Fábio Macieira 
description: WebSalao [Angular, .NET Core and EF Core]
baseurl: "" # the subpath of your site, e.g. /blog/ or empty.

# User settings
There're not settings exactly, only files to guide you understand a little bit more about Bootstrap 4
```

## Questions

Having a problem getting something to work or want to know why I setup something in a certain way? Ping me on Twitter [@ozirispc](https://twitter.com/ozirispc) or Message on [Facebook](http://facebook.com/ozirispc)


## Migrations Command

Criar Banco: dotnet ef --startup-project ../ProAgil.WebAPI  migrations add init
Atualizar Banco: dotnet ef --startup-project ../ProAgil.WebAPI  database update

## License

This theme is free and open source software, distributed under the The MIT License. So feel free to use this files on your site without linking back to me or using a disclaimer.

If you’d like to give me credit somewhere on your blog or tweet a shout out to [@ozirispc](https://twitter.com/ozirispc), that would be pretty sweet.

## Rotinas de Criação do Projeto Api
01. Implementar Modelo
02. Implementar ModeloDto
03. Implementar Contexto
04. Implementar AutoMapper
05. Implementar IRepositorio
06. Implementar WebRepository
07. Implementar Controller
08. Implementar View
