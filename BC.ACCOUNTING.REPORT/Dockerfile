# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BC.ACCOUNTING.REPORT/BC.ACCOUNTING.REPORT.csproj", "BC.ACCOUNTING.REPORT/"]
COPY ["BC.ACCOUNTING.APPLICATION/BC.ACCOUNTING.APPLICATION.csproj", "BC.ACCOUNTING.APPLICATION/"]
COPY ["BC.ACCOUNTING.CORE/BC.ACCOUNTING.CORE.csproj", "BC.ACCOUNTING.CORE/"]
COPY ["BC.ACCOUNTING.INFRASTRUCTURE/BC.ACCOUNTING.INFRASTRUCTURE.csproj", "BC.ACCOUNTING.INFRASTRUCTURE/"]
COPY ["BC.ACCOUNTING.LOGGING/BC.ACCOUNTING.LOGGING.csproj", "BC.ACCOUNTING.LOGGING/"]
RUN dotnet restore "./BC.ACCOUNTING.REPORT/BC.ACCOUNTING.REPORT.csproj"
COPY . .
WORKDIR "/src/BC.ACCOUNTING.REPORT"
RUN dotnet build "./BC.ACCOUNTING.REPORT.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BC.ACCOUNTING.REPORT.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BC.ACCOUNTING.REPORT.dll"]