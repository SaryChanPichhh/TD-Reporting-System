# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
# For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
`
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

# Install Node.js which is required by the DebugEnsureNodeEnv target in the csproj
RUN apt-get update && \
    apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_20.x | bash - && \
    apt-get install -y nodejs

WORKDIR /src

# Copy project files for caching restore layers
COPY ["BC.ACCOUNTING.REPORT/BC.ACCOUNTING.REPORT.csproj", "BC.ACCOUNTING.REPORT/"]
COPY ["BC.ACCOUNTING.APPLICATION/BC.ACCOUNTING.APPLICATION.csproj", "BC.ACCOUNTING.APPLICATION/"]
COPY ["BC.ACCOUNTING.CORE/BC.ACCOUNTING.CORE.csproj", "BC.ACCOUNTING.CORE/"]
COPY ["BC.ACCOUNTING.INFRASTRUCTURE/BC.ACCOUNTING.INFRASTRUCTURE.csproj", "BC.ACCOUNTING.INFRASTRUCTURE/"]
COPY ["BC.ACCOUNTING.LOGGING/BC.ACCOUNTING.LOGGING.csproj", "BC.ACCOUNTING.LOGGING/"]

RUN dotnet restore "./BC.ACCOUNTING.REPORT/BC.ACCOUNTING.REPORT.csproj"
COPY . .
WORKDIR "/src/BC.ACCOUNTING.REPORT"
RUN dotnet build "./BC.ACCOUNTING.REPORT.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BC.ACCOUNTING.REPORT.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BC.ACCOUNTING.REPORT.dll"]