#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["./src/IdentityServer/host/packages.lock.json", "/src/src/IdentityServer/src/"]
COPY ["./src/IdentityServer/src/packages.lock.json", "/src/src/IdentityServer/src/"]
COPY ["./src/IdentityServer/host/Host.csproj", "/src/src/IdentityServer/host/"]
COPY ["./src/IdentityServer/src/Duende.IdentityServer.csproj", "/src/src/IdentityServer/src/"]
RUN dotnet restore "/src/src/IdentityServer/src/Duende.IdentityServer.csproj" --lock-file-path "/src/src/IdentityServer/src/packages.lock.json"
RUN dotnet restore "/src/src/IdentityServer/host/Host.csproj" --lock-file-path "/src/src/IdentityServer/host/packages.lock.json"
COPY . .
WORKDIR "/src/src/IdentityServer/host"
RUN dotnet build "Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Host.csproj" -c Release -o /app/publish  --framework net5.0
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Host.dll"]