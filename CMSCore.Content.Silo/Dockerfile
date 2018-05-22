FROM microsoft/dotnet:2.0-runtime-nanoserver-1709 AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY CMSCore.Content.Silo/CMSCore.Content.Silo.csproj CMSCore.Content.Silo/
COPY CMSCore.Content.Data/CMSCore.Content.Data.csproj CMSCore.Content.Data/
COPY CMSCore.Content.ViewModels/CMSCore.Content.ViewModels.csproj CMSCore.Content.ViewModels/
COPY CMSCore.Content.Models/CMSCore.Content.Models.csproj CMSCore.Content.Models/
COPY CMSCore.Content.Grains/CMSCore.Content.Grains.csproj CMSCore.Content.Grains/
COPY CMSCore.Content.Repository/CMSCore.Content.Repository.csproj CMSCore.Content.Repository/
COPY CMSCore.Content.GrainInterfaces/CMSCore.Content.GrainInterfaces.csproj CMSCore.Content.GrainInterfaces/
RUN dotnet restore CMSCore.Content.Silo/CMSCore.Content.Silo.csproj
COPY . .
WORKDIR /src/CMSCore.Content.Silo
RUN dotnet build CMSCore.Content.Silo.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CMSCore.Content.Silo.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CMSCore.Content.Silo.dll"]
