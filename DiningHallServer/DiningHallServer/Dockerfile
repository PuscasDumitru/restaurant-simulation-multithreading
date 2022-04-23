

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["DiningHallServer/DiningHallServer.csproj", "DiningHallServer/"]
RUN dotnet restore "DiningHallServer/DiningHallServer.csproj"
COPY . .
WORKDIR "/src/DiningHallServer"
RUN dotnet build "DiningHallServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiningHallServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5000
ENTRYPOINT ["dotnet", "DiningHallServer.dll"]