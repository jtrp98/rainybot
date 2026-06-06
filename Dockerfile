FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["RainyBot.sln", "./"]
COPY ["src/RainyBot.Api/RainyBot.Api.csproj", "src/RainyBot.Api/"]
COPY ["src/RainyBot.Application/RainyBot.Application.csproj", "src/RainyBot.Application/"]
COPY ["src/RainyBot.Infrastructure/RainyBot.Infrastructure.csproj", "src/RainyBot.Infrastructure/"]
COPY ["src/RainyBot.Domain/RainyBot.Domain.csproj", "src/RainyBot.Domain/"]
COPY ["src/RainyBot.Shared/RainyBot.Shared.csproj", "src/RainyBot.Shared/"]
COPY ["src/RainyBot.Discord/RainyBot.Discord.csproj", "src/RainyBot.Discord/"]
COPY ["tests/RainyBot.UnitTests/RainyBot.UnitTests.csproj", "tests/RainyBot.UnitTests/"]
COPY ["tests/RainyBot.IntegrationTests/RainyBot.IntegrationTests.csproj", "tests/RainyBot.IntegrationTests/"]

RUN dotnet restore "RainyBot.sln"

COPY . .
WORKDIR /src/src/RainyBot.Api
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "RainyBot.Api.dll"]
