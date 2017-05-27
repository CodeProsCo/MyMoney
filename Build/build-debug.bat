echo Building Web Application

msbuild MyMoney.Application.sln /t:Build /p:Configuration=Debug /p:Platform="Any CPU" /nologo /verbosity:quiet

echo Building Data API

msbuild MyMoney.DataAPI.sln /t:Build /p:Configuration=Debug /p:Platform="Any CPU" /nologo /verbosity:quiet

