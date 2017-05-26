# MyMoney
A personal finance planner written in .NET.

[![Build status](https://ci.appveyor.com/api/projects/status/1f8dil59itpavc5d?svg=true)](https://ci.appveyor.com/project/davidsbond/mymoney)
[![License: AGPL v3](https://img.shields.io/badge/License-AGPL%20v3-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)
[![GitHub issues](https://img.shields.io/github/issues/davidsbond/MyMoney.svg)](https://github.com/davidsbond/MyMoney/issues)

## Libraries Used
### JavaScript & CSS
- [Semantic UI](https://github.com/semantic-org/semantic-ui/)
- [Semantic UI Calendar](https://github.com/mdehoog/Semantic-UI-Calendar)
- [jQuery](https://github.com/jquery/jquery)
- [IntroJS](https://github.com/usablica/intro.js/)
- [Chartist](https://github.com/gionkunz/chartist-js)
- [Toastr](https://github.com/CodeSeven/toastr)
- [Moment](https://github.com/moment/moment/)

### .NET/C# #
- [Cassette.Aspnet](https://github.com/andrewdavey/cassette) - Manages .NET web application assets (scripts, css and templates) 
- [Castle.Windsor](https://github.com/castleproject/Windsor) - Mature Inversion of Control container available for .NET
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) - High-performance JSON framework for .NET 
- [EntityFramework](https://github.com/aspnet/EntityFramework) - A lightweight and extensible version of the popular Entity Framework data access technology
- [Swashbuckle.Core](https://github.com/domaindrivendev/Swashbuckle) - Seamlessly adds a swagger to WebApi projects!
- [WebApiThrottle](https://github.com/stefanprodan/WebApiThrottle) - ASP.NET Web API rate limiter for IIS and Owin hosting

## Contributions
Contributing is fairly simple, firstly, create or assign yourself an issue which you intend to add to the source code. If you are creating an issue, ensure that it is properly labelled and placed in the correct milestone. 

Commit your code in small, manageable chunks. Once you're ready, create a pull request for your code. Ensure that the pull request contains the same labels as the issue, and is named in the format '#{Issue Number} {Issue Name}'. Don't put pull requests in projects or milestones.

When your pull request is created, it will automatically be built in AppVeyor, you will need a passing build and a successful review for your code to be merged into the master branch. If your pull request is approved, it will be mergd into the master branch and your branch will be deleted. Don't worry though, if you need to make further changes you can raise another issue, or your branch can be restored.
