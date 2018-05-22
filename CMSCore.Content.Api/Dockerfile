FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY CMSCore.Content.Api/CMSCore.Content.Api.csproj CMSCore.Content.Api/
COPY CMSCore.Content.GrainInterfaces/CMSCore.Content.GrainInterfaces.csproj CMSCore.Content.GrainInterfaces/
COPY CMSCore.Content.ViewModels/CMSCore.Content.ViewModels.csproj CMSCore.Content.ViewModels/
RUN dotnet restore CMSCore.Content.Api/CMSCore.Content.Api.csproj
COPY . .
WORKDIR /src/CMSCore.Content.Api
RUN dotnet build CMSCore.Content.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CMSCore.Content.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CMSCore.Content.Api.dll"]
