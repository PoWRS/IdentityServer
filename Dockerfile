#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src

COPY ["./hosts/main/Host.Main.csproj", "/src/hosts/main/"]
COPY ["./src/IdentityServer/Duende.IdentityServer.csproj", "/src/src/IdentityServer/"]
COPY ["./src/Storage/Duende.IdentityServer.Storage.csproj", "/src/src/Storage/"]
RUN dotnet restore "/src/src/Storage/Duende.IdentityServer.Storage.csproj"
RUN dotnet restore "/src/src/IdentityServer/Duende.IdentityServer.csproj"
RUN dotnet restore "/src/hosts/main/Host.Main.csproj"
COPY . .
WORKDIR "/src/hosts/main/"
RUN dotnet build "Host.Main.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Host.Main.csproj" -c Release -o /app/publish  --framework net5.0
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Host.Main.dll"]