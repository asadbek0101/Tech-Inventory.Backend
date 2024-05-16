#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Tech-Inventory.Application/Tech-Inventory.Application.csproj", "Tech-Inventory.Application/"]
COPY ["Tech-Inventory.Domain/Tech-Inventory.Domain.csproj", "Tech-Inventory.Domain/"]
COPY ["Tech-Inventory.Persistence/Tech-Inventory.Persistence.csproj", "Tech-Inventory.Persistence/"]
COPY ["Tech-Inventory.WebApi/Tech-Inventory.WebApi.csproj", "Tech-Inventory.WebApi/"]
RUN dotnet restore "Tech-Inventory.WebApi/Tech-Inventory.WebApi.csproj"
COPY . .
WORKDIR "/src/Tech-Inventory.WebApi"
RUN dotnet build "Tech-Inventory.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "Tech-Inventory.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tech-Inventory.WebApi.dll"]