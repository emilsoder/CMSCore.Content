@echo off

START /B /wait dotnet clean
START /B /wait dotnet build

cd "CMSCore.Content.Silo"
START dotnet run --no-build

cd "..\CMSCore.Content.Api"
start dotnet run --no-build