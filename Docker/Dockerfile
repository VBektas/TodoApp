FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyasını kopyala (proje kökünden itibaren TodoApp klasörü içinde)
COPY ./TodoApp/*.csproj ./TodoApp/

RUN dotnet restore ./TodoApp/TodoApp.csproj

# Tüm dosyaları kopyala
COPY ./TodoApp/. ./TodoApp/

WORKDIR /src/TodoApp
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TodoApp.dll"]