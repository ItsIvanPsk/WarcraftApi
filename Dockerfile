# Imagen base para el runtime de ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Imagen base para el SDK de .NET para compilar
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar los archivos .csproj primero y restaurar dependencias
COPY ["WarcraftApi.sln", "./"]
COPY ["WarcraftApi.DistributedServices.WebApi/WarcraftApi.DistributedServices.WebApi.csproj", "WarcraftApi.DistributedServices.WebApi/"]
COPY ["WarcraftApi.ApplicationServices.Application/WarcraftApi.ApplicationServices.Application.csproj", "WarcraftApi.ApplicationServices.Application/"]
COPY ["WarcraftApi.DistributedServices.Models/WarcraftApi.DistributedServices.Models.csproj", "WarcraftApi.DistributedServices.Models/"]
COPY ["WarcraftApi.DomainServices.Domain/WarcraftApi.DomainServices.Domain.csproj", "WarcraftApi.DomainServices.Domain/"]
COPY ["WarcraftApi.DomainServices.Models/WarcraftApi.DomainServices.Models.csproj", "WarcraftApi.DomainServices.Models/"]
COPY ["WarcraftApi.DomainServices.RepositoryContracts/WarcraftApi.DomainServices.RepositoryContracts.csproj", "WarcraftApi.DomainServices.RepositoryContracts/"]
COPY ["WarcraftApi.Infraestructure.Models/WarcraftApi.Infraestructure.Models.csproj", "WarcraftApi.Infraestructure.Models/"]
COPY ["WarcraftApi.CrossCutting.Utils/WarcraftApi.CrossCutting.Utils.csproj", "WarcraftApi.CrossCutting.Utils/"]
COPY ["WarcraftApi.Infraestructure.Persistance/WarcraftApi.Infraestructure.Persistance.csproj", "WarcraftApi.Infraestructure.Persistance/"]
COPY ["WarcraftApi.Infraestructure.Repository/WarcraftApi.Infraestructure.Repository.csproj", "WarcraftApi.Infraestructure.Repository/"]
COPY ["WarcraftApi.CrossCutting.Aspects/WarcraftApi.CrossCutting.Aspects.csproj", "WarcraftApi.CrossCutting.Aspects/"]

# Copiar los proyectos faltantes
COPY ["WarcraftApi.CrossCutting.Models/WarcraftApi.CrossCutting.Models.csproj", "WarcraftApi.CrossCutting.Models/"]
COPY ["WarcraftApi.DistributedServices.WebApi.Unit.Tests/WarcraftApi.DistributedServices.WebApi.Unit.Tests.csproj", "WarcraftApi.DistributedServices.WebApi.Unit.Tests/"]
COPY ["WarcraftApi.ApplicationServices.Application.Unit.Tests/WarcraftApi.ApplicationServices.Application.Unit.Tests.csproj", "WarcraftApi.ApplicationServices.Application.Unit.Tests/"]
COPY ["WarcraftApi.DomainServices.Domain.Unit.Tests/WarcraftApi.DomainServices.Domain.Unit.Tests.csproj", "WarcraftApi.DomainServices.Domain.Unit.Tests/"]
COPY ["WarcraftApi.Infraestructure.Repository.Unit.Tests/WarcraftApi.Infraestructure.Repository.Unit.Tests.csproj", "WarcraftApi.Infraestructure.Repository.Unit.Tests/"]

# Restaurar las dependencias
RUN dotnet restore "WarcraftApi.sln"

# Copiar el resto del código fuente
COPY . .

# Compilar la aplicación
WORKDIR "/src/WarcraftApi.DistributedServices.WebApi"
RUN dotnet build "WarcraftApi.DistributedServices.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish "WarcraftApi.DistributedServices.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final para correr la aplicación
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Establecer el comando de entrada
ENTRYPOINT ["dotnet", "WarcraftApi.DistributedServices.WebApi.dll"]
