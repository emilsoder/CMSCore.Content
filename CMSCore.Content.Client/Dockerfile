FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY CMSCore.Content.Client/CMSCore.Content.Client.csproj CMSCore.Content.Client/
RUN dotnet restore CMSCore.Content.Client/CMSCore.Content.Client.csproj
COPY . .
WORKDIR /src/CMSCore.Content.Client
RUN dotnet build CMSCore.Content.Client.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CMSCore.Content.Client.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CMSCore.Content.Client.dll"]
