# MyMoney
A personal finance planner written in .NET.

## Project Structure
Explained below is the structure of the Visual Studio project.
### API
The API folder contains the following projects:
- MyMoney.API.Assemblers.Tests
 - Contains unit tests for the MyMoney.API.Assemblers namespace.
- MyMoney.API.Assemblers	
 - Contains assemblers used to create request objects and parse response objects.
- MyMoney.API.DataAccess	
 - Contains the repository layer of the API which interacts with the database.
- MyMoney.API.DependencyInjection	
 - Contains the dependency injection configuratoin for the API.
- MyMoney.API.Orchestrators.Tests	
 - Contains unit tests for the MyMoney.API.Orchestrators namespace.
- MyMoney.API.Orchestrators	
 - Contains the orchestrators for the API. These perform actions based on the given requests.
- MyMoney.API
 - Contains the main .NET Web API project.

### Web
### Shared
### Models

## JS Libraries Used
- [Semantic UI](https://github.com/semantic-org/semantic-ui/)
- [jQuery](https://github.com/jquery/jquery)
- [IntroJS](https://github.com/usablica/intro.js/)
- [Chartist](https://github.com/gionkunz/chartist-js)
- [Toastr](https://github.com/CodeSeven/toastr)

## .NET Libraries Used
- [Cassette.Aspnet](https://github.com/andrewdavey/cassette)
- [Castle.Windsor](https://github.com/castleproject/Windsor)
- [JetBrains.Annotations](https://www.nuget.org/packages/JetBrains.Annotations)
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
- [EntityFramework](https://github.com/aspnet/EntityFramework6)
- [Swashbuckle.Core](https://github.com/domaindrivendev/Swashbuckle)
