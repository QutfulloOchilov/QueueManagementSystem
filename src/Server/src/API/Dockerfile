FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["src/Domain/QueueManagementSystem.Domain.csproj", "src/Domain/"]
COPY ["src/Application/QueueManagementSystem.Application.csproj", "src/Application/"]
COPY ["src/Services/QueueManagementSystem.Services.csproj", "src/Services/"]
COPY ["src/Infrastructure/QueueManagementSystem.Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/API/QueueManagementSystem.API.csproj", "src/API/"]
RUN dotnet restore "src/API/QueueManagementSystem.API.csproj"

COPY src/ src/
WORKDIR "/src/src/API"
RUN dotnet build "QueueManagementSystem.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QueueManagementSystem.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QueueManagementSystem.API.dll"]