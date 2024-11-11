FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MyNotifications.Database.Migrator/MyNotifications.Database.Migrator.csproj", "MyNotifications.Database.Migrator/"]
COPY ["src/MyNotifications.Database/MyNotifications.Database.csproj", "MyNotifications.Database/"]
COPY ["src/MyNotifications.DomainModel/MyNotifications.DomainModel.csproj", "MyNotifications.DomainModel/"]
RUN dotnet restore "MyNotifications.Database.Migrator/MyNotifications.Database.Migrator.csproj"
COPY src/ ./
WORKDIR "/src/MyNotifications.Database.Migrator"
RUN dotnet build "MyNotifications.Database.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MyNotifications.Database.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyNotifications.Database.Migrator.dll"]
