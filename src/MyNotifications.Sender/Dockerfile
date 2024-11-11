FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MyNotifications.Sender/MyNotifications.Sender.csproj", "MyNotifications.Sender/"]
COPY ["src/MyNotifications.DomainModel/MyNotifications.DomainModel.csproj", "MyNotifications.DomainModel/"]
COPY ["src/MyNotifications.Database/MyNotifications.Database.csproj", "MyNotifications.Database/"]
RUN dotnet restore "MyNotifications.Sender/MyNotifications.Sender.csproj"
COPY src/ ./
WORKDIR "/src/MyNotifications.Sender"
RUN dotnet build "MyNotifications.Sender.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MyNotifications.Sender.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyNotifications.Sender.dll"]
