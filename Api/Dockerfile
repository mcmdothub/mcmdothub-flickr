# File: 'Dockerfile'
#
# Folder Structure:
# project-root/
# │
# ├── docker-compose.yml
# ├── Api/
# │   ├── src/
# │         ├── Flickr.Api/
# │   ├── Dockerfile
# │   ├── Flickr.Api.sln
#
# Use the official .NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

# Use the .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore sample.api.sln
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Flickr.Api.dll"]
