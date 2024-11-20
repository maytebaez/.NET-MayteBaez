# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el archivo de solución y proyectos
COPY clientsMicroservice/clientsMicroservice.sln .
COPY clientsMicroservice/clientsMicroservice.csproj clientsMicroservice/
COPY Tests/Tests.csproj Tests/

# Restaurar las dependencias de NuGet usando el archivo de solución
RUN dotnet restore clientsMicroservice.sln

# Copiar todo el código fuente
COPY clientsMicroservice/. clientsMicroservice/
COPY Tests/. Tests/

# Construir y publicar la aplicación
RUN dotnet publish clientsMicroservice -c Release -o /app/publish

# Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "clientsMicroservice.dll"]