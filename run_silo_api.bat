ECHO OFF
cd CMSCore.Content.Silo
START dotnet run --no-build
cd ..\CMSCore.Content.Api
START dotnet run --no-build