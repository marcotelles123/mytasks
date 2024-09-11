FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Define o diretório de trabalho dentro do container
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MyTasks.API/MyTasks.API.csproj", "MyTasks.API/"]
COPY ["MyTasks.Domain/MyTasks.Domain.csproj", "MyTasks.Domain/"]
COPY ["MyTasks.Infra/MyTasks.Infra.csproj", "MyTasks.Infra/"]

RUN dotnet restore "MyTasks.API/MyTasks.API.csproj"

COPY . . 

WORKDIR "/src/MyTasks.API"

RUN dotnet build "MyTasks.API.csproj" -c $BUILD_CONFIGURATION -o /app/build/

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MyTasks.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish/

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyTasks.API.dll"]