#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Planets.Api/Planets.Api.csproj", "Planets.Api/"]
COPY ["Planets.Persistence/Planets.Persistence.csproj", "Planets.Persistence/"]
COPY ["Planets.Domain/Planets.Domain.csproj", "Planets.Domain/"]
COPY ["Planets.Application/Planets.Application.csproj", "Planets.Application/"]
RUN dotnet restore "Planets.Api/Planets.Api.csproj"
COPY . .
WORKDIR "/src/Planets.Api"
RUN dotnet build "Planets.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Planets.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Planets.Api.dll"]