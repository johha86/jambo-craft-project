#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/trip-planner-api/trip-planner-api.csproj", "src/trip-planner-api/"]
RUN dotnet restore "src/trip-planner-api/trip-planner-api.csproj"
COPY . .
WORKDIR "/src/src/trip-planner-api"
RUN dotnet build "trip-planner-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "trip-planner-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "trip-planner-api.dll"]