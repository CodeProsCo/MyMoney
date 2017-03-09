# MyMoney
A personal finance planner written in .NET.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Libraries Used
### JavaScript & CSS
- [Semantic UI](https://github.com/semantic-org/semantic-ui/)
- [Semantic UI Calendar](https://github.com/mdehoog/Semantic-UI-Calendar)
- [jQuery](https://github.com/jquery/jquery)
- [IntroJS](https://github.com/usablica/intro.js/)
- [Chartist](https://github.com/gionkunz/chartist-js)
- [Toastr](https://github.com/CodeSeven/toastr)

### .NET/C# #
- [Cassette.Aspnet](https://github.com/andrewdavey/cassette) - Manages .NET web application assets (scripts, css and templates) 
- [Castle.Windsor](https://github.com/castleproject/Windsor) - Mature Inversion of Control container available for .NET
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) - High-performance JSON framework for .NET 
- [EntityFramework](https://github.com/aspnet/EntityFramework) - A lightweight and extensible version of the popular Entity Framework data access technology
- [Swashbuckle.Core](https://github.com/domaindrivendev/Swashbuckle) - Seamlessly adds a swagger to WebApi projects!
- [WebApiThrottle](https://github.com/stefanprodan/WebApiThrottle) - ASP.NET Web API rate limiter for IIS and Owin hosting

## Project Structure
Explained below is the structure of the Visual Studio project.
### API
The API folder contains the following projects:
- MyMoney.API.Assemblers.Tests
- MyMoney.API.Assemblers	
- MyMoney.API.DataAccess	
- MyMoney.API.DependencyInjection	
- MyMoney.API.Orchestrators.Tests	
- MyMoney.API.Orchestrators	
- MyMoney.API

### Web
The Web folder contains the following projects:
- MyMoney.Web.Assemblers.Tests
- MyMoney.Web.Assemblers	
- MyMoney.Web.DataAccess	
- MyMoney.Web.DependencyInjection	
- MyMoney.Web.Orchestrators.Tests	
- MyMoney.Web.Orchestrators	
- MyMoney.Web

### Shared
The Shared folder contains the following projects:
- MyMoney.DTO	
- MyMoney.Extensions	
- MyMoney.Helpers
- MyMoney.Resources	
- MyMoney.Wrappers

### Models
The Models folder contains the following projects:
- MyMoney.DataModels	
- MyMoney.Proxies
- MyMoney.ViewModels
