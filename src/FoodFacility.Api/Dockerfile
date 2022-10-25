FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY ./ /

RUN dotnet restore "./src/FoodFacility.Api/FoodFacility.Api.csproj"
RUN dotnet build "./src/FoodFacility.Api/FoodFacility.Api.csproj"
RUN dotnet test "FoodFacility.Api.sln"

FROM build AS publish
RUN dotnet publish "./src/FoodFacility.Api/FoodFacility.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FoodFacility.Api.dll"]
