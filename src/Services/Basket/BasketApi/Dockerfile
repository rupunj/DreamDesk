FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Services/Basket/BasketApi/BasketApi.csproj", "src/Services/Basket/BasketApi/"]
COPY ["src/Services/Catalog/CatalogAPI/CatalogAPI.csproj", "src/Services/Catalog/CatalogAPI/"]
RUN dotnet restore "src/Services/Basket/BasketApi/BasketApi.csproj"
COPY . .
WORKDIR "/src/src/Services/Basket/BasketApi"
RUN dotnet build "BasketApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "BasketApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketApi.dll"]
