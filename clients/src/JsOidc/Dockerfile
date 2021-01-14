#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:9090
EXPOSE 9090

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["/JsOidc.csproj", "src/JsOidc/"]
RUN dotnet restore "src/JsOidc/JsOidc.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "JsOidc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JsOidc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JsOidc.dll"]