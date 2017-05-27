echo Restoring NuGet packages

nuget restore MyMoney.Application.sln -verbosity quiet
nuget restore MyMoney.DataAPI.sln -verbosity quiet

echo Restored NuGet packages
