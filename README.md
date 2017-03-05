# MyMoney
A personal finance planner written in .NET.

## Libraries Used
### JavaScript & CSS
- [Semantic UI](https://github.com/semantic-org/semantic-ui/)
- [jQuery](https://github.com/jquery/jquery)
- [IntroJS](https://github.com/usablica/intro.js/)
- [Chartist](https://github.com/gionkunz/chartist-js)
- [Toastr](https://github.com/CodeSeven/toastr)

### .NET/C# #
- [Cassette.Aspnet](https://github.com/andrewdavey/cassette)
- [Castle.Windsor](https://github.com/castleproject/Windsor)
- [JetBrains.Annotations](https://www.nuget.org/packages/JetBrains.Annotations)
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
- [EntityFramework](https://github.com/aspnet/EntityFramework6)
- [Swashbuckle.Core](https://github.com/domaindrivendev/Swashbuckle)

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
- MyMoney.Web.Assemblers.Tests
- MyMoney.Web.Assemblers	
- MyMoney.Web.DataAccess	
- MyMoney.Web.DependencyInjection	
- MyMoney.Web.Orchestrators.Tests	
- MyMoney.Web.Orchestrators	
- MyMoney.Web

### Shared
- MyMoney.DTO	
- MyMoney.Extensions	
- MyMoney.Helpers	
- MyMoney.Proxies
- MyMoney.Resources	
- MyMoney.Wrappers

### Models
- MyMoney.DataModels	
- MyMoney.Proxies
- MyMoney.ViewModels
