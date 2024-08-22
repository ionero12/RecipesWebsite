# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["RecipesWebsite_BackendApi.csproj", "."]
RUN dotnet restore "RecipesWebsite_BackendApi.csproj"

# Copy the rest of the application code
COPY . .

# Build the application
RUN dotnet build "RecipesWebsite_BackendApi.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "RecipesWebsite_BackendApi.csproj" -c Release -o /app/publish

# Use the official .NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "RecipesWebsite_BackendApi.dll"]
