FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MyNotifications.DiscordSender/MyNotifications.DiscordSender.csproj", "MyNotifications.DiscordSender/"]
COPY ["MyNotifications.DomainModel/MyNotifications.DomainModel.csproj", "MyNotifications.DomainModel/"]
RUN dotnet restore "MyNotifications.DiscordSender/MyNotifications.DiscordSender.csproj"
COPY . .
WORKDIR "/src/MyNotifications.DiscordSender"
RUN dotnet build "MyNotifications.DiscordSender.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MyNotifications.DiscordSender.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyNotifications.DiscordSender.dll"]
