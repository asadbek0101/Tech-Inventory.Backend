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

RUN apt-get update && \
    apt-get install -y \
        wget \
        gnupg2 \
        apt-transport-https \
        ca-certificates \
        fonts-liberation \
        libappindicator3-1 \
        libasound2 \
        libatk-bridge2.0-0 \
        libatk1.0-0 \
        libcups2 \
        libdbus-1-3 \
        libgdk-pixbuf2.0-0 \
        libnspr4 \
        libnss3 \
        libx11-xcb1 \
        libxcomposite1 \
        libxdamage1 \
        libxrandr2 \
        xdg-utils \
        libgbm1 \
        libxcb-dri3-0 \
        libxss1 && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tech-Inventory.WebApi.dll"]