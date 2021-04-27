#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 45656

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["RouletteProject.Api.csproj", "0.UI/RouletteProject.Api/"]
#COPY ["../../1.Application/RouletteProject.Application.Interfaces/RouletteProject.Application.Interfaces.csproj", "1.Application/RouletteProject.Application.Interfaces/"]
#COPY ["../../2.Domain/RouletteProject.Domain.Entities/RouletteProject.Domain.Entities.csproj", "2.Domain/RouletteProject.Domain.Entities/"]
#COPY ["../../3.Infrastructure/RouletteProject.Infrastructure.IoC/RouletteProject.Infrastructure.IoC.csproj", "3.Infrastructure/RouletteProject.Infrastructure.IoC/"]
#COPY ["../../2.Domain/RouletteProject.Domain.Services/RouletteProject.Domain.Services.csproj", "2.Domain/RouletteProject.Domain.Services/"]
#COPY ["../../2.Domain/RouletteProject.Domain.Interfaces/RouletteProject.Domain.Interfaces.csproj", "2.Domain/RouletteProject.Domain.Interfaces/"]
#COPY ["../../1.Application/RouletteProject.Application.Services/RouletteProject.Application.Services.csproj", "1.Application/RouletteProject.Application.Services/"]
#COPY ["../../3.Infrastructure/RouletteProject.Infrastructure.Helpers/RouletteProject.Infrastructure.Helpers.csproj", "3.Infrastructure/RouletteProject.Infrastructure.Helpers/"]
#COPY ["../../3.Infrastructure/RouletteProject.Infrastructure.Repo/RouletteProject.Infrastructure.Repo.csproj", "3.Infrastructure/RouletteProject.Infrastructure.Repo/"]
COPY [".", "/usr/src"]
WORKDIR /usr/src
RUN dotnet restore "0.UI/RouletteProject.ApiRest/RouletteProject.ApiRest.csproj"
COPY . .
WORKDIR "/usr/src/0.UI/RouletteProject.ApiRest"
RUN dotnet build "RouletteProject.ApiRest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RouletteProject.ApiRest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RouletteProject.ApiRest.dll"]
